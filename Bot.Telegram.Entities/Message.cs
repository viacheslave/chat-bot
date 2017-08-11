namespace Bot.Telegram.Entities
{
	public class Message
	{
		public long MessageId { get; set; }
		public User From { get; set; }
		public long Date { get; set; }
		public Chat Chat { get; set; }
		public string Text { get; set; }
	}
}
