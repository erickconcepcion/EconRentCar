using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EconRentCar.Core
{
    public class EntityBaseForm<T> : Form where T : class, IEntityBase, new()
    {
        public readonly IEntityBaseRepository<T> Db;
        public readonly string IncludedProperties;
        public readonly bool Included;
        public EntityBaseForm(IEntityBaseRepository<T> db, string includedProps = "")
        {
            Db = db;
            IncludedProperties = includedProps;
        }

        public IEnumerable<T> GetAllInclude()
        {
            return !string.IsNullOrEmpty(IncludedProperties) && !string.IsNullOrWhiteSpace(IncludedProperties) ? Db.GetIncluding(IncludedProperties) : Db.Get();
        }

        public T Get(int id)
        {
            return !string.IsNullOrEmpty(IncludedProperties) && !string.IsNullOrWhiteSpace(IncludedProperties) ? Db.Find(id, IncludedProperties) : Db.Find(id);
        }

        public void Create(T vm)
        {
            if (vm == null)
            {
                Warning("La Entidad esta vacia");
                return;
            }
            var result = Db.Add(vm);
            if (!result.Success)
            {
                Warning(result.ResultMessageToString());
                return;
            }

            if (!Db.Save())
            {
                Error("La base de datos ha arrojado un error");
                return;
            }

            Info("Datos guardados exitosamente");
            Close();
        }

        public void Update(int id, T vm)
        {

            if (id == 0)
            {
                Info("La Entidad esta vacia");
                return;
            }

            var find = Db.Find(id);
            if (find == null)
            {
                Warning("Datos no encontrados");
                return;
            }

            var result = Db.Update(vm);

            if (!result.Success)
            {
                Warning(result.ResultMessageToString());
                return;
            }

            if (!Db.Save())
            {
                Error("La base de datos ha arrojado un error");
                return;
            }

            Info("Datos guardados exitosamente");
            Close();
        }
        

        public void Delete(int id)
        {
            if (!Question("Está seguro que desea eliminar este registro"))
            {
                return;
            }
            var find = Db.Get().Where(t => t.Id == id).FirstOrDefault();
            if (find == null)
            {
                Warning("Datos no encontrados");
                return;
            }

            Db.Delete(find);

            if (!Db.Save())
            {
                Error("La base de datos ha arrojado un error");
                return;
            }

        }

        public DialogResult Error(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public DialogResult Warning(string message) => MessageBox.Show(message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public DialogResult Info(string message) => MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public bool Question(string message) => MessageBox.Show($"¿{message}?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public void ChargeDataSelectList<D>(ComboBox Combo, IEnumerable<D> Ds,string DisplayProp, string ValueProp, Func<D,object>Options)
            where D : class, IEntityBase, new()
        {
            if (Ds.Any())
            {
                Combo.DataSource = Ds
                    .Select(Options).ToList();
                Combo.DisplayMember = DisplayProp;
                Combo.ValueMember = ValueProp;
            }
                        
        }

        public void ChargeEnumSelectList<D>(ComboBox Combo)
            where D : Enum
        {
            Combo.DataSource = Enum.GetValues(typeof(D));
        }
    }
}
