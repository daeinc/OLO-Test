namespace OLO_Pizza_Challenge
{
    partial class FormMain
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
            this.Button_ShowPopularCombinations = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_ShowPopularCombinations
            // 
            this.Button_ShowPopularCombinations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_ShowPopularCombinations.Location = new System.Drawing.Point(30, 10);
            this.Button_ShowPopularCombinations.Name = "Button_ShowPopularCombinations";
            this.Button_ShowPopularCombinations.Size = new System.Drawing.Size(182, 23);
            this.Button_ShowPopularCombinations.TabIndex = 1;
            this.Button_ShowPopularCombinations.Text = "Show Popular Combinations";
            this.Button_ShowPopularCombinations.UseVisualStyleBackColor = true;
            this.Button_ShowPopularCombinations.Click += new System.EventHandler(this.Button_ShowPopularCombinations_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(30, 41);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(303, 468);
            this.dgvResults.TabIndex = 3;
            this.dgvResults.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 517);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.Button_ShowPopularCombinations);
            this.Name = "FormMain";
            this.Text = "OLO Pizza Challenge - Daniel Ewald";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_ShowPopularCombinations;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}

