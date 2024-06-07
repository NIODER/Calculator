using Domain;
using MediatR;

namespace Application.Sum.GetSumQuery;

internal class GetSumQueryHandler : IRequestHandler<GetSumQuery, SumResult>
{
    public Task<SumResult> Handle(GetSumQuery request, CancellationToken cancellationToken)
    {
        var result = Calculator.Add(request.Number1, request.Number2);
        return Task.FromResult(new SumResult(request.Number1, request.Number2, result));
    }
}
