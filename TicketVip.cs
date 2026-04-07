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

        // ── Method: GetTicketPrice ───────────────────────────────────────────────
        // Returns price per ticket based on category selection (1, 2, or 3)
        private double GetTicketPrice(int category)
        {
            switch (category)
            {
                case 1: return 500; // VIP
                case 2: return 300; // IP
                case 3: return 100; // P
                default: return -1; // invalid
            }
        }

        // ── Method: GetCategoryName ──────────────────────────────────────────────
        private string GetCategoryName(int category)
        {
            switch (category)
            {
                case 1: return "VIP";
                case 2: return "IP";
                case 3: return "P";
                default: return "Unknown";
            }
        }

        // ── Calculate Button ─────────────────────────────────────────────────────
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate: number of people
                if (!int.TryParse(txtPeople.Text.Trim(), out int numPeople))
                {
                    MessageBox.Show(
                        "Invalid input!\nPlease enter a valid whole number for people.",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPeople.Focus();
                    return;
                }

                if (numPeople <= 0)
                {
                    MessageBox.Show(
                        "Number of people must be greater than zero!",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPeople.Focus();
                    return;
                }

                // Validate: category
                if (!int.TryParse(txtCategory.Text.Trim(), out int category))
                {
                    MessageBox.Show(
                        "Invalid input!\nPlease enter a category number (1, 2, or 3).",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategory.Focus();
                    return;
                }

                double pricePerTicket = GetTicketPrice(category);

                if (pricePerTicket == -1)
                {
                    MessageBox.Show(
                        "Invalid category!\nPlease enter:\n  1 for VIP\n  2 for IP\n  3 for P",
                        "Invalid Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategory.Focus();
                    return;
                }

                // Calculate total
                double totalPrice    = numPeople * pricePerTicket;
                string categoryName  = GetCategoryName(category);

                // Display result
                lblResult.ForeColor = System.Drawing.Color.FromArgb(0, 100, 200);
                lblResult.Text =
                    $"  Category      :  {categoryName}\n" +
                    $"  No. of People :  {numPeople}\n" +
                    $"  Price / Ticket :  {pricePerTicket} Riyals\n" +
                    $"  ─────────────────────────────\n" +
                    $"  Total Price   :  {totalPrice} Riyals";
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
                txtPeople.Clear();
                txtCategory.Clear();
                lblResult.Text      = "  Result will appear here...";
                lblResult.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                txtPeople.Focus();
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

