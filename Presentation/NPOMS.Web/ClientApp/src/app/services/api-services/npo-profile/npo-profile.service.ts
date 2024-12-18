import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAuditorOrAffiliation, IBankDetail, INpoProfile, INpoProfileFacilityList, IProgramBankDetails, IProgramContactInformation, IProgrammeServiceDelivery, IProjectImplementation, ISDA, IServicesRendered, IStaffMemberProfile } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import { IPreviousFinancialYear, ISourceOfInformation, IAffiliatedOrganisation } from 'src/app/models/FinancialMatters';
import { IFinancialMattersExpenditure, IFinancialMattersIncome, IFinancialMattersOthers } from 'src/app/models/FinancialMatters';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class NpoProfileService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getAllNpoProfiles() {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles`;
    return this._http.get<INpoProfile[]>(url, httpOptions);
  }

  public getNpoProfileById(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/npoProfileId/${npoProfileId}`;
    return this._http.get<INpoProfile>(url, httpOptions);
  }

  public getProgrammeContactsById(programmeId: number,npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/programme/contact/programmeId/${programmeId}/npoProfileId/${npoProfileId}`;
    return this._http.get<IProgramContactInformation[]>(url, httpOptions);
  }

  public getProgrammeBankDetailsById(programmeId: number,npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/programme/bank/programmeId/${programmeId}/npoProfileId/${npoProfileId}`;
    return this._http.get<IProgramBankDetails[]>(url, httpOptions);
  }
  
  public getProgrammeBankDetails(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/programme/bank/npoProfileId/${npoProfileId}`;
    return this._http.get<IProgramBankDetails[]>(url, httpOptions);
  }

  public getProgrammeMasterDeliveryDetailsById(programmeId: number,npoId: number) {
    const url = `${this._envUrl.urlAddress}/api/programme/masterdelivery/programmeId/${programmeId}/npoProfileId/${npoId}`;
    return this._http.get<ISDA[]>(url, httpOptions);
  }

  public getProgrammeDeliveryDetailsById(programmeId: number,npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/programme/delivery/programmeId/${programmeId}/npoProfileId/${npoProfileId}`;
    return this._http.get<IProgrammeServiceDelivery[]>(url, httpOptions);
  }


  public getProgrammeDeliveryDetails(selectedApplicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/programme/delivery/selectedApplicationId/${selectedApplicationId}`;
    return this._http.get<IProgrammeServiceDelivery[]>(url, httpOptions);
  }

  public getProgrammeDeliveryDetailsQC(npoId: number) {
    const url = `${this._envUrl.urlAddress}/api/programme/deliveryDetailQC/npoId/${npoId}`;
    return this._http.get<IProgrammeServiceDelivery[]>(url, httpOptions);
  }

  public getProgrammeDeliveryArea() {
    const url = `${this._envUrl.urlAddress}/api/programme/delivery`;
    return this._http.get<IProgrammeServiceDelivery[]>(url, httpOptions);
  }

  public getProgrammeContacts(npoProfileId: number, source: string) {
    const url = `${this._envUrl.urlAddress}/api/programme/contact/npoProfileId/${npoProfileId}`;
    return this._http.get<IProgramContactInformation[]>(url, httpOptions);
  }

  public createProgrammeContact(npoProfileId: number,programContactInformation: IProgramContactInformation) {
    const url = `${this._envUrl.urlAddress}/api/programme/create-contact/${npoProfileId}`;
    return this._http.post<IProgramContactInformation>(url, programContactInformation, httpOptions);
  }

  public createProgrammeBankDetails(npoProfileId: number,programBankDetails: IProgramBankDetails) {
    const url = `${this._envUrl.urlAddress}/api/programme/create-bank/${npoProfileId}`;
    return this._http.post<IProgramBankDetails>(url,programBankDetails, httpOptions);
  }

  public updateProgrammeContact(npoProfileId: number,programContactInformation: IProgramContactInformation) {
    const url = `${this._envUrl.urlAddress}/api/programme/update-contact/${npoProfileId}`;
    return this._http.put<IProgramContactInformation>(url,programContactInformation, httpOptions);
  }

  public updateProgrammeBankDetails(npoProfileId: number,programBankDetails: IProgramBankDetails) {
    const url = `${this._envUrl.urlAddress}/api/programme/update-bank/${npoProfileId}`;
    return this._http.put<IProgramBankDetails>(url,programBankDetails, httpOptions);
  }

  public updateProgrammeDeliveryDetails(npoProfileId: number,programBankDetails: IProgrammeServiceDelivery) {
    const url = `${this._envUrl.urlAddress}/api/programme/update-delivery/${npoProfileId}`;
    return this._http.put<IProgrammeServiceDelivery>(url,programBankDetails, httpOptions);
  }

  public updateProgrammeDeliveryServiceSelection(id: number, selection: boolean) {
    const url = `${this._envUrl.urlAddress}/api/programme/update-DeliveryServiceAreaSelection/id/${id}/selection/${selection}`;
    return this._http.put<IProgrammeServiceDelivery>(url, httpOptions);
  }

  public updateProgrammeBankSelection(id: number, selection: boolean, npoId: number) {
    const url = `${this._envUrl.urlAddress}/api/programme/update-BankSelection/id/${id}/selection/${selection}/npoId/${npoId}`;
    return this._http.put<IProgrammeServiceDelivery>(url, httpOptions);
  }

  public createProgrammeDeliveryDetails(npoProfileId: number,programBankDetails: IProgrammeServiceDelivery) {
    const url = `${this._envUrl.urlAddress}/api/programme/create-delivery/${npoProfileId}`;
    return this._http.post<IProgrammeServiceDelivery>(url,programBankDetails, httpOptions);
  }



  public getNpoProfileByNpoId(npoId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/npoId/${npoId}`;
    return this._http.get<INpoProfile>(url, httpOptions);
  }

  public createNpoProfile(npoProfile: INpoProfile) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles`;
    return this._http.post<INpoProfile>(url, npoProfile, httpOptions);
  }

  public updateNpoProfile(npoProfile: INpoProfile) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles`;
    return this._http.put<INpoProfile>(url, npoProfile, httpOptions);
  }

  public approveProfile(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/approve/${npoProfileId}`;
    return this._http.post<INpoProfile>(url, npoProfileId, httpOptions);
  }

  public rejectProfile(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/reject/${npoProfileId}`;
    return this._http.post<INpoProfile>(url, npoProfileId, httpOptions);
  }

  public submitProfile(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/submit/${npoProfileId}`;
    return this._http.post<INpoProfile>(url, npoProfileId, httpOptions);
  }


  public getFacilitiesByNpoProfileId(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/facilities/npoProfileId/${npoProfileId}`;
    return this._http.get<INpoProfileFacilityList[]>(url, httpOptions);
  }

  public getFacilitiesByNpoId(npoId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/npoFacilities/npoId/${npoId}`;
    return this._http.get<INpoProfileFacilityList[]>(url, httpOptions);
  }

  public createFacilityMapping(mapping: INpoProfileFacilityList) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/facilities`;
    return this._http.post<INpoProfileFacilityList>(url, mapping, httpOptions);
  }

  public updateFacilityMapping(mapping: INpoProfileFacilityList) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/facilities`;
    return this._http.put<INpoProfileFacilityList>(url, mapping, httpOptions);
  }

  public deleteFacilityMapping(mapping: INpoProfileFacilityList) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/facilities`;
    return this._http.put<INpoProfileFacilityList>(url, mapping, httpOptions);
  }

  public getServicesRenderedByNpoProfileId(npoProfileId: number,source: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/services-rendered/${source}/npoProfileId/${npoProfileId}`;
    return this._http.get<IServicesRendered[]>(url, httpOptions);
  }

  public createServicesRendered(servicesRendered: IServicesRendered) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/services-rendered`;
    return this._http.post<IServicesRendered>(url, servicesRendered, httpOptions);
  }

  public updateServicesRendered(servicesRendered: IServicesRendered) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/services-rendered`;
    return this._http.put<IServicesRendered>(url, servicesRendered, httpOptions);
  }

  public deleteServicesRendered(servicesRendered: IServicesRendered) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/services-rendered`;
    return this._http.put<IServicesRendered>(url, servicesRendered, httpOptions);
  }

  public getProjImplByNpoProfileId(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/projImpl/npoProfileId/${npoProfileId}`;
    return this._http.get<IProjectImplementation[]>(url, httpOptions);
  }

  public getProjImplByfundingApplicationDetailId(appDetailId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/projImpl/appDetailId/${appDetailId}`;
    return this._http.get<IProjectImplementation[]>(url, httpOptions);
  }

  public deleteProjImpl(id: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/deleteProjImplById/id/${id}`;
    return this._http.delete<IProjectImplementation[]>(url, httpOptions);
  }

  public updateProjImpl(updateProjImpl: IProjectImplementation) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/UpdateProjImpl`;
    return this._http.put<IProjectImplementation[]>(url, updateProjImpl, httpOptions);
  }

  public getFinancialMattersExpenditureByNpoProfileId(npoProfileId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/getFinancialMattersExpenditureByNpoProfileId/npoProfileId/${npoProfileId}`;
    return this._http.get<IFinancialMattersExpenditure[]>(url, httpOptions);
  }

  public createFinancialMattersExpenditure(fundingApplicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/financial-matters-expenditure/fundingApplicationId/${fundingApplicationId}`;
    return this._http.post<any>(url, fundingApplicationId, httpOptions);
  }

  public updateFinancialMattersExpenditure(financialMattersExpenditure: IFinancialMattersExpenditure, applicationId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/updateFinancialMattersExpenditure/applicationId/${applicationId}`;
    return this._http.put<IFinancialMattersExpenditure>(url, financialMattersExpenditure, httpOptions);
  }

  public getFinancialMattersOthersByNpoProfileId(npoProfileId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/getFinancialMattersOthersByNpoProfileId/npoProfileId/${npoProfileId}`;
    return this._http.get<IFinancialMattersOthers[]>(url, httpOptions);
  }

  public createFinancialMattersOther(fundingApplicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/financial-matters-other/fundingApplicationId/${fundingApplicationId}`;
    return this._http.post<any>(url, fundingApplicationId, httpOptions);
  }

  public updateFinancialMattersOthers(financialMattersOthers: IFinancialMattersOthers, applicationId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/updateFinancialMattersOthers/applicationId/${applicationId}`;
    return this._http.put<IFinancialMattersOthers>(url, financialMattersOthers, httpOptions);
  }

  public deleteFinancialMattersOthersById(id: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/deleteOthersById/id/${id}`;
    return this._http.put<IFinancialMattersOthers>(url, httpOptions);
  }

  public getPreviousYearDataById(npoProfileId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/getPreviousYearFinanceByNpoProfileId/npoProfileId/${npoProfileId}`;
    return this._http.get<IPreviousFinancialYear[]>(url, httpOptions);
  }

  public createPreviousYearData(fundingApplicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/previous-financial-year/fundingApplicationId/${fundingApplicationId}`;
    return this._http.post<any>(url, fundingApplicationId, httpOptions);
  }

  public UpdatePreviousYearData(previousYearData: IPreviousFinancialYear, npoProfileId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/updatePreviousYearFinance/npoProfileId/${npoProfileId}`;
    return this._http.put<IPreviousFinancialYear>(url, previousYearData, httpOptions);
  }

  public deleteFinancialMattersExpenditureById(id: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/deleteExpenditureById/id/${id}`;
    return this._http.put<IFinancialMattersExpenditure>(url, httpOptions);
  }

  public deletePreviousYearDataById(id: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/deleteById/id/${id}`;
    return this._http.put<IPreviousFinancialYear[]>(url, httpOptions);
  }

  public getAuditorOrAffiliations(entityId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/auditor-affiliation/entityId/${entityId}`;
    return this._http.get<IAuditorOrAffiliation[]>(url, httpOptions);
  }

  public createAuditorOrAffiliation(model: IAuditorOrAffiliation) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/auditor-affiliation`;
    return this._http.post<IAuditorOrAffiliation>(url, model, httpOptions);
  }

  public updateAuditorOrAffiliation(model: IAuditorOrAffiliation) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/auditor-affiliation`;
    return this._http.put<IAuditorOrAffiliation>(url, model, httpOptions);
  }

  public getStaffMemberProfilesByNpoProfileId(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/staff-member-profile/npoProfileId/${npoProfileId}`;
    return this._http.get<IStaffMemberProfile[]>(url, httpOptions);
  }

  public updateStaffMemberProfile(staffMemberProfile: IStaffMemberProfile) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/staff-member-profile`;
    return this._http.put<IStaffMemberProfile>(url, staffMemberProfile, httpOptions);
  }
  public updateSourceOfInformation(sourceOfInformation: ISourceOfInformation, npoProfileId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/updateSourceOfInformation/npoProfileId/${npoProfileId}`;
    return this._http.post<ISourceOfInformation>(url, sourceOfInformation, httpOptions);
  }

  public getSourceOfInformationById(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/getSourceOfInformationById/npoProfileId/${npoProfileId}`;
    return this._http.get<ISourceOfInformation[]>(url, httpOptions);
  }

  public getAffiliatedOrganisationById(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/getAffiliatedOrganisationById/npoProfileId/${npoProfileId}`;
    return this._http.get<IAffiliatedOrganisation[]>(url, httpOptions);
  }

  public updateAffiliatedOrganisationData(affiliatedOrganisationData: IAffiliatedOrganisation, npoProfileId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/updateAffiliatedOrganisationData/npoProfileId/${npoProfileId}`;
    return this._http.put<IAffiliatedOrganisation[]>(url, affiliatedOrganisationData, httpOptions);
  }

  public getFinancialMattersIncomeByNpoProfileId(npoProfileId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/getFinancialMattersIncomeByNpoProfileId/npoProfileId/${npoProfileId}`;
    return this._http.get<IFinancialMattersIncome[]>(url, httpOptions);
  }

  public createFinancialMattersIncome(fundingApplicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/financial-matters-income/fundingApplicationId/${fundingApplicationId}`;
    return this._http.post<any>(url, fundingApplicationId, httpOptions);
  }

  public updateFinancialMattersIncome(financialMattersIncome: IFinancialMattersIncome, applicationId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/updateFinancialMattersIncome/applicationId/${applicationId}`;
    return this._http.put<IFinancialMattersIncome>(url, financialMattersIncome, httpOptions);
  }

  public deleteFinancialMattersIncomeById(id: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/deleteIncomeById/id/${id}`;
    return this._http.put<IFinancialMattersIncome>(url, httpOptions);
  }

  public getBankDetailByNpoProfileId(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/bank-detail/npoProfileId/${npoProfileId}`;
    return this._http.get<IBankDetail[]>(url, httpOptions);
  }

  public createBankDetail(bankDetail: IBankDetail) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/createBankDetail`;
    return this._http.post<IBankDetail>(url, bankDetail, httpOptions);
  }

  public updateBankDetail(bankDetail: IBankDetail) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/updateBankDetail`;
    return this._http.put<IBankDetail>(url, bankDetail, httpOptions);
  }

  public deleteBankDetail(id: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/deleteBankDetailById/id/${id}`;
    return this._http.put<IBankDetail>(url, httpOptions);
  }
}
