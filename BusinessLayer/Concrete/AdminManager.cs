using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IRepository<Admin> _repository;

        public AdminManager(IRepository<Admin> repository)
        {
            _repository = repository;
        }

        public void AdminAddBl(Admin admin)
        {
            _repository.Add(admin);
        }

        public void AdminDeleteBl(Admin admin)
        {
            _repository.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _repository.Update(admin);
        }

        public List<Admin> GetAdminListBl()
        {
            return _repository.List();
        }

        public Admin GetById(Admin admin)
        {
            return _repository.Get(x => x.AdminMail == admin.AdminMail && x.AdminPassword == admin.AdminPassword);

        }

        public Admin GetByIdEdit(int id)
        {
            return _repository.Get(x => x.AdminId == id);
        }

       

        public string[] GetRolesForUser(string username)
        {
            var items=_repository.Get(x => x.AdminMail == username);
            return new string[] { items.AdminRole };

        }

        public  string MD5Create(string text)
        {
            MD5 mD5 = new MD5CryptoServiceProvider();
            mD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = mD5.Hash;

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }

            return stringBuilder.ToString(); 
        }
    }
}
