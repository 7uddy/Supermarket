using Supermarket.MVVM.Model.DataAccessLayer;
using Supermarket.MVVM.Model.EntityLayer;
using System;
using System.Collections.ObjectModel;

namespace Supermarket.MVVM.Model.BusinessLogicLayer
{
    public class ReceiptProductBLL
    {
        private ReceiptProductDAL receiptProductDAL = new ReceiptProductDAL();
        public ObservableCollection<ReceiptProduct> GetReceiptProducts(Receipt selectedReceipt)
        {
            return receiptProductDAL.GetReceiptProducts(selectedReceipt.Id);
        }

        public ObservableCollection<ReceiptProduct> GetHighestReceiptProducts(DateTime date)
        {
            int receiptId = receiptProductDAL.GetHighestReceiptId(date);
            return receiptProductDAL.GetReceiptProducts(receiptId);
        }
    }
}
