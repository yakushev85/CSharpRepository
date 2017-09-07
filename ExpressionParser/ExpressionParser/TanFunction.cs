/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of TanFunction.
	/// </summary>
	public class TanFunction : MathFunction
	{
		public TanFunction()
		{
			Name = "tan";
		}
		
		public override double Eval(double arg)
		{
			return Math.Tan(arg);
		}
	}
}
