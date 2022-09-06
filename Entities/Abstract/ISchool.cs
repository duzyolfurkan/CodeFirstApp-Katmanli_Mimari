using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface ISchool
    {
        int ID { get; set; }
        string Name { get; set; }
        int NumberOfStudent { get; set; }
        int NumberofEmployee { get; set; }

        //Bireçok bağlantı yapılacağı için çok kısmını buraya ekledim.
        //Bir okulun birden fazla öğretmeni olabilir mantığı ile
        List<Teacher> Teachers { get; set; }
    }
}
