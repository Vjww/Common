using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Common
{
    /// <summary>
    /// https://stackoverflow.com/a/2556329
    /// </summary>
    public class HexConversion
    {
        public static byte[] GetStringToBytes(string value)
        {
            var shb = SoapHexBinary.Parse(value);
            return shb.Value;
        }

        public static string GetBytesToString(byte[] value)
        {
            var shb = new SoapHexBinary(value);
            return shb.ToString();
        }
    }
}