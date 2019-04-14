namespace TestDepartament_DataBase_Server
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.LogLB = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.Status_TB = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.IP_TB = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.Save_port = new System.Windows.Forms.Button();
			this.port_TB = new System.Windows.Forms.MaskedTextBox();
			this.SuspendLayout();
			// 
			// LogLB
			// 
			this.LogLB.FormattingEnabled = true;
			this.LogLB.Location = new System.Drawing.Point(364, 28);
			this.LogLB.Name = "LogLB";
			this.LogLB.Size = new System.Drawing.Size(350, 212);
			this.LogLB.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(521, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Log";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(37, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(150, 40);
			this.button1.TabIndex = 2;
			this.button1.Text = "Start server";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.StartServer);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button2.Location = new System.Drawing.Point(193, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(150, 40);
			this.button2.TabIndex = 3;
			this.button2.Text = "Stop server";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.StopServer);
			// 
			// Status_TB
			// 
			this.Status_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Status_TB.Location = new System.Drawing.Point(117, 73);
			this.Status_TB.Name = "Status_TB";
			this.Status_TB.ReadOnly = true;
			this.Status_TB.Size = new System.Drawing.Size(226, 35);
			this.Status_TB.TabIndex = 4;
			this.Status_TB.Text = "Not activated";
			this.Status_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(12, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "Server status:";
			// 
			// IP_TB
			// 
			this.IP_TB.Enabled = false;
			this.IP_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.IP_TB.Location = new System.Drawing.Point(99, 142);
			this.IP_TB.Name = "IP_TB";
			this.IP_TB.ReadOnly = true;
			this.IP_TB.Size = new System.Drawing.Size(259, 22);
			this.IP_TB.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(12, 143);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 18);
			this.label5.TabIndex = 12;
			this.label5.Text = "Server IP";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(12, 213);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 18);
			this.label6.TabIndex = 13;
			this.label6.Text = "Server port";
			// 
			// Save_port
			// 
			this.Save_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Save_port.Location = new System.Drawing.Point(281, 202);
			this.Save_port.Name = "Save_port";
			this.Save_port.Size = new System.Drawing.Size(77, 34);
			this.Save_port.TabIndex = 17;
			this.Save_port.Text = "Save";
			this.Save_port.UseVisualStyleBackColor = true;
			this.Save_port.Click += new System.EventHandler(this.Save_port_Click);
			// 
			// port_TB
			// 
			this.port_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.port_TB.Location = new System.Drawing.Point(99, 209);
			this.port_TB.Mask = "00000000000";
			this.port_TB.Name = "port_TB";
			this.port_TB.Size = new System.Drawing.Size(176, 22);
			this.port_TB.TabIndex = 18;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(724, 246);
			this.Controls.Add(this.port_TB);
			this.Controls.Add(this.Save_port);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.IP_TB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Status_TB);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LogLB);
			this.Name = "MainWindow";
			this.Text = "BZGD-DR Server";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LogLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Status_TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IP_TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Save_port;
        private System.Windows.Forms.MaskedTextBox port_TB;
    }
}

