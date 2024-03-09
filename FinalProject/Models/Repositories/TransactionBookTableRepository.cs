namespace FinalProject.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        public TransactionBookTableRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, TransactionBookTable entity)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionBookTable entity)
        {
            Db.TransactionBookTables.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, TransactionBookTable entity)
        {
            throw new NotImplementedException();
        }

        public TransactionBookTable Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TransactionBookTable entity)
        {
            throw new NotImplementedException();
        }

        public List<TransactionBookTable> View()
        {
            return Db.TransactionBookTables.ToList();
        }

        public List<TransactionBookTable> ViewFormClient()
        {
            throw new NotImplementedException();
        }
    }
}
