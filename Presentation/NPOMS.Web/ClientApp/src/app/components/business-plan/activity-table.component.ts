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

  // Constants
  private readonly CITY_OF_CAPE_TOWN_ID = 1; // Update with actual ID
  private readonly CHS_DISTRICT_ID = 2; // Update with actual ID

  constructor(private dropdownService: DropdownService) {}

  ngOnInit() {
    this.loadDistricts();
    this.loadMunicipalities();
  }

  loadDistricts() {
    // Load districts from dropdown service
    this.dropdownService.getEntities('District', false).subscribe(
      data => this.districts = data,
      error => console.error('Error loading districts:', error)
    );
  }

  loadMunicipalities() {
    // Load all municipalities
    this.dropdownService.getEntities('Municipality', false).subscribe(
      data => {
        this.municipalities = data;
        this.filteredMunicipalities = [...data];
      },
      error => console.error('Error loading municipalities:', error)
    );
  }

  onDistrictChange(event: any) {
    const selectedDistrictId = event.value?.id;
    
    if (selectedDistrictId === this.CHS_DISTRICT_ID) {
      // If CHS is selected, set to City of Cape Town
      this.selectedMunicipality = this.municipalities.find(
        m => m.id === this.CITY_OF_CAPE_TOWN_ID
      );
      this.municipalityDisabled = true;
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