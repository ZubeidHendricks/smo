using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;

namespace NPOMS.Repository.Implementation.Entities
{
	public class SubSubRecipientRepository : BaseRepository<SubSubRecipient>, ISubSubRecipientRepository
	{
		#region Constructors

		public SubSubRecipientRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		#endregion
	}
}
