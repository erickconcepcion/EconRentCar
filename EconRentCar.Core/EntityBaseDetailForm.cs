using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EconRentCar.Core
{
    public class EntityBaseDetailForm<T> : EntityBaseForm<T>, IEntityBaseDetailForm<T> where T : class, IEntityBase, new()
    {
        public bool ForUpdate;
        protected T Entity;
        public EntityBaseDetailForm(IEntityBaseRepository<T> db, string includedProps = "")
            : base(db, includedProps)
        {
            ForUpdate = false;
        }

        public void SetFormTitle(string AddTitle, string ModifyTitle) => Text = ForUpdate ? ModifyTitle : AddTitle;

        
        public void ChargeEntity(int id)
        {
            Entity = Get(id);
        }

        public void SaveOrUpdate(Func<T> InData)
        {
            Entity = InData();
            if (ForUpdate)
            {
                Update(Entity.Id, Entity);
                return;
            }
            Create(Entity);
        }

        public void ToUpdate(bool forUpdate)
        {
            ForUpdate = forUpdate;
        }
    }
}
