import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDepartment, IProgramme, IProgrammes, IRole, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { UserService } from 'src/app/services/api-services/user/user.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class UsersComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  isSystemAdmin: boolean = true;
  userDepartmentId: number;

  newUserForm: FormGroup;
  editUserForm: FormGroup;

  displayNewDialog: boolean = false;
  displayEditDialog: boolean = false;

  users: IUser[];
  roles: IRole[];
  departments: IDepartment[];
  department: IDepartment;
  userPrograms: IProgramme[];

  selectedUser: IUser;
  selectedDepartment: IDepartment;
  selectedRoles: IRole[] = [];
  selectedPrograms: IProgramme[] = [];
  searchResult: any[] = [];
  inActive: boolean;
  profile: IUser;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _messageService: MessageService,
    private _spinner: NgxSpinnerService,
    private _userRepo: UserService,
    private _formBuilder: FormBuilder,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _router: Router,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewUsers))
          this._router.navigate(['401']);

        this.userDepartmentId = profile.departments.length > 0 ? profile.departments[0].id : null;
        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });

        if (!this.isSystemAdmin)
        {
          //  this.loadRoles();
          this.loadDepartments();
          this.loadPrograms();
        }
        else{
          this.loadDepartments();
        }
        
        this.loadUsers();        
      }
    });

    this.newUserForm = this._formBuilder.group({});
    this.editUserForm = this._formBuilder.group({});
  }

  private loadUsers() {
    this._spinner.show();
    this._userRepo.getAllUsers().subscribe(
      (users) => {
        this.users = users;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadRoles() {
    if (this.isSystemAdmin != null) {
      this._spinner.show();
      this._dropdownRepo.getEntities(DropdownTypeEnum.Roles, false).subscribe(
        (results) => {
          if (!this.isSystemAdmin) {
            results.forEach((element, index) => {
              if (element.id === RoleEnum.SystemAdmin)
                results.splice(index, 1);
            });
          }

          this.roles = results;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

 loadDepartments() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Departments, false).subscribe(
      (results) => {
        this.departments = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  loadPrograms(id: number = 0) {
      this._spinner.show();
      if(!this.isSystemAdmin)
      {
        id = this.userDepartmentId;
      }
      const programs$ = this._dropdownRepo.GetProgramsByDepartment(DropdownTypeEnum.FilteredProgrammesByDepartment, id);
      const roles$ = this._dropdownRepo.GetRolesByDepartment(DropdownTypeEnum.FilteredRolesByDepartment, id);

      forkJoin([programs$, roles$]).subscribe({
          next: ([programs, roles]) => {
            this.userPrograms = programs as IProgramme[];
            this.roles = roles as IRole[];
            if (this.isSystemAdmin) {                 
              this.department = this.departments.find(department => department.id === id);
              if (this.department) {
                  if(this.department.name.toLocaleLowerCase() === 'health')
                  {
                      const preselectedProgram = this.userPrograms.find(program => program.name.toLocaleLowerCase() === 'all programmes');
                      if (preselectedProgram) {
                          this.selectedPrograms = [preselectedProgram];
                      }
                  }
                  else{
                    this.selectedPrograms=[];
                  }
              }
          }
          },
          error: (err) => {
              this._loggerService.logException(err);
          },
          complete: () => {
              this._spinner.hide();
          }
      });
  }


  add() {
    this.openNewDialog();
  }

  private openNewDialog() {
    this.clearInputs();
    this.displayNewDialog = true;
  }

  openEditDialog(user: IUser) {
    this.clearInputs();
    this.selectedUser = user;

    if (user.departments.length > 0) {
        this.selectedDepartment = this.departments.find(x => x.id === user.departments[0].id);

        if (this.selectedDepartment) {
          const programs$ = this._dropdownRepo.GetProgramsByDepartment(DropdownTypeEnum.FilteredProgrammesByDepartment, this.selectedDepartment.id);
          const roles$ = this._dropdownRepo.GetRolesByDepartment(DropdownTypeEnum.FilteredRolesByDepartment, this.selectedDepartment.id);
    
          forkJoin([programs$, roles$]).subscribe({
              next: ([programs, roles]) => {
                this.userPrograms = programs as IProgramme[];
                this.roles = roles as IRole[];
                this.selectedRoles = user.roles.map(role => this.roles.find(x => x.id === role.id)).filter(role => role);
                this.selectedPrograms = user.userPrograms.map(program => this.userPrograms.find(x => x.id === program.id)).filter(program => program);    
              },
              error: (err) => {
                  this._loggerService.logException(err);
              },
              complete: () => {
                  this._spinner.hide();
              }
          });   
        }
    }

    this.inActive = !this.selectedUser.isActive;

    this.displayEditDialog = true;
  }


  searchUser(event) {
    let searchTerm = event.query;
    this._userRepo.searchForUser(searchTerm).subscribe(result => {
      this.searchResult = result;
    });
  }

  disableSubmit() {
    if (!this.selectedUser)
      return true;

    if (this.isSystemAdmin)
      if (!this.selectedDepartment)
        return true;

    if (this.selectedRoles.length == 0)
      return true;

    return false;
  }

  submit() {
    const newUser = {} as IUser;
    newUser.fullName = this.selectedUser.fullName;
    newUser.firstName = this.selectedUser.firstName;
    newUser.lastName = this.selectedUser.lastName;
    newUser.email = this.selectedUser.email;
    newUser.userName = this.selectedUser.userName;
    newUser.isActive = !this.inActive;
    newUser.roles = this.selectedRoles;
    newUser.userPrograms = this.selectedPrograms;
    newUser.departments = [];
    //newUser.programs = [];

    if (this.isSystemAdmin)
      newUser.departments.push(this.departments.filter(x => x.id === this.selectedDepartment.id)[0]);
    else
      newUser.departments.push(this.departments.filter(x => x.id === this.userDepartmentId)[0]);

    this._userRepo.createUser(newUser)
      .subscribe({
        next: (x) => {
          this.newUserForm.reset();
          this.clearInputs();
          this.loadUsers();

          //notify user
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'User successfully created.' });
          this._spinner.hide();
        },
        error: err => {
          //do something
          //this.errorMessage = err;
          this._messageService.add({ severity: 'error', summary: 'Error', detail: 'User could not be created.' });
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      });

    this.displayNewDialog = false;
  }

  updateUser() {
    const editUser = {} as IUser;
    editUser.userName = this.selectedUser.userName;
    editUser.isActive = !this.inActive;
    editUser.roles = this.selectedRoles;
    editUser.roles = editUser.roles.filter(role => this.roles.some(deptRole => deptRole.id === role.id));
    editUser.userPrograms = this.selectedPrograms;
    editUser.userPrograms = editUser.userPrograms.filter(deProg => this.userPrograms.some(userPrograms => userPrograms.id === deProg.id));
    editUser.departments = [];
    if (this.isSystemAdmin)
      editUser.departments.push(this.departments.filter(x => x.id === this.selectedDepartment.id)[0]);
    else
      editUser.departments.push(this.departments.filter(x => x.id === this.userDepartmentId)[0]);

    this._userRepo.updateUser(editUser)
      .subscribe({
        next: (x) => {
          this.editUserForm.reset();
          this.clearInputs();
          this.loadUsers();

          //notify 
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'User successfully updated.' });
          this._spinner.hide();
        },
        error: err => {
          //do something
          //this.errorMessage = err;
          this._messageService.add({ severity: 'error', summary: 'Error', detail: 'User could not be updated.' });
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      });

    this.displayEditDialog = false;
  }

  private clearInputs() {
    this.selectedUser = null;
    this.selectedDepartment = null;
    this.selectedRoles = [];
    this.selectedPrograms = [];
    this.inActive = null;
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  canEdit() {
    return !this.IsAuthorized(PermissionsEnum.EditUsers);
  }
}
