/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 14:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of ParserEvaluateException.
	/// </summary>
	public class ParserEvaluateException : Exception
	{
		public ParserEvaluateException(string msg) : base(msg)
		{
		}
	}
}
