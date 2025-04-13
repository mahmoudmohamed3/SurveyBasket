using FluentValidation;

namespace SurveyBasket.Api.Contracts.Validitions
{
    public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
    {
        public CreatePollRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
