import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DepartmentEnum, DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDenodoBudget, IDepartment, IFinancialYear, IProgramme, IProgrammeBudget, IProgrammeBudgets, ISegmentCode, ISubProgramme, ISubProgrammeType, IUser } from 'src/app/models/interfaces';
import { BudgetService } from 'src/app/services/api-services/budget/budget.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-programme-budget',
  templateUrl: './programme-budget.component.html',
  styleUrls: ['./programme-budget.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ProgrammeBudgetComponent implements OnInit {

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
  budgets: IDenodoBudget[];
  programmeBudgets: IProgrammeBudgets[];
  financialYears: IFinancialYear[];
  selectedFinancialYearSummary: IFinancialYear;

  displayEditDialog: boolean;
  editProgrammeBudget: boolean;

  departments: IDepartment[];
  selectedDepartmentSummary: IDepartment;

  isSystemAdmin: boolean;
  isDepartmentAdmin: boolean;
  // Details displayed in summary
  totalBudget: number;
  totalAllocated: number;
  totalPaid: number;
  totalBalance: number;
  totalAdjustedBudget: number;
  totalProvisionalBudget: number;
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
  AdjustmentAmount: string;
  ProvisionalAmount: string;
  budgetId: number;
  selectedProgram: any;
  selectedDepartment: any;
  selectedSubProgram: any;
  selectedSubProgramType: any;
  filterProgramIds: string;
  filterDepartmentIds: string;
  filterSubProgramIds: string;
  filterSubProgramTypeIds: string;
  filteredSubProgramTypeIds: number[];
  profileProgramIds: number[];
  profileDepartmentIds: number[];
  linkedProgramId: any;
  filteredLinkedProgramId: string;
  filteredLinkedProgramIds: number[];

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    private _budgetRepo: BudgetService,
    private _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;
        
       
        
        if (!this.IsAuthorized(PermissionsEnum.ViewProgrammeBudget))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.isDepartmentAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.Admin });

        this.loadDepartments();
        this.loadProgrammes();
        this.loadSubProgrammes();
        this.loadProgrammeTypes();
        this.loadSegmentCode();
        this.loadFinancialYears();
        this.ProfileProgramme(this.profile.userPrograms);
        this.ProfileDepartment(this.profile.departments);
      }
    });

    this.budgetCols = [
      { header: 'Programme', width: '14%' },
      { header: 'SubProgramme', width: '14%' },
      { header: 'SubProgrammeType', width: '15%' },
      { header: 'ProvisionalBudget', width: '14%' },
      { header: 'OriginalBudget', width: '13%' },
      { header: 'AdjustedBudget', width: '13%' },
      { header: 'Allocated', width: '9%' },
      { header: 'Balance', width: '9%' }
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
        this.selectedDepartmentSummary = null;
        this.selectedDepartmentSummary = this.departments.find(x => x.id === this.profile.departments[0].id);
        // In Programme Budget Summary...
        // If user is system admin, show department dropdown
        // If user is not system admin, default department to assigned department in user department table
      
        

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  // departmentSummaryChange() {
  //   this.loadBudgets();
  // }
  loadPrograms(id: number) {
    this.filteredProgrammes = this.programmes.filter(x => x.departmentId === id); 
  }
  
  financialYearSummaryChange() {
    this.loadBudgets();
  }

  private loadProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.programmes = results;
        if(this.isSystemAdmin)
        {
          this.filteredProgrammes = this.programmes;
        }
        
        if(!this.isDepartmentAdmin)
        {
          if( this.profileProgramIds != undefined){
            this.filteredProgrammes = this.programmes.filter(item =>
              this.profileProgramIds.includes(item.id)
            );
          }
        }
        else{
          if( this.profileDepartmentIds != undefined){
            this.filteredProgrammes = this.programmes.filter(item =>
              this.profileDepartmentIds.includes(item.departmentId)
            );
          }
        }

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSubProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.subProgrammes = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammeTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgrammeTypes, false).subscribe(
      (results) => {
        this.subProgrammeType = results;
       
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSegmentCode() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SegmentCode, false).subscribe(
      (results) => {       
        this.segmentCode = results;
        this._spinner.hide();
      }, 
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  ProfileProgramme(profileProgram: any[])
  {
    let selectedProgrammes = [];

    profileProgram.forEach(program => 
    {
      selectedProgrammes.push(program.id);
    }
    );

    if(selectedProgrammes.length > 0)
      {
        this.selectedProgram = selectedProgrammes.join(",");
        this.filterProgramIds = this.selectedProgram;
        const programIds = this.filterProgramIds.split(',').map(Number);
        this.profileProgramIds = programIds;
      }     
  }

  ProfileDepartment(profileDepartment: any[])
  {
    let selectedDepartments = [];

    profileDepartment.forEach(department => 
    {
      selectedDepartments.push(department.id);
    }
    );

    if(selectedDepartments.length > 0)
      {
        this.selectedDepartment = selectedDepartments.join(",");
        this.filterDepartmentIds = this.selectedDepartment;
        const departmentIds = this.filterDepartmentIds.split(',').map(Number);
        this.profileDepartmentIds = departmentIds;
      }     
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

  private loadBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {
      this._spinner.show();

      this.totalBudget = 0;
      this.totalAllocated = 0;
      this.totalPaid = 0;
      this.totalBalance = 0;

      this._budgetRepo.getFilteredBudgets(this.selectedDepartmentSummary.id, this.selectedFinancialYearSummary.year).subscribe(
        (results) => {

          this.programmeBudgets = results ? results : [];

          if( this.filteredSubProgramTypeIds != undefined){
            this.programmeBudgets = this.programmeBudgets.filter(item =>
              this.filteredSubProgramTypeIds.includes(item.subProgrammeTypeId)
            );
          }
          else{
            this.programmeBudgets = this.programmeBudgets;
          }         

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

  getColumnSum(columnIndex: number): number {
    let sum = 0;
     
        sum += columnIndex;
    
    return sum;
}


  edit(data: IProgrammeBudget) {
    this.budgetId = data.id;
    this.editProgrammeBudget = true;
    this.displayEditDialog = true;
  }

  SaveAdjustmentAmountData(changesRequired: boolean, origin: string) {

    this._budgetRepo.addAdjustmentAmount(this.AdjustmentAmount, this.budgetId).subscribe(
      (results) => {

       this.displayEditDialog = false;
       this.loadBudgets();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );

  }

  SaveProvisionalAmountData(changesRequired: boolean, origin: string) {

    this._budgetRepo.addProvisionalAmount(this.ProvisionalAmount, this.budgetId).subscribe(
      (results) => {

        this.displayEditDialog = false;
       this.loadBudgets();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );

  }

}
