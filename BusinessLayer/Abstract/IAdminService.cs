using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {

        Admin GetById(Admin admin);
      
        Admin GetByIdEdit(int id);
        string[] GetRolesForUser(string username);
        List<Admin> GetAdminListBl();
        void AdminAddBl(Admin admin);

        
        void AdminDeleteBl(Admin admin);

        void AdminUpdate(Admin admin);
        string MD5Create(string text);

    }
}
