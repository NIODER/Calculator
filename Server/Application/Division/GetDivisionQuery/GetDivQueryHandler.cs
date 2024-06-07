using Application.Common;
using Domain;
using MediatR;

namespace Application.Division.GetDivisionQuery;

internal class GetDivQueryHandler : IRequestHandler<GetDivQuery, CalcResult>
{
    public Task<CalcResult> Handle(GetDivQuery request, CancellationToken cancellationToken)
    {
        var result = Calculator.Divide(request.Divisible, request.Divider);
        return Task.FromResult(new CalcResult("Division", request.Divisible, request.Divider, result));
    }
}
