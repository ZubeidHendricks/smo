using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class FacilitySubDistrictConfiguration : IEntityTypeConfiguration<FacilitySubDistrict>
	{
		public void Configure(EntityTypeBuilder<FacilitySubDistrict> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new FacilitySubDistrict
				{
					Id = 1,
					FacilityDistrictId = 1,
					Name = "Breede Valley Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 2,
					FacilityDistrictId = 1,
					Name = "Stellenbosch Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 3,
					FacilityDistrictId = 1,
					Name = "Drakenstein Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 4,
					FacilityDistrictId = 1,
					Name = "Witzenberg Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 5,
					FacilityDistrictId = 1,
					Name = "Langeberg Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 6,
					FacilityDistrictId = 2,
					Name = "Khayelitsha Health sub-District"
				},
				new FacilitySubDistrict
				{
					Id = 7,
					FacilityDistrictId = 2,
					Name = "Cape Town Eastern Health sub-District"
				},
				new FacilitySubDistrict
				{
					Id = 8,
					FacilityDistrictId = 2,
					Name = "Cape Town Southern Health sub-District"
				},
				new FacilitySubDistrict
				{
					Id = 9,
					FacilityDistrictId = 2,
					Name = "Cape Town Northern Health sub-District"
				},
				new FacilitySubDistrict
				{
					Id = 10,
					FacilityDistrictId = 2,
					Name = "Klipfontein Health sub-District"
				},
				new FacilitySubDistrict
				{
					Id = 11,
					FacilityDistrictId = 2,
					Name = "Cape Town Western Health sub-District"
				},
				new FacilitySubDistrict
				{
					Id = 12,
					FacilityDistrictId = 2,
					Name = "Tygerberg Health sub-District"
				},
				new FacilitySubDistrict
				{
					Id = 13,
					FacilityDistrictId = 2,
					Name = "Mitchells Plain Health sub-District"
				},
				new FacilitySubDistrict
				{
					Id = 14,
					FacilityDistrictId = 3,
					Name = "Matzikama Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 15,
					FacilityDistrictId = 3,
					Name = "Saldanha Bay Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 16,
					FacilityDistrictId = 3,
					Name = "Cederberg Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 17,
					FacilityDistrictId = 3,
					Name = "Bergrivier Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 18,
					FacilityDistrictId = 3,
					Name = "Swartland Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 19,
					FacilityDistrictId = 4,
					Name = "Overstrand Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 20,
					FacilityDistrictId = 4,
					Name = "Theewaterskloof Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 21,
					FacilityDistrictId = 4,
					Name = "Cape Agulhas Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 22,
					FacilityDistrictId = 4,
					Name = "Swellendam Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 23,
					FacilityDistrictId = 5,
					Name = "Bitou Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 24,
					FacilityDistrictId = 5,
					Name = "Mossel Bay Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 25,
					FacilityDistrictId = 5,
					Name = "Knysna Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 26,
					FacilityDistrictId = 5,
					Name = "George Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 27,
					FacilityDistrictId = 5,
					Name = "Hessequa Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 28,
					FacilityDistrictId = 5,
					Name = "Kannaland Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 29,
					FacilityDistrictId = 5,
					Name = "Oudtshoorn Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 30,
					FacilityDistrictId = 6,
					Name = "Beaufort West Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 31,
					FacilityDistrictId = 6,
					Name = "Laingsburg Local Municipality"
				},
				new FacilitySubDistrict
				{
					Id = 32,
					FacilityDistrictId = 6,
					Name = "Prince Albert Local Municipality"
				}
			);
		}
	}
}
