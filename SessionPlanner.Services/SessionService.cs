using SessionPlanner.Data;
using SessionPlanner.Models;
using SessionPlanner.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Services
{
    public class SessionService
    {
        private readonly Guid _userId;

        public SessionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSession(SessionCreate model)
        {
            var startDate = new DateTime(model.StartDay.Year, model.StartDay.Month, model.StartDay.Day, model.StartTime.Hour, model.StartTime.Minute, model.StartTime.Second);
            var endDate = new DateTime(model.EndDay.Year, model.EndDay.Month, model.EndDay.Day, model.EndTime.Hour, model.EndTime.Minute, model.EndTime.Second);

            using (var db = new ApplicationDbContext())
            {
                var pricePerHour = db.SessionTypes.Find(model.SessionTypeID).PricePerHour;

                var session = new Session()
                {
                    OwnerID = _userId,
                    SessionTypeID = model.SessionTypeID,
                    StartTime = startDate,
                    EndTime = endDate,
                    CreatedUtc = DateTime.Now,
                    Price = (model.EndTime - model.StartTime).Hours * pricePerHour
                };

                db.Sessions.Add(session);
                return db.SaveChanges() == 1;
            }
        }


        public IEnumerable<SessionListItem> GetSessions()
        {

            using (var db = new ApplicationDbContext())
            {
                var query = db.Sessions
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                    e =>
                        new SessionListItem
                        {
                            SessionID = e.SessionID,
                            SessionTypeID = e.SessionTypeID,
                            Name = e.SessionType.Name,
                            StartTime = e.StartTime,
                            EndTime = e.EndTime,
                            Price = e.Price

                        });
                return query.ToArray();
            }
        }


        public SessionDetail GetSessionByID(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Sessions.Single(s => s.SessionID == id);

                var model = new SessionDetail
                {
                    SessionID = entity.SessionID,
                    SessionTypeID = entity.SessionTypeID,
                    Name = entity.SessionType.Name,
                    StartTime = entity.StartTime,
                    EndTime = entity.EndTime,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                    Extras = entity.Extras,
                    Price = entity.Price
                };
                return model;
            }
        }


        public bool EditSession(SessionEdit model)
        {

            var startDate = new DateTime(model.StartDay.Year, model.StartDay.Month, model.StartDay.Day, model.StartTime.Hour, model.StartTime.Minute, model.StartTime.Second);
            var endDate = new DateTime(model.EndDay.Year, model.EndDay.Month, model.EndDay.Day, model.EndTime.Hour, model.EndTime.Minute, model.EndTime.Second);
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Sessions.Single(s => s.SessionID == model.SessionID);

                entity.SessionTypeID = model.SessionTypeID;
                entity.StartTime = startDate;
                entity.EndTime = endDate;
                entity.ModifiedUtc = DateTime.UtcNow;
                entity.Price = (model.EndTime - model.StartTime).Hours * model.PricePerHour;
                return db.SaveChanges() == 1;

            }
        }

        public bool DeleteSession(int sessionID)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Sessions.Single(s => s.SessionID == sessionID);

                db.Sessions.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
}
