using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessageInboxListBl(string p);
        List<Message> GetMessageInboxListSearchBl(string text);
        List<Message> GetMessageSendListBl(string p);
        void MEssageAddBl(Message message);

        Message GetById(int id);
        void MessageDeleteBl(Message message);

        void MessageUpdate(Message message);
        int InboxCount(string p);
        int SendBoxCount(string p);

       void  DeleteByCheckBox(int id);

        

       
    }
}
