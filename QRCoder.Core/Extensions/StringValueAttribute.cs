﻿using System;

namespace QRCoder.Core.Extensions
{
    /// <summary>
    /// Used to represent a string value for a value in an enum
    /// </summary>
    public class StringValueAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// Holds the alue in an enum
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion Properties

        /// <summary>
        /// Init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
    }

    /// <summary>
    /// CustomExtensions
    /// </summary>
    public static class CustomExtensions
    {
        /// <summary>
        /// Will get the string value for a given enum's value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attr = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            return attr.Length > 0 ? attr[0].StringValue : null;
        }
    }
}