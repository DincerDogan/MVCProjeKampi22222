using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IRepository<Contact> _repository;
        Context context = new Context();
        public ContactManager(IRepository<Contact> repository)
        {
            _repository = repository;
        }
       
        public void ContactAddBl(Contact contact)
        {

            _repository.Add(contact);
        }

        public int ContactCount()
        {
            return _repository.List().Count();
        }

        public void ContactDeleteBl(Contact contact)
        {
            _repository.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _repository.Update(contact);
        }

        public void DeleteByCheckbox(int id)
        {
            var item=context.Contacts.Find(id);
            context.Contacts.Remove(item);
            context.SaveChanges();
        }

        public Contact GetById(int id)
        {
            return _repository.Get(x => x.ContactId == id);
        }

        public List<Contact> GetContactListBl(string p)
        {
           return  _repository.List(x=>x.ContactMessage.Contains(p));
        }
    }
}
