using NPOMS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IUserService
	{
		Task<List<UserViewModel>> GetAll();

		Task<UserViewModel> Get(string userName, string givenName, string surname, bool autoCreateB2CUser = false);

		Task<List<UserViewModel>> Search(string searchTerm);

		Task<UserViewModel> Create(UserViewModel user, string userIdentifier);

		Task<UserViewModel> Update(UserViewModel user, string userIdentifier);

		Task Delete(UserViewModel user, string userIdentifier);

		Task<UserViewModel> GetById(int id);
	}
}
