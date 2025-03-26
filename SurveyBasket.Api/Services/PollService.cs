using SurveyBasket.Api.Models;

namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {
        private readonly List<Poll> _polls = [
            new Poll
            {
                Id = 1,
                Title = "Poll 1",
                Description = "This is First Poll"
            }
        ];

        public IEnumerable<Poll> GetAll() => _polls;

        public Poll? Get(int id) => _polls.SingleOrDefault(p => p.Id == id);

        
    }
}
