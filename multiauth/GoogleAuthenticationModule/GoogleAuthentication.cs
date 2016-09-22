﻿namespace GoogleAuthenticationModule
{
	using System;

	using AuthenticationModule;

	public class GoogleAuthentication : ICanAuthenticateUsers
	{
		public  bool LogIn(string UserName, string Password)
		{
			Console.WriteLine( "{0}: ", this.GetType().Name );
			var logIn = UserName == "goog" && Password == "g00gl3";
			if (!logIn)
			{
				Console.WriteLine("user {0} is unknown.", UserName);

                //<Petru>
                if (this.NextModule != null)
                {
                    logIn = this.NextModule.LogIn(UserName, Password);
                }
                else
                {
                    Console.WriteLine("End of chain.. sorry bro");
                }
                //</Petru>

			}
			return logIn;
		}

		public bool LogOut(string UserName)
		{
			Console.WriteLine( "user {0} was logged out", UserName );
			return true;
		}

		public ICanAuthenticateUsers NextModule { get; set; }
	}
}