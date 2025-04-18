﻿using SurveyBasket.Api.Entities;

namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {
        private static readonly List<Poll> _polls = [
            new Poll
            {
                Id = 1,
                Title = "Poll 1",
                Summary = "This is First Poll"
            }
        ];

        public IEnumerable<Poll> GetAll() => _polls;

        public Poll? Get(int id) => _polls.SingleOrDefault(p => p.Id == id);

        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count + 1;

            _polls.Add(poll);

            return poll;
        }


        public bool Update(int id, Poll poll)
        {
            var currentPoll = Get(id);

            if (currentPoll is null)
            {
                return false;
            }

            currentPoll.Title = poll.Title;
            currentPoll.Summary = poll.Summary;
            
            return true;
        }

        public bool Delete(int id)
        {
            var Poll = Get(id);

            if (Poll is null)
            {
                return false;
            }

            _polls.Remove(Poll);

            return true;
        }
    }
}
