/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of ASinFunction.
	/// </summary>
	public class ASinFunction : MathFunction
	{
		public ASinFunction()
		{
			Name = "asin";
		}
		
		public override double Eval(double arg)
		{
			return Math.Asin(arg);
		}
	}
}
