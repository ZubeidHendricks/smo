import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { DepartmentEnum, DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDenodoBudget, IDepartment, IFinancialYear, IProgramme, ISubProgramme, ISubProgrammeType, IUser, ISegmentCode } from 'src/app/models/interfaces';
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
        this.loadProgrammes();
        this.loadSubProgrammes();
        this.loadProgrammeTypes();
        this.loadFinancialYears();
        
      }
    });

    this.budgetCols = [
      { header: 'Programme', width: '15%' },
      { header: 'Sub Programme', width: '15%' },
      { header: 'Sub Programme Type', width: '15%' },
      { header: 'Original Budget', width: '15%' },
      { header: 'Adjusted Budget', width: '15%' },
      { header: 'Allocated', width: '15%' },
      { header: 'Balance', width: '10%' }
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
        this.loadDepartments();
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
        this.departments = results.filter(x => x.id != DepartmentEnum.ALL && x.id != DepartmentEnum.NONE);

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

  private loadProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.programmes = results;

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

  private loadSegmentCode(id: number) {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SegmentCode, false).subscribe(
      (results) => {       
        this.segmentCode = results;
         this.filteredSegmentCode = this.segmentCode.filter(x=> x.programmeId === id);
         console.log('this.filteredSegmentCode', this.filteredSegmentCode);
       
        this._spinner.hide();
      }, 
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  departmentSummaryChange() {
    //this.loadBudgets();
  }

  loadPrograms(id: number) {
   
    this.filteredProgrammes = this.programmes.filter(x => x.departmentId === id); 
}

  programmeChange(id: number)
  {
    this.filteredSubProgrammes = this.subProgrammes.filter(x => x.programmeId === id);
    this.loadSegmentCode(id);

  }

  subProgrammeChange(id: number)
  {
    this.filteredSubProgrammeType = this.subProgrammeType.filter(x => x.subProgrammeId === id);
  }

  financialYearSummaryChange() {
    this.loadBudgets();
  }

  private loadBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {
      this._spinner.show();

      this._budgetRepo.getBudgets(this.selectedDepartmentSummary.denodoDepartmentName, this.selectedFinancialYearSummary.year).subscribe(
        (results) => {

          

          this.denodoBudgets = results ? results.elements : [];

          this.denodoBudgets.forEach(application => {
            this.setProgrammeName(application);
          });

          //found at: https://stackoverflow.com/questions/31005396/filter-array-of-objects-with-another-array-of-objects
          this.filteredDenodoBudgets = this.denodoBudgets.filter((el) => {
            return this.filteredSegmentCode.some((f) => {
              return f.responsibilityCode === el.responsibilitylowestlevelcode && f.objectiveCode === el.objectivelowestlevelcode && Number(el.originalbudget) > 0;
            });
          });

          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private setProgrammeName(data: IDenodoBudget) {
    let responsibilityCode = data.responsibilitylowestlevelcode;
    let objectiveCode = data.objectivelowestlevelcode;
    let id =  this.segmentCode.filter(x=> x.responsibilityCode === responsibilityCode && x.objectiveCode === objectiveCode);
    if(id.length > 0)
    {     
      let programmeName = this.filteredProgrammes.filter(x=> x.id === id[0].programmeId);
      let subProgrammeName = this.subProgrammes.filter(x=> x.programmeId === programmeName[0].id);
      let subProgrammeTypeName = this.subProgrammeType.filter(x=> x.subProgrammeId === subProgrammeName[0].id)
      data.programme = programmeName[0].name;
      
      if(subProgrammeName.length > 0)
        data.subProgramme = subProgrammeName[0].name;
      
      if(subProgrammeTypeName.length > 0)
        data.subProgrammeType = subProgrammeTypeName[0].name;
    }    
  }
}
