using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace LibraryAPI.Services {
    public abstract class BaseService {
	private readonly IWebHostEnvironment env;
	private readonly string log_file = "Log.txt";

	public BaseService(IWebHostEnvironment env) {
	    this.env = env;
	}

	protected void LogToFile(string message) {
	    var path = $@"{env.ContentRootPath}/wwwroot/{log_file}";

	    using (StreamWriter w = new StreamWriter(path, append: true)) {
		w.WriteLine(message);
	    }
	}
    }
}
