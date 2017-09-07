/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 14:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of BadNumberEvaluateException.
	/// </summary>
	public class BadNumberEvaluateException : Exception
	{
		public BadNumberEvaluateException(string msg) : base(msg)
		{
		}
	}
}
