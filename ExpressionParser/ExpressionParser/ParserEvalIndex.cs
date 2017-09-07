/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 28-Jun-16
 * Time: 21:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ExpressionParser
{
	/// <summary>
	/// Description of ParserEvalIndex.
	/// </summary>
	public class ParserEvalIndex : ParserEval
	{
		public ParserEvalIndex() : base()
		{
			SetEquation("0.0");
		}
		
		public ParserEvalIndex(string eq) : base()
		{
			SetEquation(eq);
		}
		
		
		private abstract class ItemEquation 
		{
			public abstract Object GetValueItem();
		}
		
		private class ItemEquationOperator : ItemEquation 
		{
			private Char value;
		
			public ItemEquationOperator(char v) 
			{
				value = v;
			}
		
			public override Object GetValueItem() 
			{
				return value;
			}
			
			public override string ToString()
			{
				return value.ToString();
			}

		}
	
		private class ItemEquationDigit : ItemEquation
		{
			private Double value;
		
			public ItemEquationDigit(double v) 
			{
				value = v;
			}
	
			public override Object GetValueItem() 
			{
			return value;
			}
			
			public override string ToString()
			{
				return value.ToString();
			}

		}
	
		private class ItemEquationLixema : ItemEquation 
		{
			private String value;
		
			public ItemEquationLixema(string v) 
			{
				value = v;
			}
		
			public override Object GetValueItem() 
			{
				return value;
			}
			
			public override string ToString()
			{
				return value.ToString();
			}

		}

		private List<ItemEquation> StringEqToArrayEq(string eq) 
		{
			List<ItemEquation> itemsEq = new List<ItemEquation> ();
			
			ItemEquation lastItem;
			string lixema = "";
			string digit = "";
			
			for (int i=0;i<eq.Length;i++) 
			{
				char ch = eq[i];
				
				switch (ch) 
				{
					case '(':
					case ')':
					case '+':
					case '-':
					case '*':
					case '/':
					case '^':
						if (lixema.Length > 0) 
						{
							lastItem = new ItemEquationLixema(lixema);
							itemsEq.Add(lastItem);
							lixema = "";
						}
						
						if (digit.Length > 0) 
						{
							lastItem = new ItemEquationDigit(Double.Parse(digit));
							itemsEq.Add(lastItem);
							digit = "";
						}
						
						lastItem = new ItemEquationOperator(ch);
						itemsEq.Add(lastItem);
					break;
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
					case '.':
						if (lixema.Length > 0) 
						{
							lastItem = new ItemEquationLixema(lixema);
							itemsEq.Add(lastItem);
							lixema = "";
						}
						
						digit = digit + ch;
					break;
					default:
						if (digit.Length > 0) 
						{
							lastItem = new ItemEquationDigit(Double.Parse(digit));
							itemsEq.Add(lastItem);
							digit = "";
						}
						
						if ((ch != ' ')&&(ch != '\t')) 
						{
							lixema = lixema + ch;
						}
					break;
				}
			}
			
			if (lixema.Length > 0) 
			{
				lastItem = new ItemEquationLixema(lixema);
				itemsEq.Add(lastItem);
			}
			
			if (digit.Length > 0) 
			{
				lastItem = new ItemEquationDigit(Double.Parse(digit));
				itemsEq.Add(lastItem);
			}
			
			return itemsEq;
		}
		
		public override double EvalEquation() 
		{
			List<ItemEquation> itemsEq = StringEqToArrayEq(GetEquation());
			Dictionary<string, double> variables = GetParamsEq();
			
			if (itemsEq.Count < 3) 
				throw new ParserEvaluateException("Expression is too short!");
			
			//set variables
			foreach (ItemEquation item in itemsEq.ToArray())
			{
				int indexItem = itemsEq.IndexOf(item);
				
				if (item is ItemEquationLixema) 
				{
					ItemEquationLixema itemLex = (ItemEquationLixema) item;
					string lixemaStr = (string) itemLex.GetValueItem();
					
					if (variables.ContainsKey(lixemaStr))
					{
						double evalVar = variables[lixemaStr];
						ItemEquationDigit itemDigit = new ItemEquationDigit(evalVar);
						itemsEq[indexItem] = itemDigit;
					}
				}
			}
			
			
			//eval equation
			while (true) 
			{
				//find end breaks
				int indexEndBreak = -1;
				int indexBegBreak = -1;
				foreach (ItemEquation itemEq in itemsEq) 
				{
					if (itemEq is ItemEquationOperator) 
					{
						ItemEquationOperator itemOp = (ItemEquationOperator) itemEq;
						if ((char) itemOp.GetValueItem() == ')')
						{
							indexEndBreak = itemsEq.IndexOf(itemEq);
							break;
						}
						else if ((char) itemOp.GetValueItem() == '(')
						{
							indexBegBreak = itemsEq.IndexOf(itemEq);
						}
					}
				}
				
				if ((indexEndBreak < 0) && (indexBegBreak < 0)) 
				{
					return EvalEquationWBReaks(itemsEq);
				}
				
				if (indexBegBreak < 0) 
				{
					throw new ParserEvaluateException("Not found (:" + ArrayEqToString(itemsEq));
				}
				
				if (indexEndBreak < 0) 
				{
					throw new ParserEvaluateException("Not found ):" + ArrayEqToString(itemsEq));
				}
				
				List<ItemEquation> itemsEqWBreaks = new List<ItemEquation> ();
				for (int i=indexBegBreak+1;i<=indexEndBreak-1;i++) 
				{
					itemsEqWBreaks.Add(itemsEq[i]);
				}
				
				double valueWBreaks = EvalEquationWBReaks(itemsEqWBreaks);
				
				ItemEquationDigit itemDigit = new ItemEquationDigit(valueWBreaks);
				
				itemsEq.Insert(indexBegBreak, itemDigit);
				indexBegBreak++;
				
				while (true) 
				{
					if (itemsEq[indexBegBreak] is ItemEquationOperator)
					{
						ItemEquationOperator itemOp = (ItemEquationOperator) itemsEq[indexBegBreak];
						if ((char) itemOp.GetValueItem() == ')')
						{
							itemsEq.RemoveAt(indexBegBreak);
							break;
						}
						else 
						{
							itemsEq.RemoveAt(indexBegBreak);
						}
					}
					else 
					{
						itemsEq.RemoveAt(indexBegBreak);
					}
				}
			}
		}
	
		private void CheckNumber(double d) 
		{
			if (Double.IsInfinity(d))   
			{
				throw new BadNumberEvaluateException("Infinite result!");
			}
		}
		
		private double EvalEquationWBReaks(List<ItemEquation> eqWBreaks) 
		{
			List<MathFunction> functions = this.GetFunctions();
			//eval equation
			bool isEvalExec = true;
			while (isEvalExec) 
			{
				string lastEqStr = ArrayEqToString(eqWBreaks);
				
				//find functions
				bool isFoundedFunc = true;
						
				while (isFoundedFunc) 
				{
					isFoundedFunc = false;
					foreach (ItemEquation item in eqWBreaks) 
					{
						if (item is ItemEquationLixema) 
						{
							ItemEquationLixema itemLex = (ItemEquationLixema) item;
							int indexLex = eqWBreaks.IndexOf(item);
														
							if ((indexLex<eqWBreaks.Count-1) && (eqWBreaks[indexLex+1] is ItemEquationDigit)) 
							{
								double valueA = (double) ((ItemEquationDigit) eqWBreaks[indexLex+1]).GetValueItem();
								string funcStr = (string) itemLex.GetValueItem();
										
								foreach (MathFunction function in functions) 
								{
									if (string.Equals(funcStr, function.Name, StringComparison.OrdinalIgnoreCase)) 
									{
										double resultFA = function.Eval(valueA);
										CheckNumber(resultFA);
										ItemEquationDigit itemResFA = new ItemEquationDigit(resultFA);
												
										eqWBreaks[indexLex] = itemResFA;
										eqWBreaks.RemoveAt(indexLex+1);
												
										isFoundedFunc = true;
										break;
									}
								}
										
								break;
							}
						}
					}
				}
						
				//find ^
				bool isFoundPower = true;
				
				while (isFoundPower) 
				{
					isFoundPower = false;
					foreach (ItemEquation item in eqWBreaks) 
					{
						if (item is ItemEquationOperator) {
							ItemEquationOperator itemOp = (ItemEquationOperator) item;
							int indexOp = eqWBreaks.IndexOf(item);
							
							if (((char) itemOp.GetValueItem() == '^') && (indexOp>0) &&
							    (eqWBreaks[indexOp-1] is ItemEquationDigit)
							    && (eqWBreaks[indexOp+1] is ItemEquationDigit))
							{
								double valueA = (double) ((ItemEquationDigit) eqWBreaks[indexOp-1]).GetValueItem();
								double valueB = (double) ((ItemEquationDigit) eqWBreaks[indexOp+1]).GetValueItem();
								double resAB = Math.Pow(valueA,valueB);
								CheckNumber(resAB);
								
								ItemEquationDigit itemResAB = new ItemEquationDigit(resAB);
								
								eqWBreaks[indexOp-1] = itemResAB;
								eqWBreaks.RemoveAt(indexOp);
								eqWBreaks.RemoveAt(indexOp);
								
								isFoundPower = true;
								break;
							}
						}
					}
				}
				
				//find * /
				bool isFoundedMD = true;
				
				while (isFoundedMD) 
				{
					isFoundedMD = false;
					foreach (ItemEquation item in eqWBreaks) 
					{
						if (item is ItemEquationOperator) 
						{
							ItemEquationOperator itemOp = (ItemEquationOperator) item;
							int indexOp = eqWBreaks.IndexOf(item);
							
							if (((char) itemOp.GetValueItem() == '*') && (indexOp>0) && (indexOp<eqWBreaks.Count-1) &&
							    (eqWBreaks[indexOp-1] is ItemEquationDigit)
							    && (eqWBreaks[indexOp+1] is ItemEquationDigit)) 
							{
								double valueA = (double) ((ItemEquationDigit) eqWBreaks[indexOp-1]).GetValueItem();
								double valueB = (double) ((ItemEquationDigit) eqWBreaks[indexOp+1]).GetValueItem();
								double resAB = valueA*valueB;
								
								ItemEquationDigit itemResAB = new ItemEquationDigit(resAB);
								
								eqWBreaks[indexOp-1] = itemResAB;
								eqWBreaks.RemoveAt(indexOp);
								eqWBreaks.RemoveAt(indexOp);
								
								isFoundedMD = true;
								break;
							}
							
							if (((char) itemOp.GetValueItem() == '/') && (indexOp>0) && (indexOp<eqWBreaks.Count-1) &&
							    (eqWBreaks[indexOp-1] is ItemEquationDigit)
							    && (eqWBreaks[indexOp+1] is ItemEquationDigit)) 
							{
								double valueA = (double) ((ItemEquationDigit) eqWBreaks[indexOp-1]).GetValueItem();
								double valueB = (double) ((ItemEquationDigit) eqWBreaks[indexOp+1]).GetValueItem();
								if (valueB == 0) {
									throw new BadNumberEvaluateException("Divine by zero!");
								}
								
								double resAB = valueA/valueB;
								
								ItemEquationDigit itemResAB = new ItemEquationDigit(resAB);
								
								eqWBreaks[indexOp-1] = itemResAB;
								eqWBreaks.RemoveAt(indexOp);
								eqWBreaks.RemoveAt(indexOp);
								
								isFoundedMD = true;
								break;
							}
						}
					}
				}
				
				//find + -
				bool isFoundedMP = true;
				
				while (isFoundedMP) 
				{
					isFoundedMP = false;
					foreach (ItemEquation item in eqWBreaks) 
					{
						if (item is ItemEquationOperator) 
						{
							ItemEquationOperator itemOp = (ItemEquationOperator) item;
							int indexOp = eqWBreaks.IndexOf(item);
							
							if (((char) itemOp.GetValueItem() == '+') && (indexOp>0) && (indexOp<eqWBreaks.Count-1) &&
							    (eqWBreaks[indexOp-1] is ItemEquationDigit)
							    && (eqWBreaks[indexOp+1] is ItemEquationDigit)) 
							{
								double valueA = (double) ((ItemEquationDigit) eqWBreaks[indexOp-1]).GetValueItem();
								double valueB = (double) ((ItemEquationDigit) eqWBreaks[indexOp+1]).GetValueItem();
								double resAB = valueA+valueB;
								
								ItemEquationDigit itemResAB = new ItemEquationDigit(resAB);
								
								eqWBreaks[indexOp-1] = itemResAB;
								eqWBreaks.RemoveAt(indexOp);
								eqWBreaks.RemoveAt(indexOp);
								
								isFoundedMP = true;
								break;
							}
							
							if (((char) itemOp.GetValueItem() == '-') && (indexOp>0) && (indexOp<eqWBreaks.Count-1) &&
							    (eqWBreaks[indexOp-1] is ItemEquationDigit)
							    && (eqWBreaks[indexOp+1] is ItemEquationDigit)) 
							{
								double valueA = (double) ((ItemEquationDigit) eqWBreaks[indexOp-1]).GetValueItem();
								double valueB = (double) ((ItemEquationDigit) eqWBreaks[indexOp+1]).GetValueItem();
								double resAB = valueA-valueB;
								
								ItemEquationDigit itemResAB = new ItemEquationDigit(resAB);
								
								eqWBreaks[indexOp-1] = itemResAB;
								eqWBreaks.RemoveAt(indexOp);
								eqWBreaks.RemoveAt(indexOp);
								
								isFoundedMP = true;
								break;
							}
						}
					}
				}
						
				isEvalExec = (eqWBreaks.Count > 1) && (!ArrayEqToString(eqWBreaks).Equals(lastEqStr));
			}
			
			if ((eqWBreaks.Count == 2) && (eqWBreaks[0] is ItemEquationOperator) &&
			    (eqWBreaks[1] is ItemEquationDigit)) 
			{
				ItemEquationOperator itemOp = (ItemEquationOperator) eqWBreaks[0];
				if ((char) itemOp.GetValueItem() == '-')
				{
					double valueRes = (-1) * ((double) ((ItemEquationDigit) eqWBreaks[1]).GetValueItem());
					eqWBreaks.RemoveAt(0);
					eqWBreaks.RemoveAt(0);
					
					eqWBreaks.Add(new ItemEquationDigit(valueRes));
				}
			}
			
			if (eqWBreaks.Count > 1) 
				throw new ParserEvaluateException("Wrong expression:" + ArrayEqToString(eqWBreaks));
			
			if (eqWBreaks.Count == 0)
				throw new ParserEvaluateException("Wrong expression!");
			
			ItemEquation resItem = eqWBreaks[0];
			
			if (!(resItem is ItemEquationDigit)) 
			{
				throw new ParserEvaluateException("Bad result:" + ArrayEqToString(eqWBreaks));
			}
			
			ItemEquationDigit itemDigit = (ItemEquationDigit) resItem;
				
			return (double) itemDigit.GetValueItem();
		}
		
		private String ArrayEqToString(List<ItemEquation> arrEq) 
		{
			String res = "";
			
			foreach (ItemEquation item in arrEq) 
			{
				res = res + item.ToString();
			}
			
			return res;
		}		
	}
}
