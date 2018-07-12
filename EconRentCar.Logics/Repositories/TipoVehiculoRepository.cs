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
    public class TipoVehiculoRepository : EntityBaseRepository<TipoVehiculo>, ITipoVehiculoRepository
    {
        private static TipoVehiculoRepository instance;
        public static TipoVehiculoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TipoVehiculoRepository(ApplicationDbContext.Instance, TipoVehiculoValidator.Instance);
                }
                return instance;
            }
        }
        private TipoVehiculoRepository(DbContext db, IValidator<TipoVehiculo> val)
            : base(db, val)
        {

        }
    }
}
