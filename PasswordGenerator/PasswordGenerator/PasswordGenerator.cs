/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 04-Jul-16
 * Time: 21:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordGenerator
{
	/// <summary>
	/// Description of PasswordGenerator.
	/// </summary>
	public class PasswordGenerator
	{
		private const string ALPHAS = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
		private	const string DIGITS = "0123456789";
		private Random random;
		
		public PasswordGenerator()
		{
			Count = 4;
			Length = 8;
			HasAlphas = true;
			HasDigits = true;
			random = new Random();
		}
		
		public int Count { get; set; }
		public int Length { get; set; }
		public bool HasAlphas { get; set; }
		public bool HasDigits { get; set; } 
		
		public bool IsEmptyAlphabet ()
		{
			return !(HasAlphas || HasDigits);
		}
		
		private string GenerateSingle()
		{
			string alphabet = "";
			StringBuilder resPassword = new StringBuilder();
				
			if (HasAlphas) alphabet += ALPHAS;
			if (HasDigits) alphabet += DIGITS;
			
			for (int i=0;i<Length;i++)
			{
				resPassword.Append(alphabet[random.Next(0, alphabet.Length)]);
			}
			
			return resPassword.ToString();
		}
		
		public List<string> GenerateAll() 
		{
			List<string> resList = new List<string>();
			for (int i=0;i<Count;i++)
			{
				resList.Add(GenerateSingle());
			}
			
			return resList;
		}
	}
}
