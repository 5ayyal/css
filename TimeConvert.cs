using System;
using System.Windows.Forms;

namespace OddEvenCheckerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ── Method: ConvertHours ─────────────────────────────────────────────────
        // Takes hours as a double, outputs minutes and seconds via out parameters
        private void ConvertHours(double hours, out double minutes, out double seconds)
        {
            minutes = hours * 60;
            seconds = hours * 3600;
        }

        // ── Convert Button ───────────────────────────────────────────────────────
        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate: must be a valid number
                if (!double.TryParse(textBox1.Text.Trim(), out double hours))
                {
                    lblResult.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
                    lblResult.Text      = "⚠  Invalid input!\nPlease enter a valid number.";
                    return;
                }

                // Validate: must be a positive number
                if (hours <= 0)
                {
                    lblResult.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
                    lblResult.Text      = $"⚠  The number must be positive!\n   You entered: {hours}";
                    return;
                }

                // Call ConvertHours method
                ConvertHours(hours, out double minutes, out double seconds);

                // Display result
                lblResult.ForeColor = System.Drawing.Color.FromArgb(0, 100, 200);
                lblResult.Text      = $"  Hours   :  {hours} hr\n" +
                                      $"  Minutes :  {minutes} min\n" +
                                      $"  Seconds :  {seconds} sec";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ── Clear Button ─────────────────────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                lblResult.Text      = "  Result will appear here...";
                lblResult.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

