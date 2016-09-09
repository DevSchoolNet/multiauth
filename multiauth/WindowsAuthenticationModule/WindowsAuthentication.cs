using System.Runtime.InteropServices;

namespace WindowsAuthenticationModule
{
	using System;

	using AuthenticationModule;

	public class WindowsAuthentication : ICanAuthenticateUsers
	{
		public void LogIn(string UserName, string Password)
		{
			Console.WriteLine( "{0} is trying to log the user ", this.GetType().Name );
			var logIn = UserName == "gigel" && Password == "g!g3l3";

		    if (!logIn && this.NextModule != null)
		    {
		        //Console.WriteLine("user {0} is unknown.", UserName );
		        this.NextModule.LogIn(UserName, Password);
		    }
		    else
		    {
		        Console.WriteLine("user {0} has logged in successfully with {1} ",UserName,this.GetType().Name);
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