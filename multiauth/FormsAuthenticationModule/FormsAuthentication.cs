using System.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;
using AuthenticationModule;
using log4net.Config;
using Dapper;

namespace FormsAuthenticationModule
{
	public class FormsAuthentication : AuthenticationModule.AuthenticationModule
	{
		private string connectionString;

		public FormsAuthentication()
		{
			XmlConfigurator.Configure();
			connectionString = ConfigurationManager.ConnectionStrings["cs2"]
													.ConnectionString;

		}
		public override void LogIn(string UserName, string Password)
		{
			Console.WriteLine("{0} is trying to log the user ", this.GetType().Name);

			bool logIn;

			//using (var conn = new SqlConnection(connectionString) )
			//{
			//	var user = conn.Query<User>("select UserName=@UserName, Password=@Password",
			//					new {UserName = UserName, Password = Password})
			//					.SingleOrDefault();

			//	logIn = user != null;
			//}

			logIn = UserName == "gigi" && Password == "gigel";
			if (!logIn&&this.NextModule!=null)
			{
				//Console.WriteLine("user {0} is unknown.", UserName);
				this.NextModule.LogIn(UserName,Password);
			}
			else
			{
				Console.WriteLine("user {0} has logged in successfully with {1} ", UserName, this.GetType().Name);
			}

		}

		public override bool LogOut(string UserName)
		{
			Console.WriteLine("user {0} was logged out", UserName);
			return true;
		}

		public ICanAuthenticateUsers NextModule { get; set; }
	}
}