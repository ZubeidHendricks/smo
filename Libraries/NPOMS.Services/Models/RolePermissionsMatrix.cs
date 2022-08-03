using AutoMapper;
using NPOMS.Domain.Core;
using System.Collections.Generic;
using System.Linq;

namespace NPOMS.Services.Models
{
	public class RolePermissionsMatrix
	{
		private List<KeyValuePair<string, List<KeyValuePair<string, bool>>>> _mappings = new List<KeyValuePair<string, List<KeyValuePair<string, bool>>>>();
		private IMapper _mapper;
		private List<PermissionViewModel> _availablePermissions;
		private List<RoleViewModel> _availableRoles;

		public RolePermissionsMatrix(
					IMapper mapper
			)
		{
			this._mapper = mapper;
			this._availablePermissions = this._availablePermissions ?? new List<PermissionViewModel>();
		}

		public List<KeyValuePair<string, List<KeyValuePair<string, bool>>>> Mappings => _mappings;

		public List<PermissionViewModel> AvailableFeaturePermissions => _availablePermissions;

		public List<RoleViewModel> AvailableRoles => _availableRoles;

		public void Init(List<Permission> permissions, List<Role> roles)
		{
			this._availablePermissions = _mapper.Map<List<PermissionViewModel>>(permissions);
			this._availableRoles = _mapper.Map<List<RoleViewModel>>(roles);

			permissions.ForEach(x =>
			{
				List<KeyValuePair<string, bool>> item = new List<KeyValuePair<string, bool>>();

				roles.ForEach(r =>
				{
					bool isMapped = x.Roles.Any(y => y.RoleId == r.Id);
					KeyValuePair<string, bool> mapping = new KeyValuePair<string, bool>(r.SystemName, isMapped);
					item.Add(mapping);
				});

				KeyValuePair<string, List<KeyValuePair<string, bool>>> mapping
								= new KeyValuePair<string, List<KeyValuePair<string, bool>>>(x.SystemName, item);

				_mappings.Add(mapping);
			});
		}
	}
}
