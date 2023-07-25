import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as moment from 'moment';
import { ConfirmationService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { StatusEnum } from 'src/app/models/enums';
import { IApplication, IFundingApplicationDetails, IPlace, IProjectImplementation, ISubPlace, } from 'src/app/models/interfaces';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';

@Component({
  selector: 'app-project-implementation',
  templateUrl: './project-implementation.component.html',
  styleUrls: ['./project-implementation.component.css']
})
export class ProjectImplementationComponent implements OnInit, OnDestroy {

  canEdit: boolean;
  @Input() activeStep: number;
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Input() application: IApplication;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() implementations: IProjectImplementation[];
  @Output() implementationsChange = new EventEmitter();

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
  selectedSubPlaces: ISubPlace[];
  selectedPlaces: IPlace[];
  private subscriptions: Subscription[] = [];

  projectImplementations: IProjectImplementation[];
  constructor(
    private _confirmationService: ConfirmationService,
    private _npoProfile: NpoProfileService,
    private _activeRouter: ActivatedRoute,
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
      console.log('ng OnInit Id', params.get('id'));
      console.log('this.selectedApplicationId ', this.selectedApplicationId);
    });

    this.cols = [
      {header: 'Description', width: '45%' },
      {  header: 'Beneficiaries', width: '25%' },
      {header: 'Budget', width: '15%' },
      {  header: 'Actions', width: '10%' }
    ];
    this.setYearRange();

    console.log('Places coming from Edit component on ProjImpl', this.places);
    console.log('Places coming from ProjectImpsubPlacesAll', this.allsubPlaces);
    this.allDropdownsLoaded();
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

  editProjImpl(data: IProjectImplementation) {
    debugger;
    this.selectedPlaces = [];
    this.selectedSubPlaces = [];
    console.log('data', data);
    this.newImplementation = false;
    this.implementation = this.cloneImplementation(data);
    // this.implementation.timeframe = [];
    //this.implementation.timeframe.push(new Date(event.data.timeframeFrom));
    // this.implementation.timeframe.push(new Date(event.data.timeframeTo));
    this.implementation.places = this.implementation.places;
    this.implementation.subPlaces = this.implementation.subPlaces;
    console.log('bit after', this.fundingApplicationDetails)
    this.placesChange(this.implementation.places);
    this.subPlacesChange(this.implementation.subPlaces);
    //if(this.application.statusId == 3 || 22||23){ this.displayDialogImpl = false;}
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
  }

  private GetProjImpl() {
    this._npoProfile.getProjImplByNpoProfileId(Number(this.selectedApplicationId)).subscribe(
      (results) => {
        this.projectImplementations = results;
        this.updateProjImplementations();
      },
      (err) => {
        //
      }
    );
  }

  deleteProjImpl(projImpl) {
    debugger;
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._npoProfile.deleteProjImpl(projImpl).subscribe(
          (resp) => {
            this.GetProjImpl();
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

    this.activeStep = this.activeStep + 1;
    this.activeStepChange.emit(this.activeStep);
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
    if ( //(!this.implementation.timeframe ||this.implementation.timeframe.length <2)||
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
    this.implementation = null;
    console.log('bit after', this.fundingApplicationDetails)
  }


  onRowSelect(event) {
    debugger;
    this.selectedPlaces = [];
    this.selectedSubPlaces = [];
    console.log('data', event.data);
    this.newImplementation = false;
    this.implementation = this.cloneImplementation(event.data);
    // this.implementation.timeframe = [];
    //this.implementation.timeframe.push(new Date(event.data.timeframeFrom));
    // this.implementation.timeframe.push(new Date(event.data.timeframeTo));
    this.implementation.places = this.implementation.places;
    this.implementation.subPlaces = this.implementation.subPlaces;
    console.log('bit after', this.fundingApplicationDetails)
    this.placesChange(this.implementation.places);
    this.subPlacesChange(this.implementation.subPlaces);
    //if(this.application.statusId == 3 || 22||23){ this.displayDialogImpl = false;}
    this.displayDialogImpl = true;
  }

  // updateTimeframe(value: any) {

  //   if (value[0] !== null && value[1] !== null) {
  //     this.implementation.timeframeFrom = moment(value[0]).format('L');
  //     this.implementation.timeframeTo = moment(value[1]).format('L');
  //   }
  // }


  cloneImplementation(c: IProjectImplementation): IProjectImplementation {
    debugger;
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
      for (var i = 0; i < this.allsubPlaces.length; i++) {
        if (this.selectedPlaces.filter(r => r.id === this.allsubPlaces[i].placeId).length != 0) {
          this.subPlaces.push(this.allsubPlaces[i]);

        }
      }
    }
  }

  subPlacesChange(sub: ISubPlace[]) {     // create dropdown with data for subPlaces
    this.selectedSubPlaces = [];
    sub.forEach(item => {
      this.selectedSubPlaces = this.selectedSubPlaces.concat(this.allsubPlaces.find(x => x.id == item.id))
    });
    this.implementation.subPlaces = this.selectedSubPlaces;
  }

  private allDropdownsLoaded() {  // use for edit purposes if implementation has places and sub places or not

    if (this.places?.length > 0 && this.allsubPlaces?.length > 0) {
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
}




