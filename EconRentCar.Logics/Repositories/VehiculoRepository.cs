using EconRentCar.Core;
using EconRentCar.DataModel;
using FluentValidation;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconRentCar.Logics.Validators;

namespace EconRentCar.Logics.Repositories
{
    public class VehiculoRepository: EntityBaseRepository<Vehiculo>,IVehiculoRepository
    {
        private static VehiculoRepository instance;
        public static VehiculoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VehiculoRepository(ApplicationDbContext.Instance, VehiculoValidator.Instance);
                }
                return instance;
            }
        }
        private VehiculoRepository(DbContext db, IValidator<Vehiculo> val)
            : base(db, val)
        {

        }
    }
}
