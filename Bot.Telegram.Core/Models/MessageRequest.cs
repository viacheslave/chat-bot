namespace Bot.Telegram.Core.Models
{
	public class MessageRequest
	{
		public long ChatId { get; set; }
		public string Text { get; set; }
		public string ParseMode { get; set; }
	}
}
