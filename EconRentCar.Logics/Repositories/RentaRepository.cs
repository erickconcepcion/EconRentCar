using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconRentCar.Core;
using EconRentCar.DataModel;
using FluentValidation;
using System.Data.Entity;
using EconRentCar.Logics.Validators;

namespace EconRentCar.Logics.Repositories
{
    public class RentaRepository : EntityBaseRepository<Renta>,IRentaRepository
    {
        private static RentaRepository instance;
        public static RentaRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RentaRepository(ApplicationDbContext.Instance, RentaValidator.Instance);
                }
                return instance;
            }
        }
        private RentaRepository(DbContext db, IValidator<Renta> val)
            : base(db, val)
        {

        }
    }
}
