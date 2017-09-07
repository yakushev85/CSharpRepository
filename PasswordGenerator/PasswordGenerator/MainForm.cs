/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 04-Jul-16
 * Time: 20:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordGenerator
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private PasswordGenerator passwordGenerator;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			passwordGenerator = new PasswordGenerator();
		}
		
		void ButtonGenerateClick(object sender, EventArgs e)
		{
			passwordGenerator.Count = (int) numericUpDownCount.Value;
			passwordGenerator.Length =  (int) numericUpDownLength.Value;
			passwordGenerator.HasAlphas = checkBoxAlphas.Checked;
			passwordGenerator.HasDigits = checkBoxDigits.Checked;
			
			if (passwordGenerator.IsEmptyAlphabet()) {
				MessageBox.Show("Please select Use a-zA-Z or Use digits!", "Empty Alphabet",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			List<string> resList = passwordGenerator.GenerateAll();
			richTextBoxRes.Clear();
			
			foreach (string item in resList)
			{
				richTextBoxRes.AppendText(item+"\n");
			}
		}
	}
}
