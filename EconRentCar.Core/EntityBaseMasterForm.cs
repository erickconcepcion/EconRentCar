using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EconRentCar.Core
{
    public class EntityBaseMasterForm<T, K> : EntityBaseForm<T> where T : class, IEntityBase, new() where K : EntityBaseDetailForm<T>, IEntityBaseDetailForm<T>, new()
    {
        protected IEnumerable<T> Entities;
        protected K AddForm;
        protected K EditForm;
        protected DataGridView Dtgv;
        protected Func<T, object> FieldDelimiter;
        public EntityBaseMasterForm(IEntityBaseRepository<T> db, string includedProps = "") 
            : base(db, includedProps)
        {
            Entities = GetAllInclude();
        }
        protected void FillDtgv(Func<T, bool> filter=null)
        {
            var pureCollection = Entities;
            if (filter!=null)
            {
                pureCollection = Entities.Where(filter);
            }
            Dtgv.DataSource = pureCollection.Select(FieldDelimiter).ToList();
        }
        public void AddAction()
        {
            AddForm = new K();
            AddForm.ShowDialog();
            Entities = GetAllInclude();
            FillDtgv();
        }
        public void ModifyAction(int selected)
        {
            EditForm = new K();
            EditForm.ToUpdate(true);
            EditForm.ChargeEntity(selected);
            EditForm.ShowDialog();
            Entities = GetAllInclude();
            FillDtgv();
        }

        public void DeleteAction(int selected)
        {
            Delete(selected);
            Entities = GetAllInclude();
            FillDtgv();
        }

        /*public void FilterDtg(DataGridView Dtg, string Filter)
        {
            string rowFilter = "";
            foreach (DataGridViewColumn col in Dtg.Columns)
            {
                if (col== Dtg.Columns[0])
                {
                    rowFilter += string.Format("[{0}] = '{1}'", col.Name, Filter);
                    continue;
                }
                rowFilter += string.Format(" OR [{0}] = '{1}'", col.Name, Filter);
            }
            var table = (DataTable)(Dtg.DataSource);
            table.DefaultView.RowFilter = rowFilter;
        }*/
    }
}
