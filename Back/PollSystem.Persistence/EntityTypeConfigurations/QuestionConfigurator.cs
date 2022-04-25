using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollSystem.Domain;

namespace PollSystem.Persistence.EntityTypeConfigurations;

public class QuestionConfigurator : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasOne(a => a.QuestionSettings)
            .WithOne(a => a.Question)
            .HasForeignKey<QuestionSettings>(a => a.QuestionId);
    }
}