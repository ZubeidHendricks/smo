import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IApplicationPeriod, IApplicationType, IDepartment, IFinancialYear, IProgramme, ISubProgramme, ISubProgrammeType, IUser } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { UserService } from 'src/app/services/api-services/user/user.service';

@Component({
  selector: 'app-edit-application-period',
  templateUrl: './edit-application-period.component.html',
  styleUrls: ['./edit-application-period.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class EditApplicationPeriodComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  applicationPeriod: IApplicationPeriod = {} as IApplicationPeriod;

  menuActions: MenuItem[];
  profile: IUser;
  validationErrors: Message[];

  applicationPeriodId: string;
  paramSubcriptions: Subscription;
  isDataAvailable: boolean = false;

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;
  departments: IDepartment[];
  selectedDepartment: IDepartment;
  allProgrammes: IProgramme[];
  programmes: IProgramme[] = [];
  selectedProgramme: IProgramme;
  allSubProgrammes: ISubProgramme[];
  subProgrammes: ISubProgramme[] = [];
  selectedSubProgramme: ISubProgramme;
  AllsubProgrammesTypes: ISubProgrammeType[];
  subProgrammesTypes: ISubProgrammeType[] = [];
  selectedSubProgrammeType: ISubProgrammeType;
  applicationTypes: IApplicationType[];
  selectedApplicationType: IApplicationType;
  filteredSubProgrammeType: ISubProgrammeType[];
  openingMinDate: Date;
  closingMinDate: Date;
  disableClosingDate: boolean = true;
  disableOpeningDate: boolean = true;
  finYearRange: string;

  // Highlight required fields on validate click
  validated: boolean = false;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _activeRouter: ActivatedRoute,
    private _loggerService: LoggerService,
    private _userRepo: UserService
  ) { }

  ngOnInit(): void {
    this._spinner.show();
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.applicationPeriodId = params.get('id');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.EditApplicationPeriod))
          this._router.navigate(['401']);

        this.loadDepartments();
        this.loadApplicationTypes();
        this.loadApplicationPeriod();
        this.buildMenu();
      }
    });
  }

  private buildMenu() {
    if (this.profile) {
      this.menuActions = [
        {
          label: 'Validate',
          icon: 'fa fa-check',
          command: () => {
            this.formValidate();
          },
          visible: false
        },
        {
          label: 'Clear Messages',
          icon: 'fa fa-undo',
          command: () => {
            this.clearMessages();
          },
          visible: false
        },
        {
          label: 'Save',
          icon: 'fa fa-floppy-o',
          command: () => {
            this.saveItems();
          }
        },
        {
          label: 'Go Back',
          icon: 'fa fa-step-backward',
          command: () => {
            this._router.navigateByUrl('application-periods');
          }
        }
      ];
    }
  }

  private formValidate() {
    this.validated = true;
    this.validationErrors = [];

    let data = this.applicationPeriod;

    if (!this.selectedDepartment || !this.selectedProgramme || !this.selectedSubProgramme || !this.selectedApplicationType || !data.description || !this.selectedFinancialYear || !data.openingDate || !data.closingDate)
      this.validationErrors.push({ severity: 'error', summary: "Edit Programme:", detail: "Missing detail required." });

    if (this.validationErrors.length == 0)
      this.menuActions[1].visible = false;
    else
      this.menuActions[1].visible = true;
  }

  private clearMessages() {
    this.validated = false;
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }

  private saveItems() {
    if (this.canContinue()) {
      this._spinner.show();
      let data = this.applicationPeriod;

      data.departmentId = this.selectedDepartment.id;
      data.programmeId = this.selectedProgramme.id;
      data.subProgrammeId = this.selectedSubProgramme.id;
      data.financialYearId = this.selectedFinancialYear.id;
      data.applicationTypeId = this.selectedApplicationType.id;
      data.subProgrammeTypeId = this.selectedSubProgrammeType.id;
      data.openingDate = this.addTwoHours(data.openingDate);
      data.closingDate = this.addTwoHours(data.closingDate);
      data.name = this.selectedSubProgrammeType.name;
      alert(data.name);
      alert(data.subProgrammeTypeId);
      this._applicationPeriodRepo.updateApplicationPeriod(data).subscribe(
        (resp) => {
          this._spinner.hide();
          this._router.navigateByUrl('application-periods');
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private addTwoHours(date: Date) {
    let newDate = new Date(date);
    let nextTwoHours = newDate.getHours() + 2;
    newDate.setHours(nextTwoHours);

    return newDate;
  }

  private canContinue() {
    this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }

  private loadFinancialYears(financialYear: IFinancialYear) {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYears = results;
        this.getFinancialYearRange(financialYear);
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
        this.departments = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadApplicationTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ApplicationTypes, false).subscribe(
      (results) => {
        this.applicationTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammes(departmentId: number) {
    if (departmentId != null) {
      this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
        (results) => {
          this.allProgrammes = results;
          this.programmes = results.filter(x => x.departmentId === departmentId);
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadSubProgrammes(programmeId: number) {
    if (programmeId != null) {
      this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
        (results) => {
          this.allSubProgrammes = results;
          this.subProgrammes = results.filter(x => x.programmeId === programmeId);
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  disableSubProgrammeType(): boolean {
    if (this.subProgrammesTypes.length > 0)
      return false;

    return true;
  }

  private loadSubProgrammeTypes(subProgramId: number) {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgrammeTypes, false).subscribe(
      (results) => {
        this.AllsubProgrammesTypes = results.filter(x=> x.subProgrammeId === subProgramId);
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  subProgrammeChange(subProgram: ISubProgramme) {
    this.selectedSubProgrammeType = null;
    this.subProgrammesTypes = [];
    if (subProgram.id != null) {
      for (var i = 0; i < this.AllsubProgrammesTypes.length; i++) {
        if (this.AllsubProgrammesTypes[i].subProgrammeId == subProgram.id) {
          this.subProgrammesTypes.push(this.AllsubProgrammesTypes[i]);
        }
      }
    }
  }

  subProgramTypeChange(subProgramType: ISubProgrammeType)
  {
    this.loadSubProgrammeTypes(subProgramType.id);
  }

  private loadApplicationPeriod() {
    if (this.applicationPeriodId != null) {
      this._applicationPeriodRepo.getApplicationPeriodById(Number(this.applicationPeriodId)).subscribe(
        (results) => {
          this.loadFinancialYears(results.financialYear);
          this.loadProgrammes(results.departmentId);
          this.loadSubProgrammes(results.programmeId);
          this.loadSubProgrammeTypes(results.subProgrammeId);
          this.updateDateField(results.financialYear.startDate, 'opening date');
          this.updateDateField(results.openingDate, 'closing date');

          this.disableOpeningDate = false;
          this.disableClosingDate = false;

          this.selectedDepartment = results.department;
          this.selectedProgramme = results.programme;
          this.selectedSubProgramme = results.subProgramme;
          this.selectedSubProgrammeType = results.subProgrammeType;
          this.selectedFinancialYear = results.financialYear;
          this.selectedApplicationType = results.applicationType;

          results.openingDate = new Date(results.openingDate);
          results.closingDate = new Date(results.closingDate);

          this.applicationPeriod = results;
          this.isDataAvailable = true;
          this.loadCreatedUser();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadCreatedUser() {
    this._userRepo.getUserById(this.applicationPeriod.createdUserId).subscribe(
      (results) => {
        this.applicationPeriod.createdUser = results;
        this.loadUpdatedUser();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadUpdatedUser() {
    if (this.applicationPeriod.updatedUserId) {
      this._userRepo.getUserById(this.applicationPeriod.updatedUserId).subscribe(
        (results) => {
          this.applicationPeriod.updatedUser = results;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else {
      this.applicationPeriod.updatedUser = {} as IUser;
      this._spinner.hide();
    }
  }

  departmentChange(department: IDepartment) {
    this.selectedProgramme = null;
    this.selectedSubProgramme = null;

    this.programmes = [];
    this.subProgrammes = [];

    if (department.id != null) {
      for (var i = 0; i < this.allProgrammes.length; i++) {
        if (this.allProgrammes[i].departmentId == department.id) {
          this.programmes.push(this.allProgrammes[i]);
        }
      }
    }
  }

  programmeChange(programme: IProgramme) {
    this.selectedSubProgramme = null;

    this.subProgrammes = [];

    if (programme.id != null) {
      for (var i = 0; i < this.allSubProgrammes.length; i++) {
        if (this.allSubProgrammes[i].programmeId == programme.id) {
          this.subProgrammes.push(this.allSubProgrammes[i]);
        }
      }
    }
  }

  openingDateSelected(date: Date) {
    this.applicationPeriod.closingDate = null;
    this.updateDateField(date, 'closing date');
    this.disableClosingDate = false;
  }

  closingDateSelected(date: Date) {
    if (this.applicationPeriod.openingDate > date)
      this.applicationPeriod.closingDate = this.applicationPeriod.openingDate;
  }

  financialYearChange(finYear: IFinancialYear) {
    this.applicationPeriod.openingDate = null;
    this.getFinancialYearRange(finYear);
    this.updateDateField(finYear.startDate, 'opening date');
    this.disableOpeningDate = false;
  }

  private updateDateField(date: Date, dateField: string) {
    let newDate = new Date(date);

    if (dateField === 'opening date')
      this.openingMinDate = new Date();
    else
      this.closingMinDate = newDate;
  }

  private getFinancialYearRange(finYear: IFinancialYear) {
    if (this.financialYears.length > 0) {
      let start = this.financialYears.find(x => x.id === finYear.id);
      let end = this.financialYears[this.financialYears.length - 1];
      this.finYearRange = `${start.year}:${end.year}`;
    }
  }
}
