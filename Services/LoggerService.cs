using Microsoft.Extensions.Hosting;

// Singleton service.
namespace LibraryAPI.Services {
    public class LoggerService : BaseService, IHostedService {
        private Timer timer;

	public LoggerService(IWebHostEnvironment env) : base(env) { }

	public Task StartAsync(CancellationToken cancel_token) {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

	public void DoWork(object state){
            LogToFile("Executing task\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }
	
	public Task StopAsync(CancellationToken cancel_token) {
            LogToFile("Stopping task...\n");
            timer.Dispose();
            return Task.CompletedTask;
        }
    }
}
