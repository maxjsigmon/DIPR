using DIPR.Data;
using DIPR.Models.Nursing;
using DIPR.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIPR.Services
{
    public class NursingService
    {
        private readonly Guid _userID;

        public NursingService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateNursingData(NursingCreate model)
        {
            var entity =
                new Nursing()
                {
                    ParentID = _userID,
                    BabyID = model.BabyID,
                    Time = model.Time,
                    TimeFed = model.TimeFed,
                    FeedingSide = model.FeedingSide,
                    Notes = model.Notes,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Nursings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NursingListItem> GetNursingData()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Nursings
                        .Where(e => e.ParentID == _userID)
                        .Select(
                            e =>
                                new NursingListItem
                                {
                                    Name = e.Baby.Name,
                                    NursingID = e.ID,
                                    Time = e.Time,
                                    TimeFed = e.TimeFed,
                                    FeedingSide = e.FeedingSide,
                                    Notes = e.Notes,
                                    BabyID = e.BabyID
                                }
                                );
                return query.ToArray();
            }
        }

        public NursingDetail GetNursingDataById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Nursings
                        .Single(e => e.ID == id && e.ParentID == _userID);
                return
                    new NursingDetail
                    {
                        NursingID = entity.ID,
                        TimeFed = entity.TimeFed,
                        FeedingSide = entity.FeedingSide,
                        Notes = entity.Notes,
                        BabyID = entity.BabyID

                    };
            }
        }

        public bool UpdateNursingData(NursingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Nursings
                        .Single(e => e.ID == model.NursingID && e.ParentID == _userID);
                entity.Time = model.Time;
                entity.TimeFed = model.TimeFed;
                entity.Name = model.Name;
                entity.FeedingSide = model.FeedingSide;
                entity.Notes = model.Notes;
                entity.BabyID = model.BabyID;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNursingData(int nursingID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Nursings
                        .Single(e => e.ID == nursingID && e.ParentID == _userID);

                ctx.Nursings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
