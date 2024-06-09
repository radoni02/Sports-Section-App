using MediatR;
using Section.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Abstractions.CQRS;

public interface IQueryHandler<TQuery,Tresponse> : IRequestHandler<TQuery,Result<Tresponse>> where TQuery : IQuery<Tresponse>
{
}
