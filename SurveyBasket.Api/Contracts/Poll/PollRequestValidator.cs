namespace SurveyBasket.Api.Contracts.Poll
{
    public class LoginRequestValidator : AbstractValidator<PollRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Please add a {PropertyName}")
                .Length(3, 100)
                .WithMessage("Title Should be at least {MinLength} and maximum {MaxLength}, you entered [{TotalLength}]");

            RuleFor(x => x.Summary)
                .NotEmpty()
                .Length(3, 1500);

            RuleFor(x => x.StartsAt)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));

            RuleFor(x => x.EndsAt)
                .NotEmpty();

            RuleFor(x => x)
                .Must(HasValidDates)
                .WithName(nameof(PollRequest.EndsAt))
                .WithMessage("{PropertyName} must be greater than or equals Start date");


        }

        public bool HasValidDates(PollRequest poll)
        {
            return poll.EndsAt >= poll.StartsAt;
        }
    }
}
