using ServicesDemo.Services;

namespace ServicesDemo.Middlewares
{
    public class OperationServiceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly ISingletionOperationService _singletonService;
        //private readonly ITransientOperationService _transientService;
        //private readonly IScopedtOperationService _scopedService;

        public OperationServiceMiddleware(RequestDelegate next, ILogger<OperationServiceMiddleware> logger, ISingletionOperationService singletionOperationService)
        {
            _next = next;
            _logger = logger;
            _singletonService = singletionOperationService;
            //_scopedService = scopedtOperationService;
            //_transientService = transientOperationService;
        }

        public async Task InvokeAsync(HttpContext context, IScopedOperationService scopedtOperationService, ITransientOperationService transientOperationService)
        {
            _logger.LogInformation($"Middleware1: Transient: {transientOperationService.OperationId}");
            _logger.LogInformation($"Middleware1: Scoped: {scopedtOperationService.OperationId}");
            _logger.LogInformation($"Middleware1: Singleton: {_singletonService.OperationId}");
            await _next(context);
        }
    }
}
