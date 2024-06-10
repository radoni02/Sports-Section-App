using Identity.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Abstractions.CQRS;

public interface IQuery<TResponce> : IRequest<Result<TResponce>>
{
}
