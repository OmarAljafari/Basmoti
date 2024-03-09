using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        public MasterItemMenuRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterItemMenu entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public void Add(MasterItemMenu entity)
        {
            Db.MasterItemMenus.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterItemMenu entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            data.IsActive = false;
            Update(id,data);
        }

        public MasterItemMenu Find(int id)
        {
            return Db.MasterItemMenus.Include(x=>x.MasterCategoryMenu).SingleOrDefault(x =>x.MasterItemMenuId ==id);
        }

        public void Update(int id, MasterItemMenu entity)
        {
            Db.MasterItemMenus.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterItemMenu> View()
        {
            return Db.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x => !x.IsDelete).ToList();
        }

        public List<MasterItemMenu> ViewFormClient()
        {
            return Db.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
