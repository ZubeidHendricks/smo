import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { BehaviorSubject, Observable } from 'rxjs';
import { PermissionsEnum } from 'src/app/models/enums';
import { IPermission, IRole, IRolePermissionMatrix, IUser } from 'src/app/models/interfaces';
import { PermissionService } from 'src/app/services/api-services/permission/permission.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-permissions',
  templateUrl: './permissions.component.html',
  styleUrls: ['./permissions.component.css'],
  styles: [`
    :host ::ng-deep .p-datatable .p-datatable-thead > tr > th {
      position: -webkit-sticky;
      position: sticky;
      top: 0px;
    }

    @media screen and (max-width: 64em) {
        :host ::ng-deep .p-datatable .p-datatable-thead > tr > th {
            top: 0px;
        }
    }
  `]
})
export class PermissionsComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  private featurePermissionRoleSubject$: BehaviorSubject<IRolePermissionMatrix> = new BehaviorSubject(undefined);
  public featurePermissionRole$: Observable<IRolePermissionMatrix> = this.featurePermissionRoleSubject$.asObservable();

  selectedPermissionRoles: any[] = [];
  previousSelectedPermissionsRole: any[] = [];

  originalMappings: any[]; // used for checking the original permissions in the matrix list

  profile: IUser;
  rowGroupMetadata: any;

  constructor(
    private _repo: PermissionService,
    private _authService: AuthService,
    private _messageService: MessageService,
    private _router: Router,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewPermissions))
          this._router.navigate(['401']);

        this.getPermissionRoleMatrix();
      }
    });
  }

  private getPermissionRoleMatrix() {
    this._spinner.show();
    this._repo.getFeaturePermissionRoleMatrix().subscribe(
      (x) => {
        this.originalMappings = [...x.mappings];
        this.featurePermissionRoleSubject$.next(x);
        this.updateRowGroupMetaData(x);
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  getTableRoleObj(role: IRole, permission: IPermission) {

    //generate temp reference.
    let id = `r_${role.id}_p_${permission.id}`;
    role.tempId = id;
    let newRole = { ...role }; //breaking referency to same role object on different lines
    let removeOriginalItems: any[] = [];

    // hate this looping, but not sure if I can do better without looping :)
    this.originalMappings.forEach(x => {
      if (x.key === permission.systemName) {
        x.value.forEach(y => {
          if (y.key === role.systemName) {
            let isMapped = y.value;
            let exists = this.selectedPermissionRoles.length === 0
              ? []
              : this.selectedPermissionRoles.filter(x => x.tempId === id);

            if (isMapped && exists.length === 0) {
              this.selectedPermissionRoles.push(newRole);
            }
          }
        });
      }
    });

    return newRole;
  }

  onselectedChanged(role: IRole, permission: IPermission) {
    let isSelected: boolean = false;

    this.originalMappings.some(function (mapping) {
      if (mapping.key === permission.systemName) {
        for (let i = 0; i < mapping.value.length; i++) {
          if (mapping.value[i].key === role.systemName) {
            isSelected = mapping.value[i].value;
            break;
          }
        }
      }
    });

    if (isSelected) {
      this._repo.deleteFeaturePermissionFromRole(permission.id, role.id).subscribe(
        (resp) => {
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Permission successfully updated.' });
        },
        (err) => {
          this._loggerService.logException(err);
        }
      );
    }
    else {
      this._repo.addAddFeaturePermissionToRole(permission.id, role.id).subscribe(
        (resp) => {
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Permission successfully updated.' });
        },
        (err) => {
          this._loggerService.logException(err);
        }
      );
    }
  }

  private updateRowGroupMetaData(matrix) {
    this.rowGroupMetadata = {};

    if (matrix) {
      for (let i = 0; i < matrix.availableFeaturePermissions.length; i++) {
        let rowData = matrix.availableFeaturePermissions[i];
        let categoryName = rowData.categoryName;

        if (i == 0) {
          this.rowGroupMetadata[categoryName] = { index: 0, size: 1 };
        }
        else {
          let previousRowData = matrix.availableFeaturePermissions[i - 1];
          let previousRowGroup = previousRowData.categoryName;
          if (categoryName === previousRowGroup)
            this.rowGroupMetadata[categoryName].size++;
          else
            this.rowGroupMetadata[categoryName] = { index: i, size: 1 };
        }
      }
    }
  }

  public getColspan() {
    let numberOfRoles: number;

    this.featurePermissionRole$.subscribe(x => {
      numberOfRoles = x.availableRoles.length;
    });

    return 2 + numberOfRoles;
  }
}
