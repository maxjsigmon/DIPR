using DIPR.Data;
using DIPR.Models.Sleep;
using DIPR.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Services
{
    public class SleepService
    {
        private readonly Guid _userID;

        public SleepService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateSleep(SleepCreate model)
        {
            var entity =
                new Sleep()
                {
                    ParentID = _userID,
                    BabyID = model.BabyID,
                    Location = model.Location,
                    SleepStart = model.SleepStart,
                    SleepEnd = model.SleepEnd,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sleeps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SleepListItem> GetSleep()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sleeps
                        .Where(e => e.ParentID == _userID)
                        .Select(
                            e =>
                                new SleepListItem
                                {
                                    Name = e.Baby.Name,
                                    SleepID = e.ID,
                                    Location = e.Location,
                                    SleepStart = e.SleepStart,
                                    SleepEnd = e.SleepEnd,
                                    Notes = e.Notes
                                }
                                );
                return query.ToArray();
            }
        }
        public SleepDetail GetSleepById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sleeps
                        .Single(e => e.ID == id && e.ParentID == _userID);
                return
                    new SleepDetail
                    {
                        SleepID = entity.ID,
                        TotalSleep = entity.TotalSleep
                    };
            }
        }

        public bool UpdateSleep(SleepEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sleeps
                        .Single(e => e.ID == model.SleepID && e.ParentID == _userID);
                entity.Location = model.Location;
                entity.SleepStart = model.SleepStart;
                entity.SleepEnd = model.SleepEnd;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSleep(int sleepID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sleeps
                        .Single(e => e.ID == sleepID && e.ParentID == _userID);

                ctx.Sleeps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}