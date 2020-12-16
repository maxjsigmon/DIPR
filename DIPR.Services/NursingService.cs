using DIPR.Data;
using DIPR.Models.Nursing;
using DIPR.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                    TimeFed = e.TimeFed,
                                    FeedingSide = e.FeedingSide,
                                    Notes = e.Notes,
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
                entity.TimeFed = model.TimeFed;
                entity.FeedingSide = model.FeedingSide;
                entity.Notes = model.Notes;

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
