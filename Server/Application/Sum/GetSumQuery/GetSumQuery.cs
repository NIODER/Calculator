using MediatR;

namespace Application.Sum.GetSumQuery;

public record GetSumQuery(
    decimal Number1,
    decimal Number2
) : IRequest<SumResult>;
