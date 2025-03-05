using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RentManagerInterviewApi.Util.Converters
{

    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private const string DateFormat = "yyyy-MM-dd";

        public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Handle DateTime values
            if (reader.Value is DateTime dateTime)
            {
                return DateOnly.FromDateTime(dateTime);
            }

            // Handle string values
            if (reader.Value is string dateString)
            {
                return DateOnly.ParseExact(dateString, DateFormat, System.Globalization.CultureInfo.InvariantCulture);
            }

            // Handle null or unexpected values
            throw new JsonSerializationException($"Unexpected value when converting to DateOnly: {reader.Value}");
        }

        public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
        {
            // Write the DateOnly value as a formatted string
            writer.WriteValue(value.ToString(DateFormat, System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}
