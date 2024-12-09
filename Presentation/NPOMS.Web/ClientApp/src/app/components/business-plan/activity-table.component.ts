import { Component, OnInit } from '@angular/core';
import { DropdownService } from '../../services/dropdown/dropdown.service';

@Component({
  selector: 'app-activity-table',
  templateUrl: './activity-table.component.html',
  styleUrls: ['./activity-table.component.css']
})
export class ActivityTableComponent implements OnInit {
  districts: any[] = [];
  municipalities: any[] = [];
  filteredMunicipalities: any[] = [];
  selectedDistrict: any;
  selectedMunicipality: any;
  municipalityDisabled: boolean = false;

  // Updated IDs - replace these with actual values from your database
  private readonly CITY_OF_CAPE_TOWN_ID = 1;  
  private readonly CHS_DISTRICT_ID = 2;  

  constructor(private dropdownService: DropdownService) {}

  ngOnInit() {
    this.loadDistricts();
    this.loadMunicipalities();
  }

  loadDistricts() {
    // Load districts from dropdown service
    this.dropdownService.getEntities('District', false).subscribe(
      data => {
        this.districts = data;
        // If CHS is preselected, handle it
        if (this.selectedDistrict?.id === this.CHS_DISTRICT_ID) {
          this.handleCHSDistrictSelection();
        }
      },
      error => console.error('Error loading districts:', error)
    );
  }

  loadMunicipalities() {
    // Load all municipalities
    this.dropdownService.getEntities('Municipality', false).subscribe(
      data => {
        this.municipalities = data;
        this.filteredMunicipalities = [...data];
        // If CHS is selected, find and set Cape Town
        if (this.selectedDistrict?.id === this.CHS_DISTRICT_ID) {
          this.handleCHSDistrictSelection();
        }
      },
      error => console.error('Error loading municipalities:', error)
    );
  }

  handleCHSDistrictSelection() {
    const capeWown = this.municipalities.find(m => m.id === this.CITY_OF_CAPE_TOWN_ID);
    if (capeWown) {
      this.selectedMunicipality = capeWown;
      this.municipalityDisabled = true;
    }
  }

  onDistrictChange(event: any) {
    const selectedDistrictId = event.value?.id;
    
    if (selectedDistrictId === this.CHS_DISTRICT_ID) {
      this.handleCHSDistrictSelection();
    } else {
      // Filter municipalities based on district
      this.filteredMunicipalities = this.municipalities.filter(
        m => m.districtId === selectedDistrictId
      );
      this.municipalityDisabled = false;
      this.selectedMunicipality = null;
    }
  }
}