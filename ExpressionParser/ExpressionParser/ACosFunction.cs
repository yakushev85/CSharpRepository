/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of ACosFunction.
	/// </summary>
	public class ACosFunction : MathFunction
	{
		public ACosFunction()
		{
			Name = "acos";
		}
		
		public override double Eval(double arg)
		{
			return Math.Acos(arg);
		}
	}
}
