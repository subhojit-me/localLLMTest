namespace AIWindow
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            aiResponseTxtBox = new TextBox();
            userQueryTxtBox = new TextBox();
            label2 = new Label();
            askAIBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 25);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "AI Message";
            // 
            // aiResponseTxtBox
            // 
            aiResponseTxtBox.Location = new Point(76, 61);
            aiResponseTxtBox.Multiline = true;
            aiResponseTxtBox.Name = "aiResponseTxtBox";
            aiResponseTxtBox.ReadOnly = true;
            aiResponseTxtBox.Size = new Size(620, 153);
            aiResponseTxtBox.TabIndex = 1;
            // 
            // userQueryTxtBox
            // 
            userQueryTxtBox.Location = new Point(76, 288);
            userQueryTxtBox.Multiline = true;
            userQueryTxtBox.Name = "userQueryTxtBox";
            userQueryTxtBox.Size = new Size(620, 71);
            userQueryTxtBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 252);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 2;
            label2.Text = "User Query";
            // 
            // askAIBtn
            // 
            askAIBtn.Location = new Point(304, 386);
            askAIBtn.Name = "askAIBtn";
            askAIBtn.Size = new Size(114, 38);
            askAIBtn.TabIndex = 4;
            askAIBtn.Text = "Ask AI";
            askAIBtn.UseVisualStyleBackColor = true;
            askAIBtn.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 466);
            Controls.Add(askAIBtn);
            Controls.Add(userQueryTxtBox);
            Controls.Add(label2);
            Controls.Add(aiResponseTxtBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox aiResponseTxtBox;
        private TextBox userQueryTxtBox;
        private Label label2;
        private Button askAIBtn;
    }
}
