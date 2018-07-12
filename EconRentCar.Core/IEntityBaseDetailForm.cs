using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EconRentCar.Core
{
    public interface IEntityBaseDetailForm<T> where T: class, IEntityBase, new()
    {
        void ToUpdate(bool forUpdate);
        void SetFormTitle(string AddTitle, string ModifyTitle);

        void ChargeEntity(int id);

        void SaveOrUpdate(Func<T> InData);
        DialogResult ShowDialog();
    }
}
