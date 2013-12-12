namespace PagerControl
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
            this.pagerControlTest = new PagerLib.PagerControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pagerControlTest
            // 
            this.pagerControlTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.pagerControlTest.CurrentPage = 1;
            this.pagerControlTest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerControlTest.Location = new System.Drawing.Point(0, 236);
            this.pagerControlTest.Name = "pagerControlTest";
            this.pagerControlTest.RecordCount = 0;
            this.pagerControlTest.RowsPerPage = 5;
            this.pagerControlTest.Size = new System.Drawing.Size(791, 26);
            this.pagerControlTest.TabIndex = 0;
            this.pagerControlTest.TotalPage = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(791, 236);
            this.dataGridView1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 262);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pagerControlTest);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PagerLib.PagerControl pagerControlTest;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}