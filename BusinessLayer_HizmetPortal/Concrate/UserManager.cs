using BusinessLayer_HizmetPortal.Abstract;
using DataAcessLayer_HizmetPortal.Abstract;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Concrate
{
    public class UserManager : IUserService
    {

        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user); 
        }

        public List<User> GetAll()
        {
            return _userDal.List();
        }

        public void ToggleStatus(int id)
        {
            var user = _userDal.GetById(id);
            if (user != null)
            {
                user.UserStatues = !user.UserStatues;
                _userDal.Update(user);
            }
        }

        public User UserGetById(int id)
        {
            return _userDal.Get(x => x.UserId == id);
        }

        public void UserUpdate(User user)
        {
            _userDal.Update(user);
        }
    }
}
