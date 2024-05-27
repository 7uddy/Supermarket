namespace Supermarket.MVVM.Model.EntityLayer
{
    public class ReceiptProduct
    {
        private string _productName;
        public string ProductName
        {
            get => _productName;
            set => _productName = value;
        }

        private int _productId;
        public int ProductId
        {
            get => _productId;
            set => _productId = value;
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set => _price = value;
        }
    }
}
