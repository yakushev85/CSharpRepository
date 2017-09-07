/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of CosFunction.
	/// </summary>
	public class CosFunction : MathFunction
	{
		public CosFunction()
		{
			Name = "cos";
		}
		
		public override double Eval(double arg)
		{
			return Math.Cos(arg);
		}
	}
}
