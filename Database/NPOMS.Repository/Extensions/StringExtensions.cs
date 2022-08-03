using System.Security.Cryptography;
using System.Text;

namespace NPOMS.Repository.Extensions
{
	public static class StringExtensions
	{
		public static string GenerateNewCode(string abbreviation)
		{
			int resultSize = 11;
			char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
			var result = new StringBuilder(resultSize);
			byte[] data = new byte[resultSize];
			var crypto = new RNGCryptoServiceProvider(data);
			crypto.GetNonZeroBytes(data);

			foreach (byte item in data)
			{
				result.Append(chars[item % (chars.Length - 1)]);
			}

			return string.Format("{0}/{1}", abbreviation, result.ToString());
		}
	}
}
