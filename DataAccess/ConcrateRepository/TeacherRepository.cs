using DataAccess.Context;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConcrateRepository
{
    public class TeacherRepository : BaseRepository<Teacher>
    {
        public TeacherRepository(CodeFirstDbContext codeFirstDbContext) : base(codeFirstDbContext)
        {
        }
    }
}
