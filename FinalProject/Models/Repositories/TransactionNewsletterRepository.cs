namespace FinalProject.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        public TransactionNewsletterRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, TransactionNewsletter entity)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionNewsletter entity)
        {
            Db.TransactionNewsletters.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionNewsletter entity)
        {
            throw new NotImplementedException();
        }

        public TransactionNewsletter Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TransactionNewsletter entity)
        {
            throw new NotImplementedException();
        }

        public List<TransactionNewsletter> View()
        {
            return Db.TransactionNewsletters.ToList();
        }

        public List<TransactionNewsletter> ViewFormClient()
        {
            return Db.TransactionNewsletters.ToList();
        }
    }
}
