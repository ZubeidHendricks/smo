import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { StatusEnum } from 'src/app/models/enums';
import { IApplication, IFundingApplicationDetails, IPlace, IProjectImplementation, ISubPlace, ISDA} from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';

@Component({
  selector: 'app-project-implementation',
  templateUrl: './project-implementation.component.html',
  styleUrls: ['./project-implementation.component.css']
})
export class ProjectImplementationComponent implements OnInit, OnDestroy {
  [x: string]: any;

  canEdit: boolean;
  @Input() activeStep: number;
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Input() application: IApplication;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() implementations: IProjectImplementation[];
  @Output() implementationsChange = new EventEmitter();
  @Input() programId: number;
  _menuActions: MenuItem[];
  
  projImpls: IProjectImplementation[] = [];
  filteredProjImpls: IProjectImplementation[] = [];

  pint: RegExp = /^[0-9]\d*$/;
  yearRange: string;
  displayDialogImpl: boolean;
  newImplementation: boolean;
  implementation: IProjectImplementation = {} as IProjectImplementation;
  selectedImplementation: IProjectImplementation;
  selectedApplicationId: string;
  paramSubcriptions: Subscription;
  rangeDates: Date[];
  timeframes: Date[] = [];
  cols: any[];

  @Input() places: IPlace[];
  @Input() allsubPlaces: ISubPlace[];
  subPlaces: ISubPlace[];
  subPlacesAll: ISubPlace[];
  selectedSubPlaces: ISubPlace[];
  selectedPlaces: IPlace[];
  selectedSdas: ISDA[];
  sdasAll: ISDA[];
  private subscriptions: Subscription[] = [];
  @Output() getPlace = new EventEmitter<IPlace[]>(); // try to send data from child to child via parent
  @Output() getSubPlace = new EventEmitter<ISubPlace[]>();
  projectImplementations: IProjectImplementation[];
  constructor(
    private _confirmationService: ConfirmationService,
    private _npoProfile: NpoProfileService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _bidService: BidService,
    private _router: Router,
    private _messageService: MessageService
  ) {

  }
  ngOnDestroy(): void {

    this.subscriptions.forEach(function (sub) {
      sub.unsubscribe();
    });
  }

