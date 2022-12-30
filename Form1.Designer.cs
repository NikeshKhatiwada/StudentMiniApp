using MySql.Data.MySqlClient;

namespace StudentMiniApp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.studentDataGrid = new System.Windows.Forms.DataGridView();
            this.StudentListTitle = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.studentDataGrid);
            this.panel1.Controls.Add(this.StudentListTitle);
            this.panel1.Location = new System.Drawing.Point(0, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 837);
            this.panel1.TabIndex = 12;
            // 
            // studentDataGrid
            // 
            this.studentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentDataGrid.Location = new System.Drawing.Point(3, 67);
            this.studentDataGrid.Name = "studentDataGrid";
            this.studentDataGrid.ReadOnly = true;
            this.studentDataGrid.RowHeadersWidth = 51;
            this.studentDataGrid.RowTemplate.Height = 29;
            this.studentDataGrid.RowTemplate.ReadOnly = true;
            this.studentDataGrid.Size = new System.Drawing.Size(740, 699);
            this.studentDataGrid.TabIndex = 12;
            // 
            // StudentListTitle
            // 
            this.StudentListTitle.AutoSize = true;
            this.StudentListTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StudentListTitle.Location = new System.Drawing.Point(3, 10);
            this.StudentListTitle.Name = "StudentListTitle";
            this.StudentListTitle.Size = new System.Drawing.Size(236, 54);
            this.StudentListTitle.TabIndex = 11;
            this.StudentListTitle.Text = "StudentList";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addButton.ForeColor = System.Drawing.SystemColors.Info;
            this.addButton.Location = new System.Drawing.Point(23, 780);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(163, 48);
            this.addButton.TabIndex = 13;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.refreshButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.refreshButton.ForeColor = System.Drawing.SystemColors.Info;
            this.refreshButton.Location = new System.Drawing.Point(562, 780);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(163, 48);
            this.refreshButton.TabIndex = 14;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 861);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private DataGridView studentDataGrid;
        private Label StudentListTitle;
        private Button addButton;
        private Button refreshButton;
    }
}