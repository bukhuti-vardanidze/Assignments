
using ToDoAPP.Api.Db;

using ToDoAPP.Api.Db.Entities;

namespace ToDoAPP.Api.Repositories
{

    public interface ISendEmailRequestRepository
    {
        void Insert(SendEmailRequestEntity entity);
        Task SaveChangesAsync();
    }

    public class SendEmailRequestRepository : ISendEmailRequestRepository
    {
        private readonly AppDbContext _db;

        public SendEmailRequestRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Insert(SendEmailRequestEntity entity)
        {
            _db.SendEmailRequests.Add(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}