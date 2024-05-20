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
    public class ProducerBLL
    {
        public ObservableCollection<Producer> ProducersList { get; set; }
        ProducerDAL producerDAL = new ProducerDAL();

        public ObservableCollection<Producer> GetAllProducers()
        {
           return producerDAL.GetAllProducers();
        }

        public void InsertProducer(string insertName, string insertCountry)
        {
            producerDAL.InsertProducer(insertName, insertCountry);
        }

        public void UpdateProducer(int id, string newName, string newCountry)
        {
            producerDAL.UpdateProducer(id, newName, newCountry);
        }

        public void DeleteProducer(int id)
        {
            producerDAL.DeleteProducer(id);
        }
    }
}
