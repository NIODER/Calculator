using Application.Common;
using Domain;
using MediatR;

namespace Application.Multiply.GetMulQuery;

internal class GetMulQueryHandler : IRequestHandler<GetMulQuery, CalcResult>
{
    public Task<CalcResult> Handle(GetMulQuery request, CancellationToken cancellationToken)
    {
        var result = Calculator.Multiply(request.Number1, request.Number2);
        return Task.FromResult(new CalcResult("Multiplication", request.Number1, request.Number2, result));
    }
}
