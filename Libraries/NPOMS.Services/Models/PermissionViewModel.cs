using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NPOMS.Services.Models
{
	public class PermissionViewModel
	{
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("systemName")]
        public string SystemName { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        public ICollection<RoleViewModel> Roles { get; set; }
    }
}
