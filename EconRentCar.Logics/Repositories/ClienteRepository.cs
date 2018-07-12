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
    public class ClienteRepository : EntityBaseRepository<Cliente>, IClienteRepository
    {
        private static ClienteRepository instance;
        public static ClienteRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClienteRepository(ApplicationDbContext.Instance, ClienteValidator.Instance);
                }
                return instance;
            }
        }
        private ClienteRepository(DbContext db, IValidator<Cliente> val)
            : base(db, val)
        {

        }
    }
}
