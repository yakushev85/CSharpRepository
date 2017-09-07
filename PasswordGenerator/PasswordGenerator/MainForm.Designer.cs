/*
 * Created by SharpDevelop.
 * User: Oleksandr
 * Date: 04-Jul-16
 * Time: 20:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PasswordGenerator
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonGenerate = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.richTextBoxRes = new System.Windows.Forms.RichTextBox();
			this.checkBoxDigits = new System.Windows.Forms.CheckBox();
			this.checkBoxAlphas = new System.Windows.Forms.CheckBox();
			this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonGenerate
			// 
			this.buttonGenerate.Location = new System.Drawing.Point(341, 309);
			this.buttonGenerate.Name = "buttonGenerate";
			this.buttonGenerate.Size = new System.Drawing.Size(131, 40);
			this.buttonGenerate.TabIndex = 1;
			this.buttonGenerate.Text = "Generate";
			this.buttonGenerate.UseVisualStyleBackColor = true;
			this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerateClick);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.richTextBoxRes);
			this.panel1.Controls.Add(this.checkBoxDigits);
			this.panel1.Controls.Add(this.checkBoxAlphas);
			this.panel1.Controls.Add(this.numericUpDownLength);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.numericUpDownCount);
			this.panel1.Location = new System.Drawing.Point(13, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(459, 290);
			this.panel1.TabIndex = 2;
			// 
			// richTextBoxRes
			// 
			this.richTextBoxRes.Location = new System.Drawing.Point(13, 74);
			this.richTextBoxRes.Name = "richTextBoxRes";
			this.richTextBoxRes.ReadOnly = true;
			this.richTextBoxRes.Size = new System.Drawing.Size(433, 204);
			this.richTextBoxRes.TabIndex = 6;
			this.richTextBoxRes.Text = "";
			// 
			// checkBoxDigits
			// 
			this.checkBoxDigits.Checked = true;
			this.checkBoxDigits.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxDigits.Location = new System.Drawing.Point(219, 43);
			this.checkBoxDigits.Name = "checkBoxDigits";
			this.checkBoxDigits.Size = new System.Drawing.Size(74, 24);
			this.checkBoxDigits.TabIndex = 5;
			this.checkBoxDigits.Text = "Use digits";
			this.checkBoxDigits.UseVisualStyleBackColor = true;
			// 
			// checkBoxAlphas
			// 
			this.checkBoxAlphas.Checked = true;
			this.checkBoxAlphas.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxAlphas.Location = new System.Drawing.Point(13, 44);
			this.checkBoxAlphas.Name = "checkBoxAlphas";
			this.checkBoxAlphas.Size = new System.Drawing.Size(81, 24);
			this.checkBoxAlphas.TabIndex = 4;
			this.checkBoxAlphas.Text = "Use a-zA-Z";
			this.checkBoxAlphas.UseVisualStyleBackColor = true;
			// 
			// numericUpDownLength
			// 
			this.numericUpDownLength.Location = new System.Drawing.Point(269, 6);
			this.numericUpDownLength.Maximum = new decimal(new int[] {
									50,
									0,
									0,
									0});
			this.numericUpDownLength.Minimum = new decimal(new int[] {
									4,
									0,
									0,
									0});
			this.numericUpDownLength.Name = "numericUpDownLength";
			this.numericUpDownLength.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownLength.TabIndex = 3;
			this.numericUpDownLength.Value = new decimal(new int[] {
									8,
									0,
									0,
									0});
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(219, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Length:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Count:";
			// 
			// numericUpDownCount
			// 
			this.numericUpDownCount.Location = new System.Drawing.Point(62, 6);
			this.numericUpDownCount.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.numericUpDownCount.Name = "numericUpDownCount";
			this.numericUpDownCount.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownCount.TabIndex = 0;
			this.numericUpDownCount.Value = new decimal(new int[] {
									6,
									0,
									0,
									0});
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 361);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.buttonGenerate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "PasswordGenerator";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.NumericUpDown numericUpDownCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDownLength;
		private System.Windows.Forms.CheckBox checkBoxAlphas;
		private System.Windows.Forms.CheckBox checkBoxDigits;
		private System.Windows.Forms.RichTextBox richTextBoxRes;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonGenerate;
	}
}
