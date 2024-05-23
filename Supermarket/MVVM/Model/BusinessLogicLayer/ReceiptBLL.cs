using Supermarket.MVVM.Model.DataAccessLayer;
using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class ReceiptBLL
    {
        ReceiptDAL receiptDAL = new ReceiptDAL();

        public ObservableCollection<Receipt> GetAllReceipts()
        {
            return receiptDAL.GetAllReceipts();
        }
    }
}
