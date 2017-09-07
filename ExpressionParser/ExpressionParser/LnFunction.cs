/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 16:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of LnFunction.
	/// </summary>
	public class LnFunction : MathFunction
	{
		public LnFunction()
		{
			Name = "ln";
		}
		
		public override double Eval(double arg)
		{
			return Math.Log(arg);
		}
	}
}
