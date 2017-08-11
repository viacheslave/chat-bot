namespace Bot.Telegram.Entities
{
	public class Chat
	{
		public long Id { get; set; }
		public string Type { get; set; }
		public string Title { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool AllMembersAreAdministrators { get; set; }
		public ChatPhoto Photo { get; set; }
		public string Description { get; set; }
		public string InviteLink { get; set; }
	}
}
