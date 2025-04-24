namespace SurveyBasket.Api.Contracts.Validitions
{
    public class PollRequestValidator : AbstractValidator<PollRequest>
    {
        public PollRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Please add a {PropertyName}")
                .Length(3, 100)
                .WithMessage("Title Should be at least {MinLength} and maximum {MaxLength}, you entered [{TotalLength}]");

            RuleFor(x => x.Summary)
                .NotEmpty()
                .Length(3, 1500);
    
        }
       
    }
}
