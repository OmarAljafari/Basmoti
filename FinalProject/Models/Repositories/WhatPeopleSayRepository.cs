namespace FinalProject.Models.Repositories
{
    public class WhatPeopleSayRepository : IRepository<WhatPeopleSay>
    {
        public WhatPeopleSayRepository(AppDbContext db)
        {
            Db = db;
        }

        public AppDbContext Db { get; }

        public void Active(int id, WhatPeopleSay entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public void Add(WhatPeopleSay entity)
        {
            Db.WhatPeopleSay.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, WhatPeopleSay entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id,data);
        }

        public WhatPeopleSay Find(int id)
        {
           return Db.WhatPeopleSay.Find(id);

        }

        public void Update(int id, WhatPeopleSay entity)
        {
            Db.WhatPeopleSay.Update(entity);
            Db.SaveChanges();
        }

        public List<WhatPeopleSay> View()
        {
            return Db.WhatPeopleSay.Where(x => !x.IsDelete).ToList();    
        }

        public List<WhatPeopleSay> ViewFormClient()
        {
            return Db.WhatPeopleSay.Where(x => !x.IsDelete && x.IsActive).ToList();
        }
    }
}
