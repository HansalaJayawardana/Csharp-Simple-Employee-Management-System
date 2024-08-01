namespace Employee_Management_System
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Emp = new System.Windows.Forms.Button();
            this.Dep = new System.Windows.Forms.Button();
            this.Assign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Management System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Emp
            // 
            this.Emp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emp.Location = new System.Drawing.Point(89, 205);
            this.Emp.Name = "Emp";
            this.Emp.Size = new System.Drawing.Size(151, 148);
            this.Emp.TabIndex = 2;
            this.Emp.Text = "Employee ";
            this.Emp.UseVisualStyleBackColor = true;
            this.Emp.Click += new System.EventHandler(this.Emp_Click);
            // 
            // Dep
            // 
            this.Dep.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dep.Location = new System.Drawing.Point(395, 205);
            this.Dep.Name = "Dep";
            this.Dep.Size = new System.Drawing.Size(151, 148);
            this.Dep.TabIndex = 3;
            this.Dep.Text = "Department";
            this.Dep.UseVisualStyleBackColor = true;
            this.Dep.Click += new System.EventHandler(this.Dep_Click);
            // 
            // Assign
            // 
            this.Assign.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Assign.Location = new System.Drawing.Point(707, 205);
            this.Assign.Name = "Assign";
            this.Assign.Size = new System.Drawing.Size(151, 148);
            this.Assign.TabIndex = 4;
            this.Assign.Text = "Assign";
            this.Assign.UseVisualStyleBackColor = true;
            this.Assign.Click += new System.EventHandler(this.Assign_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 623);
            this.Controls.Add(this.Assign);
            this.Controls.Add(this.Dep);
            this.Controls.Add(this.Emp);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Emp;
        private System.Windows.Forms.Button Dep;
        private System.Windows.Forms.Button Assign;
    }
}