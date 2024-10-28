using NPOMS.Domain.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NPOMS.Repository.Configurations.Evaluation
{
	public class QuestionPropertyConfiguration : IEntityTypeConfiguration<QuestionProperty>
	{
		public void Configure(EntityTypeBuilder<QuestionProperty> builder)
		{
			builder.HasIndex(x => new { x.QuestionId }).IsUnique();

			builder.HasData(
				/* Pre-evaluation */
				new QuestionProperty { Id = 1, QuestionId = 1, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 2, QuestionId = 2, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 3, QuestionId = 3, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 4, QuestionId = 4, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 5, QuestionId = 5, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 6, QuestionId = 6, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 7, QuestionId = 7, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 8, QuestionId = 8, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 9, QuestionId = 9, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 10, QuestionId = 10, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },
				new QuestionProperty { Id = 11, QuestionId = 11, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 0 },

				/* Evaluation */
				new QuestionProperty { Id = 12, QuestionId = 12, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 10 },
				new QuestionProperty { Id = 13, QuestionId = 13, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 5 },
				new QuestionProperty { Id = 14, QuestionId = 14, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 10 },
				new QuestionProperty { Id = 15, QuestionId = 15, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 5 },
				new QuestionProperty { Id = 16, QuestionId = 16, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 5 },
				new QuestionProperty { Id = 17, QuestionId = 17, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 10 },
				new QuestionProperty { Id = 18, QuestionId = 18, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 10 },
				new QuestionProperty { Id = 19, QuestionId = 19, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 10 },
				new QuestionProperty { Id = 20, QuestionId = 20, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 15 },
				new QuestionProperty { Id = 21, QuestionId = 21, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 10 },
				new QuestionProperty { Id = 22, QuestionId = 22, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 5 },
				new QuestionProperty { Id = 23, QuestionId = 23, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 5 },

				/* Adjudication */
				new QuestionProperty { Id = 24, QuestionId = 24, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 25 },
				new QuestionProperty { Id = 25, QuestionId = 25, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 25 },
				new QuestionProperty { Id = 26, QuestionId = 26, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 25 },
				new QuestionProperty { Id = 27, QuestionId = 27, HasComment = true, CommentRequired = true, HasDocument = false, DocumentRequired = false, Weighting = 25 },


                //Assessment & Evaluation
				new QuestionProperty { Id = 102, QuestionId = 102, HasComment = true, CommentRequired = false, HasDocument = false, DocumentRequired = false, Weighting = 0 },
                new QuestionProperty { Id = 104, QuestionId = 104, HasComment = true, CommentRequired = false, HasDocument = false, DocumentRequired = false, Weighting = 0 },
                new QuestionProperty { Id = 107, QuestionId = 107, HasComment = true, CommentRequired = false, HasDocument = false, DocumentRequired = false, Weighting = 0 },
                new QuestionProperty { Id = 109, QuestionId = 109, HasComment = true, CommentRequired = false, HasDocument = false, DocumentRequired = false, Weighting = 0 },
                new QuestionProperty { Id = 113, QuestionId = 113, HasComment = true, CommentRequired = false, HasDocument = false, DocumentRequired = false, Weighting = 0 },
                new QuestionProperty { Id = 115, QuestionId = 115, HasComment = true, CommentRequired = false, HasDocument = false, DocumentRequired = false, Weighting = 0 },

                new QuestionProperty { Id = 110, QuestionId = 110, HasComment = true, CommentRequired = false, HasDocument = false, DocumentRequired = false, Weighting = 0 },
                new QuestionProperty { Id = 112, QuestionId = 112, HasComment = true, CommentRequired = false, HasDocument = false, DocumentRequired = false, Weighting = 0 }
            );
		}
	}
}
