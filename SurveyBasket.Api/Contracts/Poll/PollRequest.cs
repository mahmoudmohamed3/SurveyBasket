﻿namespace SurveyBasket.Api.Contracts.Poll
{

    public record PollRequest(
        string Title,
        string Summary,
        bool IsPublished,
        DateOnly StartsAt,
        DateOnly EndsAt
        );

}
