using System;
using WindowsAuthenticationModule;
using AuthenticationModule;
using FormsAuthenticationModule;
using GoogleAuthenticationModule;
using log4net.Config;
using log4net;

namespace multiauth
{
	public class Program
	{
		readonly static ILog log = LogManager.GetLogger( typeof( Program ) );
		static void Main( string[] args )
		{
			XmlConfigurator.Configure();

			//var reply = 0;
			//var authHandlers = new AuthenticationHandler();
			//var authModule = authHandlers.StartAuthenticationModule();
			ICanAuthenticateUsers a=new WindowsAuthentication();
			ICanAuthenticateUsers b=new FormsAuthentication();
			ICanAuthenticateUsers c=new GoogleAuthentication();
			

			if (args.Length != 2)
			{
				Console.WriteLine("no credentials. exiting");
				Console.ReadLine();
				log.ErrorFormat( "no credentials. exiting" );
				return;
			}
			
			
			var userName = args[0];
			var password = args[1];

			a.NextModule = b;
			b.NextModule = c;

			a.LogIn(userName,password);


			//bool login;

			//login = authHandlers.TryAll(userName, password);


			//if (login)
			//{
			//	Console.WriteLine( "user {0} has logged in successfully.", userName );
			//}

			Console.ReadLine();
		}
	}
}

