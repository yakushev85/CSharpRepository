/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 28-Jun-16
 * Time: 20:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Expression Parser is testing...");
			Console.WriteLine("===============================================");
			ParserEvalTest parserTest = new ParserEvalTest();
			parserTest.testEquationWithParams();
			parserTest.testEquatoinWithOutParams();
			parserTest.testDivByZero();
			parserTest.testInnerAndPiVariable();
			parserTest.testBigDouble();
			parserTest.testEmpty();
			parserTest.testWrong();
			Console.ReadKey(true);
		}
	}
}