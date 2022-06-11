using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public List<AdminModel> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(AdminModel t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AdminModel t)
        {
            throw new NotImplementedException();
        }

        public AdminModel TGetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public void TUpdate(AdminModel t)
        {
            throw new NotImplementedException();
        }
    }
}
