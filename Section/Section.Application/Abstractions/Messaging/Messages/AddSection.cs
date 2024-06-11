using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Abstractions.Messaging.Messages;

public sealed record AddSection(Guid TeacherId) : BaseMessage
{ }
