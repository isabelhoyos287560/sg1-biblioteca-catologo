using System.Reflection;

namespace Library.Application.Common
{
    public sealed class SimpleMediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public SimpleMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetService(handlerType)
                ?? throw new InvalidOperationException($"No handler found for {request.GetType().Name}");

            var method = handlerType.GetMethod("HandleAsync")!;
            return (Task<TResponse>)method.Invoke(handler, new object[] { request, cancellationToken })!;
        }
    }
}