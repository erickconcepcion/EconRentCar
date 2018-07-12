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
    public class InspeccionRepository : EntityBaseRepository<Inspeccion>, IInspeccionRepository
    {
        private static InspeccionRepository instance;
        public static InspeccionRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InspeccionRepository(ApplicationDbContext.Instance, InspeccionValidator.Instance);
                }
                return instance;
            }
        }
        private InspeccionRepository(DbContext db, IValidator<Inspeccion> val)
            : base(db, val)
        {

        }
    }
}
