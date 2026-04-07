namespace OddEvenCheckerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblArray      = new System.Windows.Forms.Label();
            this.lblResult     = new System.Windows.Forms.Label();
            this.btnCalculate  = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ── lblTitle ─────────────────────────────────────────────────────────
            this.lblTitle.AutoSize  = false;
            this.lblTitle.Location  = new System.Drawing.Point(12, 12);
            this.lblTitle.Size      = new System.Drawing.Size(360, 32);
            this.lblTitle.Text      = "Jagged Array – Row Summation";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);

            // ── lblArray (shows the array contents) ──────────────────────────────
            this.lblArray.AutoSize  = false;
            this.lblArray.Location  = new System.Drawing.Point(12, 55);
            this.lblArray.Size      = new System.Drawing.Size(360, 55);
            this.lblArray.Text      = "Array:  { {1, 2, 3},  {4, 5, 6},  {7, 8} }";
            this.lblArray.Font      = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular);
            this.lblArray.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblArray.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblArray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblArray.BackColor   = System.Drawing.Color.FromArgb(245, 245, 245);

            // ── btnCalculate ─────────────────────────────────────────────────────
            this.btnCalculate.Location  = new System.Drawing.Point(120, 125);
            this.btnCalculate.Name      = "btnCalculate";
            this.btnCalculate.Size      = new System.Drawing.Size(150, 40);
            this.btnCalculate.Text      = "⚡  Calculate";
            this.btnCalculate.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.TabIndex  = 0;
            this.btnCalculate.Click    += new System.EventHandler(this.btnCalculate_Click);

            // ── lblResult ────────────────────────────────────────────────────────
            this.lblResult.AutoSize    = false;
            this.lblResult.Location    = new System.Drawing.Point(12, 180);
            this.lblResult.Name        = "lblResult";
            this.lblResult.Size        = new System.Drawing.Size(360, 110);
            this.lblResult.Text        = "Result will appear here...";
            this.lblResult.Font        = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor   = System.Drawing.Color.FromArgb(0, 100, 200);
            this.lblResult.TextAlign   = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.BackColor   = System.Drawing.Color.FromArgb(235, 245, 255);
            this.lblResult.Padding     = new System.Windows.Forms.Padding(8);

            // ── Form1 ────────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(384, 310);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblArray);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblResult);
            this.Name          = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Jagged Array Summation";
            this.ResumeLayout(false);
        }

        // Control declarations
        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Label  lblArray;
        private System.Windows.Forms.Label  lblResult;
        private System.Windows.Forms.Button btnCalculate;
    }
}