  ngOnInit(): void {

    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.selectedApplicationId = params.get('id');
    });

    this.cols = [
      { header: 'Description', width: '45%' },
      { header: 'Beneficiaries', width: '25%' },
      { header: 'Budget', width: '15%' },
      { header: 'Actions', width: '10%' }
    ];
    this.setYearRange();
    this.allDropdownsLoaded();
    
   
  }

  private filterClubDevelopmentIntakes() {
    this.filteredProjImpls = this.projImpls;
   }

  disableSubPlacesOrPlace(): boolean {

    if (this.places && this.allsubPlaces) {
      return false;
    }
    return true;
  }

  readonly(): boolean {

    if (this.application.statusId == StatusEnum.PendingReview ||
      this.application.statusId == StatusEnum.Approved)
      return true;
    else return false;
  }

  

  onRowSelect(event) {
    this.selectedPlaces = [];
    this.selectedSubPlaces = [];
    this.newImplementation = false;
    this.implementation = this.cloneImplementation(event.data);
    this.implementation.places = this.implementation.places;
    this.implementation.subPlaces = this.implementation.subPlaces;
    this.placesChange(this.implementation.places);
    this.subPlacesChange(this.implementation.subPlaces);
    this.displayDialogImpl = true;
  }

  editProjImpl(data: IProjectImplementation) {
    this.selectedImplementation = data;
    this.selectedPlaces = [];
    this.selectedSubPlaces = [];
    this.newImplementation = false;
    this.implementation = this.cloneImplementation(data);
    this.implementation.places = this.implementation.places;
    this.implementation.subPlaces = this.implementation.subPlaces;
    this.placesChange(this.implementation.places);
    this.subPlacesChange(this.implementation.subPlaces);
    this.displayDialogImpl = true;
  }

  private updateProjImplementations() {
    if (this.places && this.subPlaces && this.projectImplementations) {
      this.projectImplementations.forEach(item => {
        item.places = this.implementation.places;
        item.subPlaces = this.implementation.subPlaces;
        item.beneficiaries = this.implementation.beneficiaries;
        item.budget = this.implementation.budget;
        item.description = this.implementation.description;
      });
    }
    else {
      this.projectImplementations.forEach(item => {
        item.beneficiaries = this.implementation.beneficiaries;
        item.budget = this.implementation.budget;
        item.description = this.implementation.description;
      });
    }
  }

  private GetProjImpl(projImpl: number) {
    this.projectImplementations = null;
    this._npoProfile.getProjImplByfundingApplicationDetailId(Number(this.fundingApplicationDetails.id)).subscribe(
      (results) => {
       this.implementations = results;
      },
      (err) => {
        //
      }
    );
  }

  deleteProjImpl(data: IProjectImplementation) {

    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._npoProfile.deleteProjImpl(data.id).subscribe(
          (resp) => {
            this._bidService.getBid(data.fundingApplicationDetailId).subscribe(response => {

              this.fundingApplicationDetails.implementations = response.implementations;
            });
       // this.activeStepChange.emit(this.activeStep);
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Data deleted successfully.' });
      },
          (err) => {
            //
          }
        );
       
      },
      reject: () => {
        //
      }
    });
  }


  nextPage() {
   // this.activeStep = 7;
    this.activeStepChange.emit(6);
  }
  private setYearRange() {

    let currentDate = new Date;
    let startYear = currentDate.getFullYear() - 5;
    let endYear = currentDate.getFullYear() + 5;

    this.yearRange = `${startYear}:${endYear}`;
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }
  showDialogToAdd() {
    this.selectedPlaces = [];
    this.selectedSubPlaces = [];
    this.newImplementation = true;
    this.implementation = {
      places: [],
      subPlaces: []
    } as IProjectImplementation;
    this.displayDialogImpl = true;
  }

  disableSave(): boolean {
    if (
      !this.implementation.beneficiaries || !this.implementation.budget ||
      !this.implementation.results! || !this.implementation.projectObjective ||
      !this.implementation.resources ||
      !this.implementation.description ||
      (this.places.length > 0 && this.selectedPlaces.length == 0) ||
      (this.allsubPlaces.length > 0 && this.selectedSubPlaces.length == 0)
    )
      return true;

    return false;

  }

  save() {

    this.displayDialogImpl = false;
    this.implementation.beneficiaries = Number(this.implementation.beneficiaries).valueOf();
    this.implementation.budget = Number(this.implementation.budget).valueOf();

    this.implementation.npoProfileId = Number(this.selectedApplicationId);

    let implementation = [...this.implementations];
    if (this.newImplementation) {
      implementation.push(this.implementation);
    }
    else {
       implementation[this.implementations.indexOf(this.selectedImplementation)] = this.implementation;
    }

    this.implementations = implementation;
    this.fundingApplicationDetails.implementations.length = 0;
    this.fundingApplicationDetails.implementations = this.implementations;
    this.implementationsChange.emit(this.implementations);

    this.activeStep = this.activeStep + 1;
    this.bidForm(StatusEnum.Saved);
  }

  cloneImplementation(c: IProjectImplementation): IProjectImplementation {
    let addFun = {} as IProjectImplementation;
    for (let prop in c) {
      addFun[prop] = c[prop];
    }
    return addFun;
  }

  closeDialog() {
    this.displayDialogImpl = false;
  }

  placesChange(p: IPlace[]) {
    this.selectedPlaces = [];
    p.forEach(item => {
      this.selectedPlaces = this.selectedPlaces.concat(this.places.find(x => x.id === item.id));
    });
    this.implementation.places = this.selectedPlaces;
    this.subPlaces = [];

    if (p != null && p.length != 0) {
      for (var i = 0; i < this.subPlacesAll.length; i++) {
        if (this.selectedPlaces.filter(r => r.id === this.subPlacesAll[i].placeId).length != 0) {
          this.subPlaces.push(this.subPlacesAll[i]);

        }
      }
    }
  }

  subPlacesChange(sub: ISubPlace[]) { 
    // create dropdown with data for subPlaces
    this.selectedSubPlaces = [];
    sub.forEach(item => {
      this.selectedSubPlaces = this.selectedSubPlaces.concat(this.subPlacesAll.find(x => x.id == item.id))
    });
    this.implementation.subPlaces = this.selectedSubPlaces;
  }

  onSdaChange(sdas: ISDA[]) {
    this.places = [];
    this.subPlacesAll = [];
    this.selectedSdas = [];
    // this.sdas =[];

    this.setPlaces(sdas); // populate specific locations where the service will be delivered to
    sdas.forEach(item => {
      this.selectedSdas = this.selectedSdas.concat(this.sdasAll.find(x => x.id === item.id));
    });
    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.selectedSdas;
    let count = 0;
    if (this.fundingApplicationDetails.implementations) { // when sds change make sure that fundingApplicationDetails contains correct places 
      let isPlace = [];
      this.fundingApplicationDetails.implementations.find(x => {
        x.places;
        isPlace = x.places
      });

      if (isPlace != null) {
        this.fundingApplicationDetails.implementations.forEach(x => {
          sdas.forEach(i => {
            // place already pushed to fundingApplicationDetails must be cleared out  if sda is no longer selected
            x.places.forEach(o => {
              if (o.serviceDeliveryAreaId == i.id) {
                count++;
              }
            })
          })
        })
      }

      if (this.implementation.places?.length > 0) {
        this.placesChange(this.implementation.places);
      }

    }

    if (count == 0)
      this.fundingApplicationDetails.implementations.filter(x => { x.places = []; x.subPlaces = []; });
  }

  private setPlaces(sdas: ISDA[]): void {
    //if (sdas && sdas.length != 0) {     
      this._bidService.getSdaPlaces(sdas, this.application.id, this.programId).subscribe(res => {
        this.places = res;
        this.getPlace.emit(this.places)
        this._bidService.getSubPlaces(this.places).subscribe(res => {        
          this.subPlacesAll = res;         
          this.getSubPlace.emit(this.subPlacesAll)
        });
      });
    //}
  }

  private allDropdownsLoaded() {  // use for edit purposes if implementation has places and sub places or not

    if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas?.length > 0)
     {
      this.onSdaChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas);
     }

    if (this.places?.length > 0 && this.subPlacesAll?.length > 0) {
      let plc: IPlace[];
      let subplc: ISubPlace[];
      this.fundingApplicationDetails.implementations.map(c => { plc = c.places });
      this.implementation.places = plc;
      if (this.implementation.places?.length > 0) {
        this.placesChange(this.implementation.places);
      }

      this.fundingApplicationDetails.implementations.forEach(c => { subplc = c.subPlaces; this.implementation.subPlaces = subplc; });

      if (this.implementation.subPlaces !== undefined) {
       
        this.subPlacesChange(this.implementation.subPlaces);
      }
    }
  }


  private bidForm(status: StatusEnum) {
    this.application.status = null;
    this.application.statusId = status;
    const applicationIdOnBid = this.fundingApplicationDetails;

    if (applicationIdOnBid.id == null) {
      this._bidService.addBid(this.fundingApplicationDetails).subscribe(resp => {
        //this._menuActions[1].visible = false;
        resp;
        this.implementations = null;
        this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`);
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
       
      });
    }
    else {
      this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => {
        if (resp) {
          resp;
          this.implementation = null;
          this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`);
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
        }
      });
      
    }
    if (status == StatusEnum.PendingReview) {

      this.application.statusId = status;
      this._applicationRepo.updateApplication(this.application).subscribe();
      this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
      this._router.navigateByUrl('applications');
    };
  }
  

}




