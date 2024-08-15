using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void UserUpdate(User user);
        User UserGetById(int id);
        List<User> GetAll();
        void ToggleStatus(int id);
    }
}
