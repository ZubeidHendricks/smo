using NPOMS.Domain.Entities;
namespace NPOMS.Domain.Mapping
{
    public class ActivityArea : BaseEntity
    {
        public int DemographicDistrictId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
