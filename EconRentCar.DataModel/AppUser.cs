using EconRentCar.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconRentCar.DataModel
{
    public class AppUser: IEntityBase
    {
        public AppUser()
        {
            Empleados = new HashSet<Empleado>();
        }
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }

    }
}
