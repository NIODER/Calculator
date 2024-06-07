using Application.Common;
using Domain;
using MediatR;

namespace Application.Sub.GetSubQuery;

internal class GetSubQueryHandler : IRequestHandler<GetSubQuery, CalcResult>
{
    public Task<CalcResult> Handle(GetSubQuery request, CancellationToken cancellationToken)
    {
        var result = Calculator.Subtract(request.Diminutive, request.Deductible);
        return Task.FromResult(new CalcResult("Subtraction", request.Diminutive, request.Deductible, result));
    }
}
