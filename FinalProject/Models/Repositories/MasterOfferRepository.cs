namespace FinalProject.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {
        public MasterOfferRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterOffer entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,entity);
        }

        public void Add(MasterOffer entity)
        {
            Db.MasterOffers.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterOffer entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;   
            Update(id,entity);
        }

        public MasterOffer Find(int id)
        {
            return Db.MasterOffers.Find(id);
        }

        public void Update(int id, MasterOffer entity)
        {
            Db.MasterOffers.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterOffer> View()
        {
            return Db.MasterOffers.Where(x => !x.IsDelete).ToList();
        }

        public List<MasterOffer> ViewFormClient()
        {
            return Db.MasterOffers.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
