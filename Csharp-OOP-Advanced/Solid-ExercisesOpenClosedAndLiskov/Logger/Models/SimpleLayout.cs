using System.Globalization;
using Logger.Models.Contracts;

namespace Logger.Models
{
    public class SimpleLayout:ILayout
    {
        // DateTime - Level - Message
        const string DateFormat = "M/d/yyyy h:mm:ss tt";
        const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            return $"{string.Format(Format, error.DateTime.ToString(DateFormat,CultureInfo.InvariantCulture), error.Level, error.Message)}";
        }
    }
}
