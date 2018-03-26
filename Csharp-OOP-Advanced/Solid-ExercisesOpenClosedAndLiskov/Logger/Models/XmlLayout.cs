using System;
using System.Globalization;
using Logger.Models.Contracts;

namespace Logger.Models
{
    public class XmlLayout : ILayout
    {
        private const string DateFormat = "HH:mm:ss dd-MM-yyyy";

        private string Format = "<log>" +
                                Environment.NewLine + "\t<date>{0}</date>" +
                                Environment.NewLine + "\t<level>{1}</level>" +
                                Environment.NewLine + "\t<message>{2}</message>" +
                                Environment.NewLine +
                                "</log>";
        public string FormatError(IError error)
        {
            return $"{string.Format(Format, error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture), error.Level, error.Message)}";
        }
    }
}
