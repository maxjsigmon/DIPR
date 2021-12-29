using DIPR.Data;
using DIPR.Models.Bottle;
using DIPR.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DIPR.Services
{
    public class BottleService
    {
        private readonly Guid _userID;

        public BottleService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateBottle(BottleCreate model)
        {
            var entity =
                new BottleFeeding()
                {
                    ParentID = _userID,
                    BabyID = model.BabyID,
                    Name = model.Name,
                    Time = model.Time,
                    Contents = model.Contents,
                    Quantity = model.Quantity,
                    Consumed = model.Consumed,
                    Notes = model.Notes
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bottles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BottleListItem> GetBottle()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Bottles
                        .Where(e => e.ParentID == _userID)
                        .Select(
                            e =>
                                new BottleListItem
                                {

                                    Name = e.Baby.Name,
                                    BottleID = e.ID,
                                    Time = e.Time,
                                    Contents = e.Contents,
                                    Quantity = e.Quantity,
                                    Consumed = e.Consumed,
                                    Notes = e.Notes
                                }
                                );
                return query.ToArray();
            }
        }

        public BottleDetail GetBottleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bottles
                        .Single(e => e.ID == id && e.ParentID == _userID);
                return
                    new BottleDetail
                    {
                        BabyID = entity.BabyID,
                        BottleID = entity.ID,
                        Time = entity.Time,
                        Contents = entity.Contents,
                        Quantity = entity.Quantity,
                        Consumed = entity.Consumed,
                        Notes = entity.Notes
                    };
            }
        }

        public bool UpdateBottle(BottleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bottles
                        .Single(e => e.ID == model.BottleID && e.ParentID == _userID);
                entity.Time = model.Time;
                entity.Contents = model.Contents;
                entity.Quantity = model.Quantity;
                entity.Consumed = model.Consumed;
                entity.Notes = model.Notes;
                entity.BabyID = model.BabyID;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBottle(int bottleID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bottles
                        .Single(e => e.ID == bottleID && e.ParentID == _userID);

                ctx.Bottles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
