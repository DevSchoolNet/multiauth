namespace GoogleAuthenticationModule
{
	using System;

	using AuthenticationModule;

	public class GoogleAuthentication : ICanAuthenticateUsers
	{
		public  void LogIn(string UserName, string Password)
		{
			Console.WriteLine( "{0} is trying to log the user", this.GetType().Name );
			var logIn = UserName == "goog" && Password == "g00gl3";
			if (!logIn)
			{
				Console.WriteLine("user {0} is unknown and couldn't be identified by any module", UserName);
			}
			else
			{
				Console.WriteLine("user {0} has logged in successfully with {1} ", UserName, this.GetType().Name);
			}
		}

		public bool LogOut(string UserName)
		{
			Console.WriteLine( "user {0} was logged out", UserName );
			return true;
		}

		public ICanAuthenticateUsers NextModule { get; set; }
	}
}