using Mapster;
using SurveyBasket.Api.Entities;

namespace SurveyBasket.Api.Services
{
    public class PollService (ApplicationDbContext context): IPollService
    {

        private readonly ApplicationDbContext _context = context;
        

        public async Task <IEnumerable<Poll>> GetAllAsync() =>
            await _context.Polls.AsNoTracking().ToListAsync();

        public async Task<Poll?> GetAsync(int id) =>
            await _context.Polls.FindAsync(id);

        public async Task <Poll> AddAsync(Poll poll)
        {
            await _context.Polls.AddAsync(poll);
            await _context.SaveChangesAsync();

            return poll;
        }


        //public bool Update(int id, Poll poll)
        //{
        //    var currentPoll = Get(id);

        //    if (currentPoll is null)
        //    {
        //        return false;
        //    }

        //    currentPoll.Title = poll.Title;
        //    currentPoll.Summary = poll.Summary;

        //    return true;
        //}

        //public bool Delete(int id)
        //{
        //    var Poll = Get(id);

        //    if (Poll is null)
        //    {
        //        return false;
        //    }

        //    _polls.Remove(Poll);

        //    return true;
        //}
    }
}
