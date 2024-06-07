using Application.Common;
using MediatR;

namespace Application.Division.GetDivisionQuery;

public record GetDivQuery(decimal Divisible, decimal Divider) : IRequest<CalcResult>;
