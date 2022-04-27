﻿using FluentValidation;

namespace PollSystem.Application.CQRS.Votes.Commands.CreateVoteCommand;

public class CreateVoteCommandValidator : AbstractValidator<CreateVoteCommand>
{
    public CreateVoteCommandValidator()
    {
        RuleFor(v => v.OptionId).NotEqual(Guid.Empty);
        RuleFor(v => v.UserLogin).NotEmpty().NotNull();
    }
}