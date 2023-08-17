namespace Arduino_Jostick_Communication
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
            label2 = new Label();
            label_Input_Data = new Label();
            label_Aim_Sensitivity = new Label();
            label3 = new Label();
            textBox_PortNumber = new TextBox();
            button_Open = new Button();
            textBox_Aim_Sensitivity = new TextBox();
            label4 = new Label();
            button_Aim_Sensitivity = new Button();
            button_Moving_Test = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 37);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "현재 입력 값";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 101);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 1;
            label2.Text = "현재 마우스 민감도";
            // 
            // label_Input_Data
            // 
            label_Input_Data.AutoSize = true;
            label_Input_Data.Location = new Point(209, 38);
            label_Input_Data.Name = "label_Input_Data";
            label_Input_Data.Size = new Size(47, 15);
            label_Input_Data.TabIndex = 2;
            label_Input_Data.Text = "입력 값";
            // 
            // label_Aim_Sensitivity
            // 
            label_Aim_Sensitivity.AutoSize = true;
            label_Aim_Sensitivity.Location = new Point(209, 101);
            label_Aim_Sensitivity.Name = "label_Aim_Sensitivity";
            label_Aim_Sensitivity.Size = new Size(59, 15);
            label_Aim_Sensitivity.TabIndex = 3;
            label_Aim_Sensitivity.Text = "민감도 값";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 161);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 4;
            label3.Text = "PORT 상태(MEGA)";
            // 
            // textBox_PortNumber
            // 
            textBox_PortNumber.Location = new Point(31, 202);
            textBox_PortNumber.Name = "textBox_PortNumber";
            textBox_PortNumber.Size = new Size(111, 23);
            textBox_PortNumber.TabIndex = 5;
            // 
            // button_Open
            // 
            button_Open.Location = new Point(209, 202);
            button_Open.Name = "button_Open";
            button_Open.Size = new Size(101, 23);
            button_Open.TabIndex = 6;
            button_Open.Text = "아두이노 연결";
            button_Open.UseVisualStyleBackColor = true;
            button_Open.Click += button_Open_Click;
            // 
            // textBox_Aim_Sensitivity
            // 
            textBox_Aim_Sensitivity.Location = new Point(31, 306);
            textBox_Aim_Sensitivity.Name = "textBox_Aim_Sensitivity";
            textBox_Aim_Sensitivity.Size = new Size(111, 23);
            textBox_Aim_Sensitivity.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 262);
            label4.Name = "label4";
            label4.Size = new Size(127, 30);
            label4.TabIndex = 8;
            label4.Text = "마우스 민감도 값 변경\r\n        1 ~ 100";
            // 
            // button_Aim_Sensitivity
            // 
            button_Aim_Sensitivity.Location = new Point(209, 306);
            button_Aim_Sensitivity.Name = "button_Aim_Sensitivity";
            button_Aim_Sensitivity.Size = new Size(101, 23);
            button_Aim_Sensitivity.TabIndex = 9;
            button_Aim_Sensitivity.Text = "민감도 값 변경";
            button_Aim_Sensitivity.UseVisualStyleBackColor = true;
            button_Aim_Sensitivity.Click += button_Aim_Sensitivity_Click;
            // 
            // button_Moving_Test
            // 
            button_Moving_Test.Location = new Point(120, 347);
            button_Moving_Test.Name = "button_Moving_Test";
            button_Moving_Test.Size = new Size(95, 23);
            button_Moving_Test.TabIndex = 10;
            button_Moving_Test.Text = "움직임 테스트";
            button_Moving_Test.UseVisualStyleBackColor = true;
            button_Moving_Test.Click += button_Moving_Test_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 382);
            Controls.Add(button_Moving_Test);
            Controls.Add(button_Aim_Sensitivity);
            Controls.Add(label4);
            Controls.Add(textBox_Aim_Sensitivity);
            Controls.Add(button_Open);
            Controls.Add(textBox_PortNumber);
            Controls.Add(label3);
            Controls.Add(label_Aim_Sensitivity);
            Controls.Add(label_Input_Data);
            Controls.Add(label2);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label_Input_Data;
        private Label label_Aim_Sensitivity;
        private Label label3;
        private TextBox textBox_PortNumber;
        private Button button_Open;
        private TextBox textBox_Aim_Sensitivity;
        private Label label4;
        private Button button_Aim_Sensitivity;
        private Button button_Moving_Test;
    }
}