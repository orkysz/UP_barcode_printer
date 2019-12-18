namespace BarPrinterCode
{
    partial class BarcodeForm
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
            this.tbCodeToGenerate = new System.Windows.Forms.TextBox();
            this.btnGenerateToBarcode = new System.Windows.Forms.Button();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.pbBarcode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCodeToGenerate
            // 
            this.tbCodeToGenerate.Location = new System.Drawing.Point(20, 20);
            this.tbCodeToGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCodeToGenerate.Name = "tbCodeToGenerate";
            this.tbCodeToGenerate.Size = new System.Drawing.Size(409, 26);
            this.tbCodeToGenerate.TabIndex = 0;
            // 
            // btnGenerateToBarcode
            // 
            this.btnGenerateToBarcode.Location = new System.Drawing.Point(18, 60);
            this.btnGenerateToBarcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerateToBarcode.Name = "btnGenerateToBarcode";
            this.btnGenerateToBarcode.Size = new System.Drawing.Size(279, 35);
            this.btnGenerateToBarcode.TabIndex = 1;
            this.btnGenerateToBarcode.Text = "Generuj kod kreskowy";
            this.btnGenerateToBarcode.UseVisualStyleBackColor = true;
            this.btnGenerateToBarcode.Click += new System.EventHandler(this.btnGenerateToBarcode_Click);
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.Location = new System.Drawing.Point(308, 60);
            this.btnPrintBarcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(112, 35);
            this.btnPrintBarcode.TabIndex = 2;
            this.btnPrintBarcode.Text = "Drukuj";
            this.btnPrintBarcode.UseVisualStyleBackColor = true;
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // pbBarcode
            // 
            this.pbBarcode.BackColor = System.Drawing.Color.White;
            this.pbBarcode.Location = new System.Drawing.Point(18, 117);
            this.pbBarcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbBarcode.Name = "pbBarcode";
            this.pbBarcode.Size = new System.Drawing.Size(402, 142);
            this.pbBarcode.TabIndex = 3;
            this.pbBarcode.TabStop = false;
            // 
            // BarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 300);
            this.Controls.Add(this.pbBarcode);
            this.Controls.Add(this.btnPrintBarcode);
            this.Controls.Add(this.btnGenerateToBarcode);
            this.Controls.Add(this.tbCodeToGenerate);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BarcodeForm";
            this.Text = "Kod kreskowy";
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCodeToGenerate;
        private System.Windows.Forms.Button btnGenerateToBarcode;
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.PictureBox pbBarcode;
    }
}

