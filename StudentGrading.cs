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

        // ── Method: GetQualityRating ─────────────────────────────────────────────
        // Takes an integer value and returns the product quality string
        private string GetQualityRating(int value)
        {
            if      (value >= 0  && value <= 20)  return "Poor";
            else if (value >= 21 && value <= 40)  return "Fair";
            else if (value >= 41 && value <= 60)  return "Average";
            else if (value >= 61 && value <= 80)  return "Very Good";
            else if (value >= 81 && value <= 100) return "Excellent";
            else                                   return null; // out of range
        }

        // ── Check Button ─────────────────────────────────────────────────────────
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                // TryParse — validate input is a number
                if (!int.TryParse(textBox1.Text.Trim(), out int value))
                {
                    lblResult.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
                    lblResult.Text      = "⚠  Invalid input!\nPlease enter a whole number.";
                    return;
                }

                // Get rating — returns null if out of 0–100 range
                string rating = GetQualityRating(value);

                if (rating == null)
                {
                    lblResult.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
                    lblResult.Text      = $"⚠  Value '{value}' is out of range!\nPlease enter a number between 0 and 100.";
                    return;
                }

                // Pick a colour per rating for visual feedback
                switch (rating)
                {
                    case "Poor":      lblResult.ForeColor = System.Drawing.Color.FromArgb(180,  30,  30); break;
                    case "Fair":      lblResult.ForeColor = System.Drawing.Color.FromArgb(210, 110,   0); break;
                    case "Average":   lblResult.ForeColor = System.Drawing.Color.FromArgb(160, 130,   0); break;
                    case "Very Good": lblResult.ForeColor = System.Drawing.Color.FromArgb(  0, 140,  80); break;
                    case "Excellent": lblResult.ForeColor = System.Drawing.Color.FromArgb(  0, 100, 200); break;
                }

                lblResult.Text = $"  Score   :  {value}\n  Quality :  {rating}";
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

