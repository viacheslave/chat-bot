using Bot.Common;

namespace Bot.Telegram.Modules
{
	class ModulesConfig : AppConfig
	{
		public string OpenWeatherUrl => GetAppConfigValue("openweather.api.url");
		public string OpenWeatherKey => GetAppConfigValue("openweather.key");
	}
}
