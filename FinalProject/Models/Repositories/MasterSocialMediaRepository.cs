namespace FinalProject.Models.Repositories
{
    public class MasterSocialMediaRepository : IRepository<MasterSocialMedia>
    {
        public MasterSocialMediaRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterSocialMedia entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,entity);
        }

        public void Add(MasterSocialMedia entity)
        {
            Db.MasterSocialMedia.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterSocialMedia entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate =entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public MasterSocialMedia Find(int id)
        {
            return Db.MasterSocialMedia.Find(id);
        }

        public void Update(int id, MasterSocialMedia entity)
        {
            Db.MasterSocialMedia.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterSocialMedia> View()
        {
            return Db.MasterSocialMedia.Where(x =>!x.IsDelete).ToList();
        }

        public List<MasterSocialMedia> ViewFormClient()
        {
            return Db.MasterSocialMedia.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
