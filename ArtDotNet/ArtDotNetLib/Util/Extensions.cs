using System;
using System.Security.Cryptography;

namespace ArtDotNet
{
	public static class Extensions
	{
		public static byte[] Block (this byte[] data, int start, int end)
		{
			var tmp = new byte[end - start];

			for (int i = start; i < end; i++)
				tmp [i] = data [i];

			return tmp;
		}
	}
}

