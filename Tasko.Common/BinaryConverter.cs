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

        /// <summary>
        /// Determines whether [is valid unique identifier] [the specified identifier].
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="IdType">Type of the identifier.</param>
        /// <returns>
        /// <c>true</c> if [is valid GUID] [the specified string value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidGuid(string Id, TaskoEnum.IdType IdType)
        {
            bool isValidGuid = true;
            try
            {
                ConvertStringToByte(Id);
            }
            catch (Exception)
            {
                isValidGuid = false;

                switch (IdType)
                {
                    case TaskoEnum.IdType.CustomerId:
                        throw new UserException("Invalid Customer Id");

                    case TaskoEnum.IdType.VendorId:
                        throw new UserException("Invalid Vendor Id");

                    case TaskoEnum.IdType.UserId:
                        throw new UserException("Invalid User Id");
                    
                    case TaskoEnum.IdType.ServiceId:
                        throw new UserException("Invalid Service Id");
                    
                    case TaskoEnum.IdType.ParentServiceId:
                        throw new UserException("Invalid Parent Service Id");
                    
                    case TaskoEnum.IdType.VendorServiceId:
                        throw new UserException("Invalid Vendor Service Id");
                    
                    case TaskoEnum.IdType.VendorAddressId:
                        throw new UserException("Invalid Vendor Address Id");
                    
                    case TaskoEnum.IdType.AuthCode:
                        throw new UserException("Invalid Auth Code");
                    
                    case TaskoEnum.IdType.SourceAddressId:
                        throw new UserException("Invalid Source Address Id");
                    
                    case TaskoEnum.IdType.DestinationAddressId:
                        throw new UserException("Invalid Destination Address Id");
                    
                    case TaskoEnum.IdType.AddressId:
                        throw new UserException("Invalid Address Id");

                    case TaskoEnum.IdType.VendorDocumentId:
                        throw new UserException("Invalid Vendor Document Id");
                    
                    case TaskoEnum.IdType.TokenCode:
                        throw new UserException("Invalid Token Code");

                    case TaskoEnum.IdType.StateId:
                        throw new UserException("Invalid State Id");

                    case TaskoEnum.IdType.CityId:
                        throw new UserException("Invalid City Id");

                    case TaskoEnum.IdType.RateCardId:
                        throw new UserException("Rate Card Id");
                    default:
                        break;
                }
            }

            return isValidGuid;
        }
    }
}