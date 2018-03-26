using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models.Factories
{
    public class ErrorFactory
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTime, string errorLevel, string message)
        {
            DateTime date = DateTime.ParseExact(dateTime, DateFormat, CultureInfo.InvariantCulture);
            ErrorLevel level = ParseErrorLevel(errorLevel);
            IError error = new Error(date,level,message);

            return error;
        }

        private ErrorLevel ParseErrorLevel(string errorLevel)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), errorLevel);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Invalid ErrorLevel Type!", e);
            }

        }
    }
}
