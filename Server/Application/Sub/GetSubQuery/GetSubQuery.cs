using Application.Common;
using MediatR;

namespace Application.Sub.GetSubQuery;

public record GetSubQuery(decimal Diminutive, decimal Deductible) : IRequest<CalcResult>;
