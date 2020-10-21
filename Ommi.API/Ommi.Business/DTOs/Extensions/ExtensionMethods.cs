using System.Collections.Generic;

namespace Ommi.Business.DTOs.Extensions
{
	public static class ExtensionMethods
	{
		public static string ConvertToString(this List<bool> boolList)
		{
			string result = "";
			foreach (bool step in boolList)
			{
				if (step == true)
					result = result + "1";
				else
					result = result + "0";
			}

			return result;
		}

		public static List<bool> ConvertToBoolList(this string boolString)
		{
			List<bool> list = new List<bool>();
			foreach (char character in boolString)
			{
				bool boolToAdd;
				if (character == '0')
					boolToAdd = false;
				else if (character == '1')
					boolToAdd = true;
				else
					throw new System.Exception("Found character in steps string that isn't 0 nor 1.");

				list.Add(boolToAdd);
			}

			return list;
		}
	}
}
