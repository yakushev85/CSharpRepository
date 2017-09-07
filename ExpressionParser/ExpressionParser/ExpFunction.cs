/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of ExpFunction.
	/// </summary>
	public class ExpFunction : MathFunction
	{
		public ExpFunction()
		{
			Name = "exp";
		}
		
		public override double Eval(double arg)
		{
			return Math.Exp(arg);
		}
	}
}
