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
    public class TipoCombustibleRepository : EntityBaseRepository<TipoCombustible>,ITipoCombustibleRepository
    {
        private static TipoCombustibleRepository instance;
        public static TipoCombustibleRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TipoCombustibleRepository(ApplicationDbContext.Instance, TipoCombustibleValidator.Instance);
                }
                return instance;
            }
        }
        private TipoCombustibleRepository(DbContext db, IValidator<TipoCombustible> val)
            : base(db, val)
        {

        }
    }
}
