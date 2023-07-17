using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Evaluation
{
	[Table("QuestionProperties", Schema = "eval")]
	public class QuestionProperty : BaseEntity
	{
		public int QuestionId { get; set; }

		public bool HasComment { get; set; }

		public bool CommentRequired { get; set; }

		public bool HasDocument { get; set; }

		public bool DocumentRequired { get; set; }

		public int Weighting { get; set; }
	}
}
