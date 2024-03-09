namespace FinalProject.Models.Repositories
{
    public class TransactionContactUsRepository : IRepository<TransactionContactUs>
    {
        public TransactionContactUsRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, TransactionContactUs entity)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionContactUs entity)
        {
            Db.TransactionContactUs.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionContactUs entity)
        {
            throw new NotImplementedException();
        }

        public TransactionContactUs Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TransactionContactUs entity)
        {
            throw new NotImplementedException();
        }

        public List<TransactionContactUs> View()
        {
            return Db.TransactionContactUs.ToList();
        }

        public List<TransactionContactUs> ViewFormClient()
        {
            return Db.TransactionContactUs.ToList();
        }
    }
}
