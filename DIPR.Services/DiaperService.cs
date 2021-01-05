using DIPR.Data;
using DIPR.Models.Diaper;
using DIPR.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPR.Services
{
    public class DiaperService
    {
        private readonly Guid _userID;

        public DiaperService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateDiaper(DiaperCreate model)
        {
            var entity =
                new Diaper()
                {
                    ParentID = _userID,
                    BabyID = model.BabyID,
                    Soiled = model.Soiled,
                    Time = model.Time,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Diapers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DiaperListItem> GetDiaper()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Diapers
                        .Where(e => e.ParentID == _userID)
                        .Select(
                            e =>
                                new DiaperListItem
                                {
                                    Name = e.Baby.Name,
                                    DiaperID = e.ID,
                                    Soiled = e.Soiled,
                                    Time = e.Time,
                                    Notes = e.Notes
                                }
                                );
                return query.ToArray();
            }
        }

        public DiaperDetails GetDiaperById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Diapers
                        .Single(e => e.ID == id && e.ParentID == _userID);
                return
                    new DiaperDetails
                    {
                        BabyID = entity.BabyID,
                        DiaperID = entity.ID,
                        Time = entity.Time,
                        Soiled = entity.Soiled,
                        Notes = entity.Notes
                    };
            }
        }

        public bool UpdateDiaper(DiaperEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Diapers
                        .Single(e => e.ID == model.DiaperID && e.ParentID == _userID);
                entity.Soiled = model.Soiled;
                entity.Time = model.Time;
                entity.Notes = model.Notes;
                entity.BabyID = model.BabyID;
                
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDiaper(int diaperID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Diapers
                        .Single(e => e.ID == diaperID && e.ParentID == _userID);

                ctx.Diapers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
