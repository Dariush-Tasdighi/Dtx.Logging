namespace Server.Controllers
{
	[Microsoft.AspNetCore.Mvc.ApiController]
	[Microsoft.AspNetCore.Mvc.Route("[controller]")]
	public class SomeController : Microsoft.AspNetCore.Mvc.Controller
	{
		//public SomeController
		//	(Microsoft.Extensions.Logging.ILogger<SomeController> logger) : base()
		//{
		//	Logger = logger;
		//}

		//protected Microsoft.Extensions.Logging.ILogger<SomeController> Logger { get; }

		public SomeController
			(Dtx.Logging.ILogger<SomeController> logger) : base()
		{
			Logger = logger;
		}

		protected Dtx.Logging.ILogger<SomeController> Logger { get; }

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public Microsoft.AspNetCore.Mvc.IActionResult Get()
		{
			// **************************************************
			//Logger.LogTrace(message: "Trace 1");
			//Logger.LogDebug(message: "Debug 1");
			//Logger.LogInformation(message: "Info 1");
			//Logger.LogWarning(message: "Warn 1");
			//Logger.LogError(message: "Error 1");
			//Logger.LogCritical(message: "Fatal 1");
			// **************************************************

			// **************************************************
			System.Exception innerException = new System.Exception(message: "Inner Exception Message (1)");
			System.Exception exception = new System.Exception(message: "Exception Message (1)", innerException: innerException);

			System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
			hashtable.Add(key: "Key1", value: "Value1");
			hashtable.Add(key: "Key2", value: "Value2");

			Logger.LogCritical(exception: exception, message: "Fatal 1", parameters: hashtable);
			// **************************************************

			string message = "Hello, World!";

			return Ok(value: message);
		}
	}
}
