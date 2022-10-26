using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace LibraryAPI.Services {
    public class LoggerService : IHostedService {
        private readonly IWebHostEnvironment env;
        private readonly string log_file = "Log.txt";
        private Timer timer;

	public LoggerService(IWebHostEnvironment env) {
            this.env = env;
        }

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

	private void LogToFile(string message) {
            var path = $@"{env.ContentRootPath}/wwwroot/{log_file}";

	    using (StreamWriter w = new StreamWriter(path, append: true)) {
                w.WriteLine(message);
            }
        }
    }
}
