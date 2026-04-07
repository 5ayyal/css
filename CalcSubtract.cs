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

        // ── Method: CalcSubtract ─────────────────────────────────────────────────
        // Takes 2 double parameters, returns their subtraction result
        private double CalcSubtract(double num1, double num2)
        {
            return num1 - num2;
        }

        // ── Method: ClearALL ─────────────────────────────────────────────────────
        // Clears textBox1, textBox2, and lblResult
        private void ClearALL()
        {
            textBox1.Clear();
            textBox2.Clear();
            lblResult.Text = "Result: ";
            textBox1.Focus();
        }

        // ── Subtract Button ──────────────────────────────────────────────────────
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            try
            {
                // TryParse textBox1
                if (!double.TryParse(textBox1.Text.Trim(), out double num1))
                {
                    MessageBox.Show(
                        "Invalid value in Field 1.\nPlease enter a valid number.",
                        "Input Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                // TryParse textBox2
                if (!double.TryParse(textBox2.Text.Trim(), out double num2))
                {
                    MessageBox.Show(
                        "Invalid value in Field 2.\nPlease enter a valid number.",
                        "Input Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }

                // Call CalcSubtract method and display result
                double result = CalcSubtract(num1, num2);
                lblResult.Text = $"Result:  {num1}  −  {num2}  =  {result}";
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
                ClearALL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error while clearing:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

