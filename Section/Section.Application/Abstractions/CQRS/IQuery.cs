using MediatR;
using Section.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Abstractions.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
