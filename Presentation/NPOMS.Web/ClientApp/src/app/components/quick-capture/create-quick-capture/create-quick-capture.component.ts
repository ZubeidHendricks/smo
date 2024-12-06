import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { AccessStatusEnum, DepartmentEnum, DropdownTypeEnum, PermissionsEnum, RoleEnum, StaffCategoryEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IApplicationPeriod, IContactInformation, IDistrictCouncil, IFundingApplicationDetails, IGender, ILanguage, ILocalMunicipality, INpo, INpoProfile, IOrganisationType, IPosition, IProgrammeServiceDelivery, IRace, IRegion, IRegistrationStatus, ISDA, IStaffCategory, IStaffMemberProfile, ITitle, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { DepartmentService } from 'src/app/services/Department/department.service';

@Component({
  selector: 'app-create-quick-capture',
  templateUrl: './create-quick-capture.component.html',
  styleUrls: ['./create-quick-capture.component.css']
})
export class CreateQuickCaptureComponent implements OnInit {
  // ... (keep existing properties)

  // Add new constant for City of Cape Town Municipality ID
  private readonly CITY_OF_CAPE_TOWN_MUNICIPALITY_ID = 1; // Update this with the correct ID from your database
  private readonly CHS_DISTRICT_ID = 2; // Update this with the correct ID for CHS district

  onDistrictChange(event: any) {
    const selectedDistrictId = event.value?.id;
    
    // If CHS district is selected, set municipality to City of Cape Town
    if (selectedDistrictId === this.CHS_DISTRICT_ID) {
      this.selectedLocalMunicipality = this.allLocalMunicipalities.find(
        m => m.id === this.CITY_OF_CAPE_TOWN_MUNICIPALITY_ID
      );
      // Optionally disable municipality selection
      this.municipalityDisabled = true;
    } else {
      // Filter municipalities based on selected district
      this.filteredLocalMunicipalities = this.allLocalMunicipalities.filter(
        m => m.districtCouncilId === selectedDistrictId
      );
      this.municipalityDisabled = false;
    }

    // Trigger change detection
    this.updateMunicipality();
  }

  private loadMunicipalities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.LocalMunicipality, false).subscribe(
      (results) => {
        this.allLocalMunicipalities = results;
        // Store initial complete list
        this.filteredLocalMunicipalities = [...results];
        this.loadRegions();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  // Method to update municipality selection
  updateMunicipality() {
    if (this.selectedLocalMunicipality) {
      // Additional logic if needed when municipality changes
      this.updateNpo();
    }
  }

  // ... (keep rest of the existing code)
}
