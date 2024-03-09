namespace FinalProject.Models.Repositories
{
    public class MasterWorkingHourRepository : IRepository<MasterWorkingHour>
    {
        public MasterWorkingHourRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, MasterWorkingHour entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public void Add(MasterWorkingHour entity)
        {
            Db.MasterWorkingHours.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, MasterWorkingHour entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate= entity.EditDate;
            Update(id, data);  
        }

        public MasterWorkingHour Find(int id)
        {
            return Db.MasterWorkingHours.SingleOrDefault(x => x.MasterWorkingHourId == id);
        }

        public void Update(int id, MasterWorkingHour entity)
        {
            Db.MasterWorkingHours.Update(entity);
            Db.SaveChanges();
        }

        public List<MasterWorkingHour> View()
        {
            return Db.MasterWorkingHours.Where(x =>!x.IsDelete).ToList();
        }

        public List<MasterWorkingHour> ViewFormClient()
        {
            return Db.MasterWorkingHours.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
