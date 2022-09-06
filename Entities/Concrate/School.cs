using Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrate
{
    public class School : IBaseEntity, ISchool
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now; //Nesne üretildiğinde tarih bilgisi otomatik verilir.
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DeletedBy { get; set; }
        public Status status { get; set; } = Status.Active; //Statüyü aktif olarak verir.
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfStudent { get; set; }
        public int NumberofEmployee { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
