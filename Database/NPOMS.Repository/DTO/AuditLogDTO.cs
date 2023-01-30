using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NPOMS.Repository.DTO
{
	public class AuditLogDTO
	{
		public AuditLogDTO(EntityEntry entry)
		{
			Entry = entry;
		}

		public EntityEntry Entry { get; }

		public string TableName { get; set; }

		public int TablePrimaryKey { get; set; }

		public AuditTypeEnum AuditType { get; set; }

		public List<string> AffectedColumns { get; } = new List<string>();

		public Dictionary<string, object> OldValue { get; } = new Dictionary<string, object>();

		public Dictionary<string, object> NewValue { get; } = new Dictionary<string, object>();

		public int CreatedUserId { get; set; }

		public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

		public bool HasTemporaryProperties => TemporaryProperties.Any();

		public AuditLog ToAudit()
		{
			var audit = new AuditLog();
			audit.TableName = TableName;
			audit.TablePrimaryKey = TablePrimaryKey;
			audit.AuditType = AuditType.ToString();
			audit.AffectedColumns = AffectedColumns.Count == 0 ? null : JsonConvert.SerializeObject(AffectedColumns);
			audit.OldValue = OldValue.Count == 0 ? null : JsonConvert.SerializeObject(OldValue);
			audit.NewValue = NewValue.Count == 0 ? null : JsonConvert.SerializeObject(NewValue);
			audit.CreatedUserId = CreatedUserId;
			audit.CreatedDateTime = DateTime.Now;
			return audit;
		}
	}
}
