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
    public class MarcaRepository : EntityBaseRepository<Marca>, IMarcaRepository
    {
        private static MarcaRepository instance;
        public static MarcaRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MarcaRepository(ApplicationDbContext.Instance, MarcaValidator.Instance);
                }
                return instance;
            }
        }
        private MarcaRepository(DbContext db, IValidator<Marca> val)
            : base(db, val)
        {

        }
    }
}
