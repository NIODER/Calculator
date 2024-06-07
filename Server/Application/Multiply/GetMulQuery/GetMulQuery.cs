using Application.Common;
using MediatR;

namespace Application.Multiply.GetMulQuery;

public record GetMulQuery(decimal Number1, decimal Number2) : IRequest<CalcResult>;
