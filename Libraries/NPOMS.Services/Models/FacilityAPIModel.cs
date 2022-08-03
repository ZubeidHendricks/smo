using System.Collections.Generic;

namespace NPOMS.Services.Models
{
	public class FacilityAPIModel
	{
		public string name { get; set; }
		public string code { get; set; }
		public string datein { get; set; }
		public string dateout { get; set; }
		public string status_code { get; set; }
		public string status { get; set; }
		public string classification_id { get; set; }
		public string classification { get; set; }
		public string category_id { get; set; }
		public string category { get; set; }
		public string short_name { get; set; }
		public string latitude { get; set; }
		public string longitude { get; set; }
		public string telno { get; set; }
		public string email { get; set; }
		public string contact_name { get; set; }
		public string authority_id { get; set; }
		public string authority { get; set; }
		public string associated_facility { get; set; }
		public string associated_facility_code { get; set; }
		public string urban_code { get; set; }
		public string urban { get; set; }
		public string health_facility_short_code { get; set; }
		public string date_modified { get; set; }
		public string emis { get; set; }
		public string dhis_uid { get; set; }
		public string quintile_id { get; set; }
		public string quintile_name { get; set; }
		public string nat_code { get; set; }
		public string tier { get; set; }
		public string po_box_or_private_bag { get; set; }
		public string postal_suburb_or_town { get; set; }
		public string postal_code { get; set; }
		public string address_type { get; set; }
		public string street_number { get; set; }
		public string street_name { get; set; }
		public string district_id { get; set; }
		public string district { get; set; }
		public string district_status { get; set; }
		public string sub_district_id { get; set; }
		public string sub_district { get; set; }
		public string suburb { get; set; }
		public string town { get; set; }
		public string province { get; set; }
		public string street_postal_code { get; set; }
		public string recordstatus_0 { get; set; }
		public string throughput_report_required { get; set; }
		public string substruct { get; set; }
		public string metro_rural { get; set; }
		public string open_days { get; set; }
		public string open_tim { get; set; }
	}

	public class FacilityAPIWrapperModel
	{
		public string name { get; set; }
		public List<FacilityAPIModel> elements { get; set; }
	}
}
