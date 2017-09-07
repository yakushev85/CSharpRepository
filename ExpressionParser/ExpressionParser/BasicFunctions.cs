/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ExpressionParser
{
	/// <summary>
	/// Description of BasicFunctions.
	/// </summary>
	public class BasicFunctions
	{
		private static List<MathFunction> basicFunctions;
		
		public static List<MathFunction> GetInstance()
		{
			if (basicFunctions == null) {
				basicFunctions = new List<MathFunction> ();
				basicFunctions.Add(new SinFunction());
				basicFunctions.Add(new CosFunction());
				basicFunctions.Add(new TanFunction());
				basicFunctions.Add(new ASinFunction());
				basicFunctions.Add(new ACosFunction());
				basicFunctions.Add(new ATanFunction());
				basicFunctions.Add(new SqrtFunction());
				basicFunctions.Add(new LnFunction());
				basicFunctions.Add(new ExpFunction());
			}

			
			return basicFunctions;
		}
	}
}
