using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;

namespace NPOMS.Repository.Implementation.Entities
{
	public class SubRecipientRepository : BaseRepository<SubRecipient>, ISubRecipientRepository
	{
		#region Constructors

		public SubRecipientRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		#endregion
	}
}
