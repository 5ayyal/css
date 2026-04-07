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

        // ── Method: Iamsumofeven ─────────────────────────────────────────────────
        // Takes start and end values, returns the sum of all even numbers between them
        private int Iamsumofeven(int start, int end)
        {
            int sum = 0;

            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                    sum += i;
            }

            return sum;
        }

        // ── Calculate Button ─────────────────────────────────────────────────────
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate: starting value
                if (!int.TryParse(txtStart.Text.Trim(), out int start))
                {
                    MessageBox.Show(
                        "Invalid input!\nPlease enter a valid whole number for the starting value.",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStart.Focus();
                    return;
                }

                // Validate: ending value
                if (!int.TryParse(txtEnd.Text.Trim(), out int end))
                {
                    MessageBox.Show(
                        "Invalid input!\nPlease enter a valid whole number for the ending value.",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEnd.Focus();
                    return;
                }

                // Validate: start must be less than or equal to end
                if (start > end)
                {
                    MessageBox.Show(
                        "Starting value must be less than or equal to the ending value!",
                        "Range Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStart.Focus();
                    return;
                }

                // Call Iamsumofeven method
                int result = Iamsumofeven(start, end);

                // Display result
                lblResult.ForeColor = System.Drawing.Color.FromArgb(0, 100, 200);
                lblResult.Text =
                    $"  Start Value  :  {start}\n"  +
                    $"  End Value    :  {end}\n"    +
                    $"  ───────────────────────────\n" +
                    $"  Sum of Even  :  {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Clear Button ─────────────────────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtStart.Clear();
                txtEnd.Clear();
                lblResult.Text      = "  Result will appear here...";
                lblResult.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                txtStart.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

