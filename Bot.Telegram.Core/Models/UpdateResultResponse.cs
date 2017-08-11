using Bot.Telegram.Entities;

namespace Bot.Telegram.Core.Models
{
	public class UpdateResultResponse
	{
		public int UpdateId { get; set; }
		public Message Message { get; set; }
	}
}
