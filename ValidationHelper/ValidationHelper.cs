
namespace ValidationHelper
{
    /// <summary>
    /// Global class providing Validation methods.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Returns the boolean representation of an object or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        public static bool GetBoolean(object value, bool defaultValue)
        {
            if (IsNull(value))
                return defaultValue;

            if (IsBoolean(value))
                return Convert.ToBoolean(value);

            if (IsStringBoolean(value as string))
                return GetBooleanFromString(value.ToString(), defaultValue);

            bool flag;
            try
            {
                flag = Convert.ToBoolean(value);
            }
            catch
            {
                return defaultValue;
            }
            return flag;
        }

        /// <summary>
        /// Returns the DateTime representation of an object or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        public static DateTime GetDateTime(object value, DateTime defaultValue)
        {
            if (IsNull(value))
                return defaultValue;

            if (IsDateTime(value))
                return Convert.ToDateTime(value);

            DateTime dateTime;
            try
            {
                dateTime = DateTime.Parse(value.ToString());
            }
            catch
            {
                dateTime = defaultValue;
            }
            return dateTime;
        }


        /// <summary>
        /// Returns the decimal representation of an object or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        public static decimal GetDecimal(object value, decimal defaultValue)
        {
            if (!IsDecimal(value))
                return defaultValue;

            return decimal.TryParse(Convert.ToString(value), out decimal number)
                ? number
                : defaultValue;
        }

        /// <summary>
        /// Returns the double representation of an object or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        public static double GetDouble(object value, double defaultValue)
        {
            if (!IsDouble(value))
                return defaultValue;

            return double.TryParse(Convert.ToString(value), out double number)
                ? number
                : defaultValue;
        }

        /// <summary>
        /// Returns the GUID representation of an object or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        public static Guid GetGuid(object value, Guid defaultValue)
        {
            if (!IsGuid(value))
                return defaultValue;

            return new Guid(value.ToString());
        }

        /// <summary>
        /// Returns the integer representation of an object or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        public static int GetInteger(object value, int defaultValue)
        {
            if (!IsInteger(value))
                return defaultValue;

            return int.TryParse(Convert.ToString(value), out int number)
                ? number
                : defaultValue;
        }

        /// <summary>
        /// Returns the long representation of an object or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        public static long GetLong(object value, long defaultValue)
        {
            if (!IsLong(value))
                return defaultValue;

            return long.TryParse(Convert.ToString(value), out long number)
                ? number
                : defaultValue;
        }

        /// <summary>
        /// Returns the string representation of an object or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        public static string GetString(object value, string defaultValue)
        {
            if (ValidationHelper.IsNull(value))
                return defaultValue;

            return Convert.ToString(value);
        }

        /// <summary>
        /// Returns the string representation of an object or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="format">Formatting string</param>
        public static string GetString(object value, string defaultValue, string format)
        {
            if (ValidationHelper.IsNull(format))
                return ValidationHelper.GetString(value, defaultValue);

            if (ValidationHelper.IsNull(value))
                value = defaultValue;

            return string.Format(format, value);
        }

        /// <summary>
        /// Returns true if the object representation matches the Boolean type.
        /// </summary>
        /// <param name="value">Value to check</param>
        public static bool IsBoolean(object value)
        {
            if (IsNull(value))
                return false;

            if (value is bool)
                return true;

            if (IsStringBoolean(value.ToString()))
                return true;

            return false;
        }

        /// <summary>
        /// Returns true if the object representation matches the date time format.
        /// </summary>
        /// <param name="value">Value to check</param>
        public static bool IsDateTime(object value)
        {
            if (IsNull(value))
                return false;

            if (value is DateTime)
                return true;

            return DateTime.TryParse(value.ToString(), out _);
        }

        /// <summary>
        /// Returns true if the object representation matches the Double type.
        /// </summary>
        /// <param name="value">Value to check</param>
        public static bool IsDecimal(object value)
        {
            if (IsNull(value))
                return false;

            if (value is decimal)
                return true;

            return decimal.TryParse(Convert.ToString(value), out _);
        }

        /// <summary>
        /// Returns true if the object representation matches the Double type.
        /// </summary>
        /// <param name="value">Value to check</param>
        public static bool IsDouble(object value)
        {
            if (IsNull(value))
                return false;

            if (value is double)
                return true;

            return double.TryParse(Convert.ToString(value), out _);
        }

        /// <summary>
        /// Returns true if the object representation matches the Guid type.
        /// </summary>
        /// <param name="value">Value to check</param>
        public static bool IsGuid(object value)
        {
            if (IsNull(value))
                return false;

            if (value is Guid)
                return true;

            var stringValue = value.ToString();
            if (stringValue.Length != 36)
                return false;

            Guid guid;
            if (!Guid.TryParse(stringValue, out guid))
                return false;

            return true;
        }

        /// <summary>
        /// Returns true if the object representation matches the Integer type.
        /// </summary>
        /// <param name="value">Value to check</param>
        public static bool IsInteger(object value)
        {
            if (IsNull(value))
                return false;

            return int.TryParse(Convert.ToString(value), out _);
        }

        /// <summary>
        /// Returns true if value is higher than or equal to minimum and lesser than or equal to maximum.
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <param name="value">Value to check</param>
        public static bool IsInRange(int min, int max, int value)
        {
            if (value < min)
                return false;

            return value <= max;
        }

        /// <summary>
        /// Returns true if value is higher than or equal to minimum and lesser than or equal to maximum.
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <param name="value">Value to check</param>
        public static bool IsInRange(double min, double max, double value)
        {
            if (value < min)
                return false;

            return value <= max;
        }

        /// <summary>
        /// Returns true if value is higher than or equal to minimum and lesser than or equal to maximum.
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <param name="value">Value to check</param>
        public static bool IsInRange(decimal min, decimal max, decimal value)
        {
            if (value < min)
                return false;

            return value <= max;
        }

        /// <summary>
        /// Returns true if the object representation matches the Long type.
        /// </summary>
        /// <param name="value">Value to check</param>
        public static bool IsLong(object value)
        {
            if (IsNull(value))
                return false;

            if (value is long)
                return true;

            return long.TryParse(Convert.ToString(value), out _);
        }

        /// <summary>
        /// Returns true if the given value is considered NULL value
        /// </summary>
        /// <param name="value">Value to check</param>
        public static bool IsNull(object value)
        {
            if (value == null)
                return true;

            return value == DBNull.Value;
        }

        /// <summary>
        /// Returns true if the given value is considered NULL value
        /// </summary>
        /// <param name="value">Value to check</param>
        private static bool IsStringBoolean(string value)
        {
            if (IsNull(value))
                return false;

            var lowerInvariant = value.ToLowerInvariant();
            if (lowerInvariant == "true" || lowerInvariant == "1")
                return true;

            if (lowerInvariant == "false" || lowerInvariant == "0")
                return true;

            return false;
        }

        /// <summary>
        /// Returns the boolean representation of a string or default value if not.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        private static bool GetBooleanFromString(string value, bool defaultValue)
        {
            if (IsNull(value))
                return defaultValue;

            var lowerInvariant = value.ToLowerInvariant();
            if (lowerInvariant == "true" || lowerInvariant == "1")
                return true;

            if ((lowerInvariant == "false") || (lowerInvariant == "0"))
                return false;

            return defaultValue;
        }
    }
}
