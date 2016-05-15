// -----------------------------------------------------------------------
// <copyright file="BinaryConverter.cs" company="Tasko.in">
// -----------------------------------------------------------------------

namespace Tasko.Common
{
    using System;
    using System.Globalization;
    using System.IO;

    /// <summary>
    /// BinaryConverter class - contains useful methods for working with binary format.
    /// </summary>
    public static class BinaryConverter
    {
        /// <summary>
        /// Convert string to byte.
        /// </summary>
        /// <param name="valueToConvert">The value to convert.</param>
        /// <returns>
        /// string converted to binary
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate parameter value before using it", Justification = "validate parameter value before using it.")]
        public static byte[] ConvertStringToByte(string valueToConvert)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(valueToConvert))
                {
                    // Convert string to Guid first to remove any potential hyphens
                    Guid guid = Guid.Parse(valueToConvert);
                    valueToConvert = guid.ToString("N").ToUpper(CultureInfo.InvariantCulture);
                }

                int length = valueToConvert.Length / 2;
                byte[] byteOut = new byte[length];
                for (int i = 0; i < length; i++)
                {
                    byteOut[i] = Convert.ToByte(valueToConvert.Substring(i * 2, 2), 16);
                }

                return byteOut;
            }
            catch (Exception)
            {
                // Create a user exception
                throw;
            }
        }

        /// <summary>
        /// Convert Byte to string.
        /// </summary>
        /// <param name="valueToConvert">The value to convert.</param>
        /// <returns>
        /// converted string
        /// </returns>
        public static string ConvertByteToString(byte[] valueToConvert)
        {
            string hex = BitConverter.ToString(valueToConvert);
            return hex.Replace("-", string.Empty);
        }

        /// <summary>
        /// Generates the GUID.
        /// </summary>
        /// <returns>GUID as string</returns>
        public static string GenerateGuid()
        {
            string guidStr = string.Empty;
            System.Guid guid = System.Guid.NewGuid();
            guidStr = guid.ToString("N");
            guidStr = guidStr.ToUpper(CultureInfo.InvariantCulture);
            return guidStr;
        }

        /// <summary>
        /// Generates the GUID for string.
        /// </summary>
        /// <param name="stringValue">The string value.</param>
        /// <returns>Guid for given string</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", Justification = "we need to port old code as it is, Hence no changes are required")]
        public static Guid GenerateGuidForString(string stringValue)
        {
            Guid guid = new Guid(stringValue);
            return guid;
        }

        /// <summary>
        /// Convert byte array to hex string.
        /// </summary>
        /// <param name="valueToConvert">The value to convert.</param>
        /// <returns>
        /// string converted to hex
        /// </returns>
        public static string ConvertByteToHexString(byte[] valueToConvert)
        {
            string hexString = string.Empty;
            for (int i = 0; i < valueToConvert.Length; i++)
            {
                string byteString = valueToConvert[i].ToString("X", CultureInfo.InvariantCulture);
                if (byteString.Length == 1)
                {
                    // TA 5.5 added a 0 for single length bytestring before it
                    byteString = "0" + byteString;
                }

                hexString += byteString;
            }

            return hexString;
        }

        /// <summary>
        /// Determines whether [is valid GUID] [the specified string value].
        /// </summary>
        /// <param name="valueToConvert">The string value.</param>
        /// <returns>
        /// <c>true</c> if [is valid GUID] [the specified string value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidGuid(string valueToConvert)
        {
            bool isValidGuid = true;
            try
            {
                ConvertStringToByte(valueToConvert);
            }
            catch (Exception)
            {
                isValidGuid = false;

                // do nothing
                throw;
            }

            return isValidGuid;
        }
    }
}
