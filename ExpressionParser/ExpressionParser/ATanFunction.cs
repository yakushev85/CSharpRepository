/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of ATanFunction.
	/// </summary>
	public class ATanFunction : MathFunction
	{
		public ATanFunction()
		{
			Name = "atan";
		}
		
		public override double Eval(double arg)
		{
			return Math.Atan(arg);
		}
	}
}
