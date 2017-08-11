namespace Bot.Common
{
	public interface IAppConfig
	{
		string TelegramApiKey { get; }
		string TelegramApiUrl { get; }
	}
}