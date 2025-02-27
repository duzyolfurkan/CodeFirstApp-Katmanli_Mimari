﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface IBaseEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; } //İlk oluşturulduğunda null
        DateTime? DeletedDate { get; set; } //İlk oluşturulduğunda null

        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        string DeletedBy { get; set; }
        Status status { get; set; }
    }
}
