﻿using DataAccess.Context;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConcrateRepository
{
    public class SchoolRepository : BaseRepository<School>
    {
        public SchoolRepository(CodeFirstDbContext codeFirstDbContext) : base(codeFirstDbContext)
        {
        }
    }
}
