/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 03-Jul-16
 * Time: 17:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ExpressionParser
{
	/// <summary>
	/// Description of ParserEvalTest.
	/// </summary>
	public class ParserEvalTest 
	{
		private static double DELTA = 0.000001;
		
		private static string TXT_TESTEQUATION1_W_PARAMS = "   (  2*1.1*sqrt(next_test-some_test*2)+(sin(1))^2+"
				+ "(cos(1))^2-atan(0^5)+tan(0.0)+asin(0)+acos(1)+ln(1.0)+exp(0)	)  /  4.2";
		private static string TXT_PARAM1 = "some_test";
		private static double VALUE_PARAM1 = 22.1;
		private static string TXT_PARAM2 = "next_test";
		private static double VALUE_PARAM2 = 45.9;
		
		private static string TXT_TESTEQUATION2__WOUT_PARAMS = "sin(456.7	/cos(3.45))*tan(   89.9)+asin(acos(0.56)*"
				+ "asin(0.9)/1000)*atan(9.9)-(ln(234))^      (exp(1.1))      ";
		
		private static string TXT_TESTEQUATION3_DIVBYZERO = "(1/x)*cos(x*pi)+x+1";
		private static string TXT_PARAM3 = "x";
		private static double VALUE_PARAM3 = 0;
		
		private static string TXT_TESTEQUATION4_INNER ="sin(cos(tan(sqrt(0)+1)+2*pi)+3*pi)";
		private static string TXT_PARAMPI = "pi";
		
		private static string TXT_TESTEQUATION4_BIGDOUBLE = "sqrt(761782.78217482*2.76237)+sin(1.3627186472)";
		
		private static string TXT_TESTEQUATION5_WRONG = "sin())((";
		
		private ParserEval parserEval;
		
	    public ParserEvalTest() 
	    {
	        parserEval = new ParserEvalIndex();
	        parserEval.AddFunctions(BasicFunctions.GetInstance());
	    }
	
	    public void testEquationWithParams() 
	    {
	    	parserEval.SetEquation(TXT_TESTEQUATION1_W_PARAMS);
	    	parserEval.AddVariable(TXT_PARAM1, VALUE_PARAM1);
	    	parserEval.AddVariable(TXT_PARAM2, VALUE_PARAM2);
	    	double expectedValue = (2*1.1*Math.Sqrt(VALUE_PARAM2-VALUE_PARAM1*2)+Math.Pow((Math.Sin(1)),2)+Math.Pow((Math.Cos(1)),2)
					-Math.Atan(Math.Pow(0,5))+Math.Tan(0.0)+Math.Asin(0)+Math.Acos(1)+Math.Log(1.0)+Math.Exp(0))/4.2;
	    	
	    	if (Math.Abs(expectedValue-parserEval.EvalEquation())<DELTA)
	    	{
	    		Console.WriteLine("testEquationWithParams is passed.");
	    	}
	    	else
	    	{
	    		Console.WriteLine("testEquationWithParams is failed.");
	    	}
	    }
	    
	    public void testEquatoinWithOutParams() 
	    {
	    	parserEval.SetEquation(TXT_TESTEQUATION2__WOUT_PARAMS);
	    	double expectedValue = Math.Sin(456.7/Math.Cos(3.45))*Math.Tan(89.9)+Math.Asin(Math.Acos(0.56)*Math.Asin(0.9)/1000)
					*Math.Atan(9.9)-Math.Pow(Math.Log(234),Math.Exp(1.1));
	    	
	    	if (Math.Abs(expectedValue-parserEval.EvalEquation())<DELTA)
	    	{
	    		Console.WriteLine("testEquatoinWithOutParams is passed.");
	    	}
	    	else
	    	{
	    		Console.WriteLine("testEquatoinWithOutParams is failed.");
	    	}
	    }
	    
	    public void testDivByZero() 
	    {
	    	parserEval.SetEquation(TXT_TESTEQUATION3_DIVBYZERO);
	    	parserEval.AddVariable(TXT_PARAM3, VALUE_PARAM3);
	    	
	    	try 
	    	{
	    		parserEval.EvalEquation();
	    	} 
	    	catch (BadNumberEvaluateException e) 
	    	{
	    		Console.WriteLine("testDivByZero is passed. Founded exception: {0}",e.Message);
	    		return;
	    	}
	    	
	    	Console.WriteLine("testDivByZero is failed.");
	    }
	    
	    public void testInnerAndPiVariable() 
	    {
	    	parserEval.SetEquation(TXT_TESTEQUATION4_INNER);
	    	parserEval.AddVariable(TXT_PARAMPI, Math.PI);
	    	double expectedValue = Math.Sin(Math.Cos(Math.Tan(Math.Sqrt(0)+1)+2*Math.PI)+3*Math.PI);
	    	
	    	if (Math.Abs(expectedValue-parserEval.EvalEquation())<DELTA)
	    	{
	    		Console.WriteLine("testInnerAndPiVariable is passed.");
	    	}
	    	else
	    	{
	    		Console.WriteLine("testInnerAndPiVariable is failed.");
	    	}
	    }
	    
	    public void testBigDouble() 
	    {
	    	parserEval.SetEquation(TXT_TESTEQUATION4_BIGDOUBLE);
	    	double expectedValue = Math.Sqrt(761782.78217482*2.76237)+Math.Sin(1.3627186472);
	    	
	    	if (Math.Abs(expectedValue-parserEval.EvalEquation())<DELTA)
	    	{
	    		Console.WriteLine("testBigDouble is passed.");
	    	}
	    	else
	    	{
	    		Console.WriteLine("testBigDouble is failed.");
	    	}
	    }
	    
	    public void testEmpty() 
	    {
	    	try 
	    	{
		    	parserEval.SetEquation("");
		    	parserEval.EvalEquation();
		    	Console.WriteLine("testEmpty is failed.");
	    	} 
	    	catch (ParserEvaluateException e) 
	    	{
	    		Console.WriteLine("testEmpty is passed. Founded exception: {0}",e.Message);
	    	}
	    }
	    
	    public void testWrong() 
	    {
	    	try {
		    	parserEval.SetEquation(TXT_TESTEQUATION5_WRONG);
		    	parserEval.EvalEquation();
		    	Console.WriteLine("testWrong is failed.");
	    	} 
	    	catch (ParserEvaluateException e) 
	    	{
	    		Console.WriteLine("testWrong is passed. Founded exception: {0}",e.Message);
	    	}
	    }
	}

}
