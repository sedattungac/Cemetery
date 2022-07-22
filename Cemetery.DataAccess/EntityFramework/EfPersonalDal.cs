using Cemetery.DataAccess.Abstract;
using Cemetery.Entity.Entity;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cemetery.DataAccess.EntityFramework
{
    public class EfPersonalDal : GenericRepository<Personal>, IPersonalDal
    {
    }
}
