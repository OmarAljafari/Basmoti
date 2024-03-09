namespace FinalProject.Models.Repositories
{
    public class MasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        public MasterContactUsInformationRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterContactUsInformation entity)
        {
            entity.IsActive = !entity.IsActive;
            Update(id,entity);
        }

        public void Add(MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformations.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterContactUsInformation entity)
        {
            entity.IsDelete = true;
            entity.IsActive = false;
            Update(id,entity);
        }

        public MasterContactUsInformation Find(int id)
        {
            return Db.MasterContactUsInformations.SingleOrDefault(x => x.MasterContactUsInformationId == id);
        }

        public void Update(int id, MasterContactUsInformation entity)
        {
            Db.MasterContactUsInformations.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterContactUsInformation> View()
        {
            return Db.MasterContactUsInformations.Where(x =>!x.IsDelete).ToList();
        }

        public List<MasterContactUsInformation> ViewFormClient()
        {
            return Db.MasterContactUsInformations.Where(x =>!x.IsDelete && x.IsActive).ToList();
        }
    }
}
