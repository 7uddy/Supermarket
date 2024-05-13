using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model.EntityLayer
{
    public class Product
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string barcode;
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }
        private int idCategory;
        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }
        private int idProducer;
        public int IdProducer
        {
            get { return idProducer; }
            set { idProducer = value; }
        }
    }
}
