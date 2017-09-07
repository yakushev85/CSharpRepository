/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of SinFunction.
	/// </summary>
	public class SinFunction : MathFunction
	{
		public SinFunction()
		{
			Name = "sin";
		}
		
		public override double Eval(double arg)
		{
			return Math.Sin(arg);
		}
	}
}
