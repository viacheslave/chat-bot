using Newtonsoft.Json;

namespace Bot.Common.Serialization
{
	public static class JsonStringExtensions
	{
		public static string ToJsonSnakeCase(this object obj)
		{
			return JsonConvert.SerializeObject(obj, SerializationConfigurationHelper.CreateJsonSnakeCaseSerializerSettings());
		}

		public static T FromJsonSnakeCase<T>(this string json)
		{
			return JsonConvert.DeserializeObject<T>(json, SerializationConfigurationHelper.CreateJsonSnakeCaseSerializerSettings());
		}
	}
}
