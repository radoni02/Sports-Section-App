using Section.Application.Abstractions.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Abstractions.Messaging;

public interface IMessageSender
{
    void SendMessage(BaseMessage message);
}
