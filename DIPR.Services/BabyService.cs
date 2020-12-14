using DIPR.Data;
using DIPR.Models;
using DIPR.Models.Baby;
using DIPR.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Gender = DIPR.Models.Baby.Gender;

namespace DIPR.Services
{
   public class BabyService
    {
        private readonly Guid _userID;

        public BabyService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateBaby(BabyCreate model)
        {
            var entity =
                new Baby()
                {
                    ParentID = _userID,
                    Name = model.Name,
                    Gender = (Data.Gender)model.Gender,
                    BirthDate = model.BirthDate

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Babies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BabyListItem> GetBaby()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Babies
                        .Where(e => e.ParentID == _userID)
                        .Select(
                            e =>
                                new BabyListItem
                                {
                                    BabyID = e.ID,
                                    Name = e.Name,
                                    Gender = (Gender)e.Gender,
                                    BirthDate = e.BirthDate
                                }
                                );
                return query.ToArray();
            }
        }

       
    }
}
