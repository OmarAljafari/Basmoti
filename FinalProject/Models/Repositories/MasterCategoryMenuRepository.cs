namespace FinalProject.Models.Repositories
{
    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        public MasterCategoryMenuRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterCategoryMenu entity)
        {
            entity.IsActive = !entity.IsActive;
            Update(id, entity);
        }

        public void Add(MasterCategoryMenu entity)
        {
            Db.MasterCategoryMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterCategoryMenu entity)
        {
            var data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public MasterCategoryMenu Find(int id)
        {
            return Db.MasterCategoryMenus.SingleOrDefault(x => x.MasterCategoryMenuId == id);
        }

        public void Update(int id, MasterCategoryMenu entity)
        {
            Db.MasterCategoryMenus.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterCategoryMenu> View()
        {
            return Db.MasterCategoryMenus.Where(x => !x.IsDelete).ToList();
        }

        public List<MasterCategoryMenu> ViewFormClient()
        {
            return Db.MasterCategoryMenus.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
