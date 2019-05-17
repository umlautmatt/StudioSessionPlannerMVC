using SessionPlanner.Data;
using SessionPlanner.Models.SessionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Services
{
    public class SessionTypeService
    {

        public bool CreateSessionType(SessionTypeCreate model)
        {
            SessionType sessionType = new SessionType()
            {
                Name = model.Name,
                PricePerHour = model.PricePerHour
            };
            using (var db = new ApplicationDbContext())
            {
                db.SessionTypes.Add(sessionType);
                return db.SaveChanges() == 1;
            }
        }



        public IEnumerable<SessionTypeListItem> GetSessionTypes()
        {
            using(var db = new ApplicationDbContext())
            {
                var query = db.SessionTypes
                    .Select(
                    e => new SessionTypeListItem
                    {
                        SessionTypeID = e.SessionTypeID,
                        Name = e.Name,
                        PricePerHour = e.PricePerHour
                    });
                return query.ToArray();
                    
            }
        }


        public SessionTypeDetail GetSessionTypeByID(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.SessionTypes.FirstOrDefault(s => s.SessionTypeID == id);

                var model = new SessionTypeDetail
                {
                    SessionTypeID = entity.SessionTypeID,
                    Name = entity.Name,
                    PricePerHour = entity.PricePerHour
                };

                return model;
            }
        }



        public bool EditSessionType(SessionTypeEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.SessionTypes.FirstOrDefault(s => s.SessionTypeID == model.SessionTypeID);

                entity.Name = model.Name;
                entity.PricePerHour = model.PricePerHour;

                return db.SaveChanges() == 1;
            }
        }


        public bool DeleteSessionType(int id)
        {
            using(var db = new ApplicationDbContext())
            {
                var entity = db.SessionTypes.Single(s => s.SessionTypeID == id);

                db.SessionTypes.Remove(entity);
                return db.SaveChanges() == 1;
            }
        }


    }
}
