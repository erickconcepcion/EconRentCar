using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconRentCar.Core;
using EconRentCar.DataModel;
using EconRentCar.Logics.Validators;
using FluentValidation;

namespace EconRentCar.Logics.Repositories
{
    public class EmpleadoRepository : EntityBaseRepository<Empleado>, IEmpleadoRepository
    {
        private static EmpleadoRepository instance;
        public static EmpleadoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmpleadoRepository(ApplicationDbContext.Instance, EmpleadoValidator.Instance);
                }
                return instance;
            }
        }
        private EmpleadoRepository(DbContext db, IValidator<Empleado> val)
            : base(db, val)
        {

        }
    }
}
