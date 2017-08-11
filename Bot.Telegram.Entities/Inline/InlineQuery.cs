namespace Bot.Telegram.Entities
{
	public class InlineQuery
	{
		public string Id { get; set; }
		public User From { get; set; }
		public Location Location { get; set; }
		public string Query { get; set; }
		public string Offset { get; set; }
	}
}
