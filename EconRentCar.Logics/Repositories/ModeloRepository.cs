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
    public class ModeloRepository : EntityBaseRepository<Modelo>,IModeloRepository
    {
        private static ModeloRepository instance;
        public static ModeloRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModeloRepository(ApplicationDbContext.Instance, ModeloValidator.Instance);
                }
                return instance;
            }
        }
        private ModeloRepository(DbContext db, IValidator<Modelo> val)
            : base(db, val)
        {

        }
    }
}
