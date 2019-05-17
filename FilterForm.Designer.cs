namespace Innuendo
{
    partial class FilterForm
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
            this.CategoryChoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CategoryCriteria = new System.Windows.Forms.ComboBox();
            this.EntryCriteria = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CategoryChoice
            // 
            this.CategoryChoice.FormattingEnabled = true;
            this.CategoryChoice.Location = new System.Drawing.Point(145, 30);
            this.CategoryChoice.Name = "CategoryChoice";
            this.CategoryChoice.Size = new System.Drawing.Size(138, 21);
            this.CategoryChoice.TabIndex = 0;
            this.CategoryChoice.TextChanged += new System.EventHandler(this.CategoryChoice_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter Entries by:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnFilterData_Click);
            // 
            // btnCancelFilter
            // 
            this.btnCancelFilter.Location = new System.Drawing.Point(208, 132);
            this.btnCancelFilter.Name = "btnCancelFilter";
            this.btnCancelFilter.Size = new System.Drawing.Size(75, 23);
            this.btnCancelFilter.TabIndex = 3;
            this.btnCancelFilter.Text = "Cancel";
            this.btnCancelFilter.UseVisualStyleBackColor = true;
            this.btnCancelFilter.Click += new System.EventHandler(this.btnCancelFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Criteria:";
            // 
            // CategoryCriteria
            // 
            this.CategoryCriteria.FormattingEnabled = true;
            this.CategoryCriteria.Location = new System.Drawing.Point(145, 57);
            this.CategoryCriteria.Name = "CategoryCriteria";
            this.CategoryCriteria.Size = new System.Drawing.Size(138, 21);
            this.CategoryCriteria.TabIndex = 5;
            // 
            // EntryCriteria
            // 
            this.EntryCriteria.Enabled = false;
            this.EntryCriteria.Location = new System.Drawing.Point(145, 85);
            this.EntryCriteria.Name = "EntryCriteria";
            this.EntryCriteria.Size = new System.Drawing.Size(138, 20);
            this.EntryCriteria.TabIndex = 6;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 196);
            this.Controls.Add(this.EntryCriteria);
            this.Controls.Add(this.CategoryCriteria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelFilter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CategoryChoice);
            this.Name = "FilterForm";
            this.Text = "FilterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CategoryChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CategoryCriteria;
        private System.Windows.Forms.TextBox EntryCriteria;
    }
}