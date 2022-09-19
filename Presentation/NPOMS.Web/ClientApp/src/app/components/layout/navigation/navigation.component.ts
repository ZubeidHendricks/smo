import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { DepartmentEnum, PermissionsEnum } from 'src/app/models/enums';
import { IUser } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  private _profile: IUser;
  private _isLoggedIn: boolean;

  mainMenu: MenuItem[];
  sideMenu: MenuItem[];
  /*organisationMenu: MenuItem[];
  workplanMenu: MenuItem[];
  accessManagementMenu: MenuItem[];*/
  displaySideMenu: boolean = false;

  get profile() {
    return this._profile;
  }

  get IsLoggedIn() {
    return this._isLoggedIn;
  }

  get profileDetails() {
    let profileText = "";

    if (this.profile) {
      profileText = `${this.profile.fullName}`;
    }

    if (this._authService.loggedInAccount() && !this.profile) {
      profileText = `${this._authService.loggedInAccount().name} ( Offline )`;
    }

    return profileText;
  }

  constructor(
    private _router: Router,
    private _authService: AuthService
  ) { }

  ngOnInit(): void {
    this._authService.canLogIn$.subscribe(status => {
      if (status)
        this._authService.profile$.subscribe(profile => {
          if (profile != null && profile.isActive) {
            this.buildMainMenu();
            this.buildSideMenu();
          }
        });
    });

    this._authService.loggedIn$.subscribe(x => {
      this._isLoggedIn = x;
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this._profile = profile;
        this.buildMainMenu();
        this.buildSideMenu();
      }
    });
  }

  private buildMainMenu() {
    this.mainMenu = [];

    if (this.profile) {
      this.mainMenu.push({
        label: 'Home',
        icon: 'fa fa-home wcg-icon',
        routerLink: '/'
      });

      if (this.IsAuthorized(PermissionsEnum.ViewTrainingMenu)) {
        this.mainMenu.push({
          label: 'Training',
          icon: 'fa fa-graduation-cap wcg-icon',
          command: () => {
            this._router.navigateByUrl('training-material');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewApplyForAccessMenu)) {
        this.mainMenu.push({
          label: 'Apply for Access',
          icon: 'fa fa-user-o wcg-icon',
          command: () => {
            this._router.navigateByUrl('access-request');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewNpoMenu)) {
        this.mainMenu.push({
          label: 'Organisations',
          icon: 'fa fa-university wcg-icon',
          command: () => {
            this._router.navigateByUrl('npos');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewProfileMenu)) {
        this.mainMenu.push({
          label: 'Profiles',
          icon: 'fa fa-address-card wcg-icon',
          command: () => {
            this._router.navigateByUrl('npo-profiles');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewApplicationPeriodMenu)) {
        this.mainMenu.push({
          label: 'Workplan',
          icon: 'fa fa-briefcase wcg-icon',
          command: () => {
            this._router.navigateByUrl('application-periods');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewApplicationMenu)) {
        this.mainMenu.push({
          label: 'Applications',
          icon: 'fa fa-file-text wcg-icon',
          command: () => {
            this._router.navigateByUrl('applications');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewDashboardMenu)) {
        this.mainMenu.push({
          label: 'Dashboard',
          icon: 'fa fa-bar-chart wcg-icon',
          command: () => {
            this._router.navigateByUrl('pbi-dashboard');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewAccessReviewMenu)) {
        this.mainMenu.push({
          label: 'Access Review',
          icon: 'fa fa-user wcg-icon',
          command: () => {
            this._router.navigateByUrl('access-review');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewNpoApprovalMenu)) {
        this.mainMenu.push({
          label: 'Organisation Approval',
          icon: 'fa fa-legal wcg-icon',
          command: () => {
            this._router.navigateByUrl('npo-approval');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewAdminMenu)) {
        this.mainMenu.push({
          label: 'Admin',
          icon: 'fa fa-cogs wcg-icon',
          command: () => {
            this.displaySideMenu = true;
          }
        });
      }
    }
  }

  /*private buildMainMenu() {
    this.mainMenu = [];
    this.organisationMenu = [];
    this.workplanMenu = [];
    this.accessManagementMenu = [];
  
    if (this.profile) {
      this.mainMenu.push({
        label: 'Home',
        icon: 'fa fa-home wcg-icon',
        routerLink: '/'
      });
  
      if (this.IsAuthorized(PermissionsEnum.ViewTrainingMenu)) {
        this.mainMenu.push({
          label: 'Training',
          icon: 'fa fa-graduation-cap wcg-icon',
          command: () => {
            this._router.navigateByUrl('training-material');
          }
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewApplyForAccessMenu)) {
        this.mainMenu.push({
          label: 'Apply for Access',
          icon: 'fa fa-user-o wcg-icon',
          command: () => {
            this._router.navigateByUrl('access-request');
          }
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewNpoMenu)) {
        this.organisationMenu.push({
          label: 'Organisations',
          icon: 'fa fa-university wcg-icon',
          command: () => {
            this._router.navigateByUrl('npos');
          }
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewProfileMenu)) {
        this.organisationMenu.push({
          label: 'Profiles',
          icon: 'fa fa-address-card wcg-icon',
          command: () => {
            this._router.navigateByUrl('npo-profiles');
          }
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewApplyForAccessMenu) || this.IsAuthorized(PermissionsEnum.ViewNpoMenu)) {
        this.mainMenu.push({
          label: 'Organisation Details',
          icon: 'fa fa-university wcg-icon',
          items: this.organisationMenu
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewApplicationPeriodMenu)) {
        this.workplanMenu.push({
          label: 'Workplan',
          icon: 'fa fa-briefcase wcg-icon',
          command: () => {
            this._router.navigateByUrl('application-periods');
          }
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewApplicationMenu)) {
        this.workplanMenu.push({
          label: 'Applications',
          icon: 'fa fa-file-text wcg-icon',
          command: () => {
            this._router.navigateByUrl('applications');
          }
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewApplicationPeriodMenu) || this.IsAuthorized(PermissionsEnum.ViewApplicationMenu)) {
        this.mainMenu.push({
          label: 'Workplans',
          icon: 'fa fa-folder-open wcg-icon',
          items: this.workplanMenu
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewDashboardMenu)) {
        this.mainMenu.push({
          label: 'Dashboard',
          icon: 'fa fa-bar-chart wcg-icon',
          command: () => {
            this._router.navigateByUrl('pbi-dashboard');
          }
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewAccessReviewMenu)) {
        this.accessManagementMenu.push({
          label: 'Access Review',
          icon: 'fa fa-user wcg-icon',
          command: () => {
            this._router.navigateByUrl('access-review');
          }
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewNpoApprovalMenu)) {
        this.accessManagementMenu.push({
          label: 'Organisation Approval',
          icon: 'fa fa-legal wcg-icon',
          command: () => {
            this._router.navigateByUrl('npo-approval');
          }
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewAccessReviewMenu) || this.IsAuthorized(PermissionsEnum.ViewNpoApprovalMenu)) {
        this.mainMenu.push({
          label: 'Access Management',
          icon: 'fa fa-handshake-o wcg-icon',
          items: this.accessManagementMenu
        });
      }
  
      if (this.IsAuthorized(PermissionsEnum.ViewAdminMenu)) {
        this.mainMenu.push({
          label: 'Admin',
          icon: 'fa fa-cogs wcg-icon',
          command: () => {
            this.displaySideMenu = true;
          }
        });
      }
    }
  }*/

  private buildSideMenu() {
    this.sideMenu = [];

    if (this.profile && !this.profile.isB2C) {
      //security
      this.sideMenu.push(
        {
          label: 'Security',
          icon: 'fa fa-users',
          items: [
            {
              label: 'Users',
              icon: 'fa fa-user-plus',
              disabled: !this.IsAuthorized(PermissionsEnum.ViewUsers),
              command: () => {
                this._router.navigateByUrl('admin/users');
                this.displaySideMenu = false;
              }
            },
            {
              label: 'Permissions',
              icon: 'fa fa-shield',
              disabled: !this.IsAuthorized(PermissionsEnum.ViewPermissions),
              command: () => {
                this._router.navigateByUrl('admin/permissions');
                this.displaySideMenu = false;
              }
            }
          ]
        }
      );

      //settings
      this.sideMenu.push(
        {
          label: 'Settings',
          icon: 'fa fa-cog',
          items: [
            {
              label: 'Utilities',
              icon: 'fa fa-wrench',
              disabled: !this.IsAuthorized(PermissionsEnum.ViewUtilities),
              command: () => {
                this._router.navigateByUrl('admin/utilities');
                this.displaySideMenu = false;
              }
            }
          ]
        }
      );
    }

    if (this.profile.departments[0].id === DepartmentEnum.ALL || this.profile.departments[0].id === DepartmentEnum.DSD) {
      //budgets
      this.sideMenu.push(
        {
          label: 'Budgets',
          icon: 'fa fa-credit-card-alt',
          items: [
            {
              label: 'Department Budget',
              icon: 'fa fa-sliders',
              disabled: !this.IsAuthorized(PermissionsEnum.ViewDepartmentBudget),
              command: () => {
                this._router.navigateByUrl('admin/department-budget');
                this.displaySideMenu = false;
              }
            },
            {
              label: 'Directorate Budget',
              icon: 'fa fa-sliders',
              disabled: !this.IsAuthorized(PermissionsEnum.ViewDirectorateBudget),
              command: () => {
                this._router.navigateByUrl('admin/directorate-budget');
                this.displaySideMenu = false;
              }
            },
            {
              label: 'Programme Budget',
              icon: 'fa fa-sliders',
              disabled: !this.IsAuthorized(PermissionsEnum.ViewProgrammeBudget),
              command: () => {
                this._router.navigateByUrl('admin/programme-budget');
                this.displaySideMenu = false;
              }
            }
          ]
        }
      );
    }
  }

  login() {
    this._authService.login();
  }

  logout() {
    this._authService.logout();
  }

  signup() {
    this._authService.signup();
  }

  passwordReset() {
    this._authService.passwordReset();
  }

  rolesTooltip() {
    if (this.profile) {
      let allRoles: string = "";

      this.profile.roles.forEach(role => {
        allRoles += role.name + ", ";
      });

      let editedRoles = allRoles.slice(0, -2);
      return editedRoles;
    }
  }
}
