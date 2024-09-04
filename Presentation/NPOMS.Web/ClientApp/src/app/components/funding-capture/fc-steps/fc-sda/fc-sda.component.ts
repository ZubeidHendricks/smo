import { Component, Input, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { DropdownTypeEnum } from 'src/app/models/enums';
import { IFundingDetailViewModel, INpoViewModel, IPlace, ISDA, ISDAViewModel } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-fc-sda',
  templateUrl: './fc-sda.component.html',
  styleUrls: ['./fc-sda.component.css']
})
export class FCSDAComponent implements OnInit {

  @Input() toggleable: boolean;
  @Input() sda: ISDAViewModel;
  @Input() npo: INpoViewModel;
  @Input() fundingDetail: IFundingDetailViewModel;
  @Input() isEdit: boolean;

  private _validated: boolean;
  @Input()
  get validated(): boolean { return this._validated; }
  set validated(validated: boolean) { this._validated = validated; }

  sdas: ISDA[];
  selectedSDA: ISDA;

  places: IPlace[];
  filteredPlaces: IPlace[];
  selectedPlace: IPlace;

  constructor(
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _npoProfileRepo: NpoProfileService,
    private _fundingManagementRepo: FundingManagementService
  ) { }

  ngOnInit(): void {
    this.loadProgrammeDeliveryDetailsById();
  }

  private loadProgrammeDeliveryDetailsById() {
    this._spinner.show();
    this._npoProfileRepo.getProgrammeDeliveryDetailsById(this.fundingDetail.programmeId, this.npo.npoProfileId).subscribe(
      (results) => {
        this.sdas = [];

        let programDeliveryDetails = results.filter(x => x.subProgrammeId === this.fundingDetail.subProgrammeId && x.subProgrammeTypeId === this.fundingDetail.subProgrammeTypeId);
        programDeliveryDetails.forEach(detail => {
          if (detail.serviceDeliveryAreas.length > 0) {
            detail.serviceDeliveryAreas.forEach(sda => {
              this.sdas.push(sda);
            });
          }
        });

        this.selectedSDA = this.sda.serviceDeliveryAreaId ? this.sdas.find(x => x.id === this.sda.serviceDeliveryAreaId) : null;
        this.sda.serviceDeliveryAreaName = this.selectedSDA ? this.selectedSDA.name : null;
        this.loadPlaces();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadPlaces() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Places, false).subscribe(
      (results) => {
        this.places = results;
        
        this.filteredPlaces = this.sda.serviceDeliveryAreaId ? this.places.filter(x => x.serviceDeliveryAreaId === this.sda.serviceDeliveryAreaId) : [];
        this.selectedPlace = this.sda.placeId ? this.places.find(x => x.id === this.sda.placeId) : null;
        
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public sdaChange(sda: ISDA) {
    this.selectedPlace = null;
    this.filteredPlaces = this.places.filter(x => x.serviceDeliveryAreaId === sda.id);
    this.valueChanged();
  }

  public valueChanged() {
    this.sda.serviceDeliveryAreaId = this.selectedSDA ? this.selectedSDA.id : null;
    this.sda.placeId = this.selectedPlace ? this.selectedPlace.id : null;
    this._fundingManagementRepo.updateSDA(this.sda).subscribe();
  }
}
