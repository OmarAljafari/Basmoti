using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FinalProject.Models.Repositories
{
    public class SystemSettingRepositiry : IRepository<SystemSetting>
    {
        public SystemSettingRepositiry(AppDbContext db)
        {
            
            Db = db;
        }

       
        public AppDbContext Db { get; }

        public void Active(int id, SystemSetting entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id,entity);
        }

        public void Add(SystemSetting entity)
        {
            Db.SystemSettings.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, SystemSetting entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public SystemSetting Find(int id)
        {
            return   Db.SystemSettings.Find(id);
        }

        public void Update(int id, SystemSetting entity)
        {
            Db.SystemSettings.Update(entity);
            Db.SaveChanges();
        }

        public List<SystemSetting> View()
        {
            return Db.SystemSettings.Where(x => !x.IsDelete).ToList();
        }

        public List<SystemSetting> ViewFormClient()
        {
            return Db.SystemSettings.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
