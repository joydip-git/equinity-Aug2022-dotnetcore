using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public sealed class Sample : IHostedService
{
    private readonly ILogger logger;

    public Sample(ILogger<Sample> logger, IHostApplicationLifetime applicationLifetime)
    {
        Console.WriteLine("Sample service created");
        this.logger = logger;
        applicationLifetime.ApplicationStarted.Register(OnStarted);
        applicationLifetime.ApplicationStopped.Register(OnStopped);
        applicationLifetime.ApplicationStopping.Register(OnStopping);
        
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("1. started...");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("2. ended...");
        return Task.CompletedTask;
    }

    private void OnStarted()
    {
        logger.LogInformation("OnStarted called...");
    }
    private void OnStopped()
    {
        logger.LogInformation("OnStopped called...");
    }
    private void OnStopping()
    {
        logger.LogInformation("OnStopping called...");
    }
}
