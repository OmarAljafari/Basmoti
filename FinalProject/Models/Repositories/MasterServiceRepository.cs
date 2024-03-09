namespace FinalProject.Models.Repositories
{
    public class MasterServiceRepository : IRepository<MasterService>
    {
        public MasterServiceRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterService entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public void Add(MasterService entity)
        {
            Db.MasterServices.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterService entity)
        {
            var data =Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate= entity.EditDate;
            Update(id,data);
        }

        public MasterService Find(int id)
        {
            return Db.MasterServices.Find(id);
        }

        public void Update(int id, MasterService entity)
        {
            Db.MasterServices.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterService> View()
        {
            return Db.MasterServices.Where(x => !x.IsDelete).ToList();
        }

        public List<MasterService> ViewFormClient()
        {
            return Db.MasterServices.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
