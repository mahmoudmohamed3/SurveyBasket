using SurveyBasket.Api.Models;

namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {
        private static readonly List<Poll> _polls = [
            new Poll
            {
                Id = 1,
                Title = "Poll 1",
                Description = "This is First Poll"
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
    }
}
