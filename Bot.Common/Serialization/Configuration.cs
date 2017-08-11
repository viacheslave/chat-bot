using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bot.Common.Serialization
{
	public static class SerializationConfigurationHelper
	{
		public static JsonSerializerSettings CreateJsonSnakeCaseSerializerSettings()
		{
			return new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				ContractResolver = new DefaultContractResolver
				{
					NamingStrategy = new SnakeCaseNamingStrategy()
				},
				Formatting = Formatting.Indented
			};
		}
	}
}
