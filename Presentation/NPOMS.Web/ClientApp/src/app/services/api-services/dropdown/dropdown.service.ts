import { PropertySubType } from 'src/app/models/PropertySubType';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DropdownTypeEnum } from 'src/app/models/enums';
import { IAccessStatus, IAccountType, IActivityList, IActivityType, IAllocationType, IApplicationType, IBank, IBranch, ICompliantCycleRule, IDenodoFacilityWrapper, IDepartment, IDirectorate, IDistrictCouncil, IDocumentType, IFacilityClass, IFacilityDistrict, IFacilityList, IFacilitySubDistrict, IFacilityType, IFinancialYear, IFrequency, IFrequencyPeriod, ILocalMunicipality, IOrganisationType, IPosition, IProgramme, IProvisionType, IRecipientType, IRegion, IResourceList, IResourceType, IRole, IServiceDeliveryArea, IServiceType, IStatus, ISubProgramme, ISubProgrammeType, ITitle, ITrainingMaterial, IUtility } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import { PropertyType } from 'src/app/models/PropertyType';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class DropdownService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getEntities(dropdownType: DropdownTypeEnum, returnInactive: boolean) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/dropdownTypeEnum/${dropdownType}/returnInactive/${returnInactive}`;
    var data;

    switch (dropdownType) {
      case DropdownTypeEnum.Roles:
        data = this._http.get<IRole[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Departments:
        data = this._http.get<IDepartment[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.OrganisationTypes:
        data = this._http.get<IOrganisationType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Titles:
        data = this._http.get<ITitle[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Positions:
        data = this._http.get<IPosition[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.AccessStatuses:
        data = this._http.get<IAccessStatus[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Programmes:
        data = this._http.get<IProgramme[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.SubProgramme:
        data = this._http.get<ISubProgramme[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.FinancialYears:
        data = this._http.get<IFinancialYear[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.ApplicationTypes:
        data = this._http.get<IApplicationType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.RecipientTypes:
        data = this._http.get<IRecipientType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.ActivityTypes:
        data = this._http.get<IActivityType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.ResourceTypes:
        data = this._http.get<IResourceType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.ServiceTypes:
        data = this._http.get<IServiceType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.AllocationTypes:
        data = this._http.get<IAllocationType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.FacilityDistricts:
        data = this._http.get<IFacilityDistrict[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.FacilitySubDistricts:
        data = this._http.get<IFacilitySubDistrict[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.FacilityClasses:
        data = this._http.get<IFacilityClass[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.FacilityList:
        data = this._http.get<IFacilityList[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.DocumentTypes:
        data = this._http.get<IDocumentType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.FacilityTypes:
        data = this._http.get<IFacilityType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Statuses:
        data = this._http.get<IStatus[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.ActivityList:
        data = this._http.get<IActivityList[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.ResourceList:
        data = this._http.get<IResourceList[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.ProvisionTypes:
        data = this._http.get<IProvisionType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Utilities:
        data = this._http.get<IUtility[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.TrainingMaterial:
        data = this._http.get<ITrainingMaterial[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Frequencies:
        data = this._http.get<IFrequency[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.FrequencyPeriods:
        data = this._http.get<IFrequencyPeriod[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.SubProgrammeTypes:
        data = this._http.get<ISubProgrammeType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Directorates:
        data = this._http.get<IDirectorate[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Banks:
        data = this._http.get<IBank[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Branches:
        data = this._http.get<IBranch[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.AccountTypes:
        data = this._http.get<IAccountType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.CompliantCycleRules:
        data = this._http.get<ICompliantCycleRule[]>(url, httpOptions);
        break;

      case DropdownTypeEnum.DistrictCouncil:
          data = this._http.get<IDistrictCouncil[]>(url, httpOptions);
          break;
      case DropdownTypeEnum.LocalMunicipality:
          data = this._http.get<ILocalMunicipality[]>(url, httpOptions);
        break;

      case DropdownTypeEnum.Region:
        data = this._http.get<IRegion[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.ServiceDeliveryArea:
        data = this._http.get<IServiceDeliveryArea[]>(url, httpOptions);
        break; 

        case DropdownTypeEnum.PropertyType:
          data = this._http.get<PropertyType[]>(url, httpOptions);
          break;
        case DropdownTypeEnum.PropertySubType:
          data = this._http.get<PropertySubType[]>(url, httpOptions);
          break;         
    }

    return data;
  }

  public createEntity(data: any, dropdownType: DropdownTypeEnum) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/dropdownTypeEnum/${dropdownType}`;
    var entity;

    switch (dropdownType) {
      case DropdownTypeEnum.Roles:
        entity = this._http.post<IRole>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Departments:
        entity = this._http.post<IDepartment>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.OrganisationTypes:
        entity = this._http.post<IOrganisationType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Titles:
        entity = this._http.post<ITitle>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Positions:
        entity = this._http.post<IPosition>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.AccessStatuses:
        entity = this._http.post<IAccessStatus>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Programmes:
        entity = this._http.post<IProgramme>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.SubProgramme:
        entity = this._http.post<ISubProgramme>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FinancialYears:
        entity = this._http.post<IFinancialYear>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ApplicationTypes:
        entity = this._http.post<IApplicationType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.RecipientTypes:
        entity = this._http.post<IRecipientType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ActivityTypes:
        entity = this._http.post<IActivityType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ResourceTypes:
        entity = this._http.post<IResourceType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ServiceTypes:
        entity = this._http.post<IServiceType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.AllocationTypes:
        entity = this._http.post<IAllocationType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FacilityDistricts:
        entity = this._http.post<IFacilityDistrict>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FacilitySubDistricts:
        entity = this._http.post<IFacilitySubDistrict>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FacilityClasses:
        entity = this._http.post<IFacilityClass>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.DocumentTypes:
        entity = this._http.post<IDocumentType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FacilityTypes:
        entity = this._http.post<IFacilityType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Statuses:
        entity = this._http.post<IStatus>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ProvisionTypes:
        entity = this._http.post<IProvisionType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Utilities:
        entity = this._http.post<IUtility>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Frequencies:
        entity = this._http.post<IFrequency>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FrequencyPeriods:
        entity = this._http.post<IFrequencyPeriod>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.SubProgrammeTypes:
        entity = this._http.post<ISubProgrammeType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Directorates:
        entity = this._http.post<IDirectorate>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Banks:
        entity = this._http.post<IBank>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Branches:
        entity = this._http.post<IBranch>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.AccountTypes:
        entity = this._http.post<IAccountType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.CompliantCycleRules:
        entity = this._http.post<ICompliantCycleRule>(url, data, httpOptions);
        break;
    }

    return entity;
  }

  public updateEntity(data: any, dropdownType: DropdownTypeEnum) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/dropdownTypeEnum/${dropdownType}`;
    var entity;

    switch (dropdownType) {
      case DropdownTypeEnum.Roles:
        entity = this._http.put<IRole>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Departments:
        entity = this._http.put<IDepartment>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.OrganisationTypes:
        entity = this._http.put<IOrganisationType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Titles:
        entity = this._http.put<ITitle>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Positions:
        entity = this._http.put<IPosition>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.AccessStatuses:
        entity = this._http.put<IAccessStatus>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Programmes:
        entity = this._http.put<IProgramme>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.SubProgramme:
        entity = this._http.put<ISubProgramme>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FinancialYears:
        entity = this._http.put<IFinancialYear>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ApplicationTypes:
        entity = this._http.put<IApplicationType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.RecipientTypes:
        entity = this._http.put<IRecipientType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ActivityTypes:
        entity = this._http.put<IActivityType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ResourceTypes:
        entity = this._http.put<IResourceType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ServiceTypes:
        entity = this._http.put<IServiceType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.AllocationTypes:
        entity = this._http.put<IAllocationType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FacilityDistricts:
        entity = this._http.put<IFacilityDistrict>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FacilitySubDistricts:
        entity = this._http.put<IFacilitySubDistrict>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FacilityClasses:
        entity = this._http.put<IFacilityClass>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.DocumentTypes:
        entity = this._http.put<IDocumentType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FacilityTypes:
        entity = this._http.put<IFacilityType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Statuses:
        entity = this._http.put<IStatus>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.ProvisionTypes:
        entity = this._http.put<IProvisionType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Utilities:
        entity = this._http.put<IUtility>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Frequencies:
        entity = this._http.put<IFrequency>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.FrequencyPeriods:
        entity = this._http.put<IFrequencyPeriod>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.SubProgrammeTypes:
        entity = this._http.put<ISubProgrammeType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Directorates:
        entity = this._http.put<IDirectorate>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Banks:
        entity = this._http.put<IBank>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.Branches:
        entity = this._http.put<IBranch>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.AccountTypes:
        entity = this._http.put<IAccountType>(url, data, httpOptions);
        break;
      case DropdownTypeEnum.CompliantCycleRules:
        entity = this._http.put<ICompliantCycleRule>(url, data, httpOptions);
        break;
    }

    return entity;
  }

  public getFacilityByName(searchText: string) {
    const url = `${this._envUrl.urlAddress}/api/denodo?facilityName=${searchText}&pageSize=25&status=active`;
    return this._http.get<IDenodoFacilityWrapper>(url, httpOptions);
  }

  public getFacilityList(facilityList: IFacilityList) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/facility/facilityTypeId/${facilityList.facilityTypeId}/facilitySubDistrictId/${facilityList.facilitySubDistrictId}/facilityClassId/${facilityList.facilityClassId}/name/${facilityList.name}`;
    return this._http.get<IFacilityList>(url, httpOptions);
  }

  public createFacilityList(facilityList: IFacilityList) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/facility`;
    return this._http.post<IFacilityList>(url, facilityList, httpOptions);
  }

  public updateFacilityList(facilityList: IFacilityList) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/facility`;
    return this._http.put<IFacilityList>(url, facilityList, httpOptions);
  }

  public getActivityByName(searchText: string) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/activity/name/${searchText}`;
    return this._http.get<IActivityList[]>(url, httpOptions);
  }

  public createActivityList(activityList: IActivityList) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/activity`;
    return this._http.post<IActivityList>(url, activityList, httpOptions);
  }

  public createResourceList(resourceList: IResourceList) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/resource`;
    return this._http.post<IResourceList>(url, resourceList, httpOptions);
  }

  public getFromCurrentFinYear() {
    const url = `${this._envUrl.urlAddress}/api/dropdown/financial-year`;
    return this._http.get<IFinancialYear[]>(url, httpOptions);
  }

  public getEntitiesByEntityId(dropdownType: DropdownTypeEnum, entityId: number) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/dropdownTypeEnum/${dropdownType}/entityId/${entityId}`;
    var data;

    switch (dropdownType) {
      case DropdownTypeEnum.SubProgramme:
        data = this._http.get<ISubProgramme[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.SubProgrammeTypes:
        data = this._http.get<ISubProgrammeType[]>(url, httpOptions);
        break;
      case DropdownTypeEnum.Branches:
        data = this._http.get<IBranch[]>(url, httpOptions);
        break;
    }

    return data;
  }

  public getBranchById(branchId: number) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/branch/branchId/${branchId}`;
    return this._http.get<IBranch>(url, httpOptions);
  }

  public getAccountTypeById(accountTypeId: number) {
    const url = `${this._envUrl.urlAddress}/api/dropdown/account-type/accountTypeId/${accountTypeId}`;
    return this._http.get<IAccountType>(url, httpOptions);
  }
}
