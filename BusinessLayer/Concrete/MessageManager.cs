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
    public class MessageManager : IMessageService
    {
        IRepository<Message> _repository;

        public MessageManager(IRepository<Message> repository)
        {
            _repository = repository;
        }

        public void DeleteByCheckBox(int id)
        {
            Context context = new Context();
           var info= context.Messages.Find(id);
            context.Messages.Remove(info);
            context.SaveChanges();
            
        }

        public Message GetById(int id)
        {
            return _repository.Get(x => x.MessageId == id);
        }

        public List<Message> GetMessageInboxListBl(string p)
        {
            
            return _repository.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetMessageInboxListSearchBl(string text)
        {
            return _repository.List(x => x.MessageContent.Contains(text));
        }

        public List<Message> GetMessageSendListBl(string p)
        {
            return _repository.List(x => x.SenderMail == p);
        }

        public int InboxCount(string p)
        {
            return _repository.List(x => x.ReceiverMail == p).Count();
        }

        public void MEssageAddBl(Message message)
        {
            _repository.Add(message);

        }

        public void MessageDeleteBl(Message message)
        {
            _repository.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }

        

        public int SendBoxCount(string p)
        {
            return _repository.List(x => x.SenderMail == p).Count();
        }
    }
}
