using Cemetery.Business.Abtract;
using Cemetery.DataAccess.Abstract;
using Cemetery.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cemetery.Business.Concrete
{
    public class PersonalManager : IPersonalService
    {
        IPersonalDal _personalDal;

        public PersonalManager(IPersonalDal personalDal)
        {
            _personalDal = personalDal;
        }

        public void TAdd(Personal t)
        {
            _personalDal.Insert(t);
        }

        public void TDelete(Personal t)
        {
            _personalDal.Delete(t);
        }

        public Personal TGetById(int id)
        {
            return _personalDal.GetById(id);
        }

        public List<Personal> TGetList()
        {
            return _personalDal.GetList();
        }

        public void TUpdate(Personal t)
        {
            _personalDal.Update(t);
        }
    }
}
