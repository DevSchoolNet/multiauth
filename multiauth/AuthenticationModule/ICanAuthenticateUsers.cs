namespace AuthenticationModule
{
	public interface ICanAuthenticateUsers
	{
		void LogIn(string UserName, string Password);
		bool LogOut(string UserName);

		ICanAuthenticateUsers NextModule { get; set; }

	}
}