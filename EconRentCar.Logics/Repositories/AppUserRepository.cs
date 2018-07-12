using EconRentCar.Core;
using EconRentCar.DataModel;
using EconRentCar.Logics.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconRentCar.Logics.Repositories
{
    public class AppUserRepository : EntityBaseRepository<AppUser>, IAppUserRepository
    {
        private static AppUserRepository instance;
        public static AppUserRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppUserRepository(ApplicationDbContext.Instance, AppUserValidator.Instance);
                }
                return instance;
            }
        }
        private AppUserRepository(DbContext db, IValidator<AppUser> val)
            : base(db, val)
        {

        }
    }
}
