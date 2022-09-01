import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { ITrainingMaterial, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-training-material',
  templateUrl: './training-material.component.html',
  styleUrls: ['./training-material.component.css']
})
export class TrainingMaterialComponent implements OnInit {

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

  trainingMaterials: ITrainingMaterial[];
  cols: any[];

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _spinner: NgxSpinnerService,
    private _dropdownService: DropdownService,
    private _authService: AuthService,
    private _router: Router,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewTrainingMaterial))
          this._router.navigate(['401']);

        this.loadTrainingMaterials();
      }
    });

    this.cols = [
      { field: 'name', header: 'Name', width: '25%' },
      { field: 'description', header: 'Description', width: '60%' }
    ];
  }

  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    return value;
  }

  private loadTrainingMaterials() {
    this._spinner.show();

    this._dropdownService.getEntities(DropdownTypeEnum.TrainingMaterial, false).subscribe(
      (results) => {
        this.trainingMaterials = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
