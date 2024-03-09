namespace FinalProject.Models.Repositories
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {
        public MasterSliderRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterSlider entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public void Add(MasterSlider entity)
        {
            Db.MasterSliders.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterSlider entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id,data);
        }

        public MasterSlider Find(int id)
        {
            return Db.MasterSliders.Find(id);
        }

        public void Update(int id, MasterSlider entity)
        {
            Db.MasterSliders.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterSlider> View()
        {
            return Db.MasterSliders.Where(x => !x.IsDelete).ToList();
        }

        public List<MasterSlider> ViewFormClient()
        {
            return Db.MasterSliders.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
