/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 14:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of MathFunction.
	/// </summary>
	public abstract class MathFunction
	{
		public MathFunction() : base()
		{
		}
		
		public string Name {get; set;}
		
		public abstract double Eval(double arg);
	}
}
