/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 28-Jun-16
 * Time: 21:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ExpressionParser
{
	/// <summary>
	/// Description of ParserEval.
	/// </summary>
	public abstract class ParserEval
	{
		private Dictionary<string, double> paramsEq;
		private List<MathFunction> functions;
		private string equation;
		
		public ParserEval()
		{
			paramsEq = new Dictionary<string, double> ();
			functions = new List<MathFunction> ();
		}
	
		protected Dictionary<string, double> GetParamsEq() 
		{
			return paramsEq;
		}
	
		protected List<MathFunction> GetFunctions() 
		{
			return functions;
		}
	
		public void AddVariable(string nameVar, double evalVar)
		{
			paramsEq.Add(nameVar, evalVar);
		}
	
		public void RemoveVariable(String nameVar) 
		{
			paramsEq.Remove(nameVar);
		}
	
		public void AddFunction(MathFunction f) 
		{
			functions.Add(f);
		}
	
		public void RemoveFunction(MathFunction f) 
		{
			functions.Remove(f);
		}
	
		public void AddFunctions(List<MathFunction> fs) 
		{
			functions.AddRange(fs);
		}
	
		public void ClearFunctions() 
		{
			functions.Clear();
		}
	
		public String GetEquation() 
		{
			return equation;
		}

		public void SetEquation(String equation) 
		{
			this.equation = equation;
		}
	
		public abstract double EvalEquation();

	}
}
