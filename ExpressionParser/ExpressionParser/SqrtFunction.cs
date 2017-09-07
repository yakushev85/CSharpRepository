/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of SqrtFunction.
	/// </summary>
	public class SqrtFunction : MathFunction
	{
		public SqrtFunction()
		{
			Name = "sqrt";
		}
		
		public override double Eval(double arg)
		{
			return Math.Sqrt(arg);
		}
	}
}
