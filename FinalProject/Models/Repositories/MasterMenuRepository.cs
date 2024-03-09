namespace FinalProject.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        public MasterMenuRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterMenu entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive; 
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);

        }

        public void Add(MasterMenu entity)
        {
            Db.MasterMenus.Add(entity); 
            Db.SaveChanges();
        }

        public void Delete(int id, MasterMenu entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate= entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public MasterMenu Find(int id)
        {
            return Db.MasterMenus.SingleOrDefault(x => x.MasterMenuId == id);
        }

        public void Update(int id, MasterMenu entity)
        {
            Db.MasterMenus.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterMenu> View()
        {
            return Db.MasterMenus.Where(x => !x.IsDelete).ToList();
        }

        public List<MasterMenu> ViewFormClient()
        {
            return Db.MasterMenus.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
