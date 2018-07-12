using System;
using System.Data.Entity;
using System.Linq;
namespace EconRentCar.DataModel
{ 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("Data Source=.\\Econsoft;Initial Catalog=EconRentCar;Integrated Security=True; MultipleActiveResultSets=True;")
        {
        }

        public virtual DbSet<TipoCombustible> TipoCombustibles { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }

        public virtual DbSet<Renta> Rentas { get; set; }
        public virtual DbSet<Inspeccion> Inspeccions { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        private static ApplicationDbContext instance;
        
        public static ApplicationDbContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationDbContext();
                }
                return instance;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}