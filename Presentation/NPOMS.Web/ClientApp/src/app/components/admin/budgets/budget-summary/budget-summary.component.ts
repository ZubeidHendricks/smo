import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { DepartmentEnum, DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDenodoBudget, IDepartment, IFinancialYear, IProgramme, ISubProgramme, ISubProgrammeType, IUser, ISegmentCode, IProgrammeBudgets } from 'src/app/models/interfaces';
import { BudgetService } from 'src/app/services/api-services/budget/budget.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-budget-summary',
  templateUrl: './budget-summary.component.html',
  styleUrls: ['./budget-summary.component.css']
})
export class BudgetSummaryComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  profile: IUser;
  budgetCols: any[];
  denodoBudgets: IDenodoBudget[];
  filteredDenodoBudgets: IDenodoBudget[];
  programmeBudgets: IProgrammeBudgets[];

  financialYears: IFinancialYear[];
  selectedFinancialYearSummary: IFinancialYear;

  departments: IDepartment[];
  selectedDepartmentSummary: IDepartment;
  isSystemAdmin: boolean;
  rowGroupMetadataActivities: any[];

  programmes: IProgramme[];
  filteredProgrammes: IProgramme[];
  selectedProgrammes: IProgramme;
  subProgrammes: ISubProgramme[];
  filteredSubProgrammes: ISubProgramme[];
  selectedSubProgrammes: ISubProgramme;
  subProgrammeType: ISubProgrammeType[];
  filteredSubProgrammeType: ISubProgrammeType[];
  selectedSubProgrammeType: ISubProgrammeType;
  segmentCode: ISegmentCode[] = [];
  filteredSegmentCode: ISegmentCode[] = [];
  totalBudget: number;
  totalAdjustedBudget: number;
  totalProvisionalBudget: number;
  selectedProgram: any;
  selectedSubProgram: any;
  selectedSubProgramType: any;
  filterProgramIds: string;
  filterSubProgramIds: string;
  filterSubProgramTypeIds: string;
  filteredSubProgramTypeIds: number[];
  linkedProgramId: any;
  filteredLinkedProgramId: string;
  filteredLinkedProgramIds: number[];

  list: any[] = [];
  item: any;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    private _budgetRepo: BudgetService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewBudgetSummary))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
       
        this.loadDepartments();       
        this.loadFinancialYears();
      }
    });

    this.budgetCols = [
     
      { header: 'ApprovedBudget', width: '13%' },
      { header: 'ProvisionalBudget', width: '13%' },
      { header: 'AdjustedBudget', width: '13%' },
      { header: 'Allocated', width: '13%' },
      { header: 'Paid', width: '13%' },
      { header: 'Balance', width: '13%' }
    ];
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        //Get until current financial year
        let currentDate = new Date();
        let currentFinancialYear = results.find(x => new Date(x.startDate) <= currentDate && new Date(x.endDate) >= currentDate);
        this.financialYears = results.filter(x => x.id <= currentFinancialYear.id);
       
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDepartments() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Departments, false).subscribe(
      (results) => {
        
        if(this.isSystemAdmin )
          {
            this.departments = results.filter(x => x.id != DepartmentEnum.ALL && x.id != DepartmentEnum.NONE);
          }
          else{
            this.departments = results.filter(x => x.id === this.profile.departments[0].id);
          }

        // In Programme Budget Summary...
        // If user is system admin, show department dropdown
        // If user is not system admin, default department to assigned department in user department table
       
        this.selectedDepartmentSummary = this.isSystemAdmin ? null : this.departments.find(x => x.id === this.profile.departments[0].id);

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  

    departmentSummaryChange() {
    this.loadBudgets();
  }

 
  programmeChange(programs: any[])
  {
    let selectedProgrammes = [];
    selectedProgrammes.push(programs); 

    if (selectedProgrammes.length > 0)
    {
      this.selectedProgram = selectedProgrammes.join(",");
     
      this.filterProgramIds = this.selectedProgram;
      const programIds = this.filterProgramIds.split(',').map(Number);
      
      this.filteredSubProgrammes = this.subProgrammes.filter(item =>
        programIds.includes(item.programmeId)
      );
    }  
    else
    this.selectedProgram = "0";
  }

  subProgrammeChange(subProgram: any[])
  {
    let selectedSubProgrammes = [];
    selectedSubProgrammes.push(subProgram); 
    if (selectedSubProgrammes.length > 0)
    {
      this.selectedSubProgram = selectedSubProgrammes.join(",");
     
      this.filterSubProgramIds = this.selectedSubProgram;
      const subProgrammeIds = this.filterSubProgramIds.split(',').map(Number);
      
      this.filteredSubProgrammeType = this.subProgrammeType.filter(item =>
        subProgrammeIds.includes(item.subProgrammeId)
      );     
    }  
    else
    this.selectedProgram = "0";
  }

  subProgrammeTypeChange(subProgramType: any[])
  {
    let selectedSubProgrammesType = [];
    selectedSubProgrammesType.push(subProgramType); 

    if (selectedSubProgrammesType.length > 0)
    {
      this.selectedSubProgramType = selectedSubProgrammesType.join(",");
     
      this.filterSubProgramTypeIds = this.selectedSubProgramType;
      const subProgrammeTypeIds = this.filterSubProgramTypeIds.split(',').map(Number);
      
      this.filteredSubProgramTypeIds = subProgrammeTypeIds;

      this.loadBudgets();
    }  
    else
    this.selectedProgram = "0";
  }

  linkedProgram()
  {
    let linkedPrograms = [];

    linkedPrograms.push(this.profile.userPrograms); 

    if (linkedPrograms.length > 0)
    {
      this.linkedProgramId = linkedPrograms.join(",");
     
      this.filteredLinkedProgramId = this.selectedSubProgramType;
      const linkedProgramIds = this.filteredLinkedProgramId.split(',').map(Number);
      
      this.filteredLinkedProgramIds = linkedProgramIds;
    }  
    else
    this.linkedProgramId = "0";
  }

  financialYearSummaryChange() {
    this.loadBudgets();
  }

  private loadBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {
      this._spinner.show();
      this._budgetRepo.getFilteredBudgets(this.selectedDepartmentSummary.id, this.selectedFinancialYearSummary.year).subscribe(
        (results) => {
          
          this.programmeBudgets = results ? results : [];

          this.totalBudget = this.programmeBudgets.reduce((n, {originalBudgetAmount}) => n + Number(originalBudgetAmount), 0);
          this.totalAdjustedBudget = this.programmeBudgets.reduce((n, {adjustedBudgetAmount}) => n + Number(adjustedBudgetAmount), 0);
          this.totalProvisionalBudget = this.programmeBudgets.reduce((n, {provisionalBudgetAmount}) => n + Number(provisionalBudgetAmount), 0);
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    
    }
  }

  private setSubProgrammeTypeName(data: IProgrammeBudgets) {
    var subProgTypeName = this.subProgrammeType.filter(x=> x.id = data.subProgrammeTypeId);
    data.subProgrammeTypeName = subProgTypeName[0].name;
  }
}
