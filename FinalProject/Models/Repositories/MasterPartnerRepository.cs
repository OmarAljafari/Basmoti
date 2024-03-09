namespace FinalProject.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {
        public MasterPartnerRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterPartner entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterPartner entity)
        {
            Db.MasterPartners.Add(entity);
            Db.SaveChanges();

        }

        public void Delete(int id, MasterPartner entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterPartner Find(int id)
        {
            return Db.MasterPartners.Find(id);
        }

        public void Update(int id, MasterPartner entity)
        {
            Db.MasterPartners.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterPartner> View()
        {
            return Db.MasterPartners.Where(x => !x.IsDelete).ToList();   
        }

        public List<MasterPartner> ViewFormClient()
        {
            return Db.MasterPartners.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
