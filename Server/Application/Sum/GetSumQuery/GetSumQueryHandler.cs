using Application.Common;
using Domain;
using MediatR;

namespace Application.Sum.GetSumQuery;

internal class GetSumQueryHandler : IRequestHandler<GetSumQuery, CalcResult>
{
    public Task<CalcResult> Handle(GetSumQuery request, CancellationToken cancellationToken)
    {
        var result = Calculator.Add(request.Number1, request.Number2);
        return Task.FromResult(new CalcResult("Sum", request.Number1, request.Number2, result));
    }
}
