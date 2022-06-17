using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContactService
    {
        List<Contact> GetContactListBl(string p);
        void DeleteByCheckbox(int id);
        void ContactAddBl(Contact contact);
        int ContactCount();
        Contact GetById(int id);
        void ContactDeleteBl(Contact contact);

        void ContactUpdate(Contact contact);
    }
}
