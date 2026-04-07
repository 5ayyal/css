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

        // ── Method: CheckLoanEligibility ─────────────────────────────────────────
        // Returns eligibility status string based on income and credit score
        private string CheckLoanEligibility(double income, double creditScore)
        {
            if (income > 50000 && creditScore > 700)
                return "Applicable";
            else if (income > 30000 && creditScore > 600)
                return "Applicable with Conditions";
            else
                return "Not Applicable";
        }

        // ── Check Button ─────────────────────────────────────────────────────────
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                // ── Validate Age ─────────────────────────────────────────────────
                if (!int.TryParse(txtAge.Text.Trim(), out int age))
                {
                    MessageBox.Show(
                        "Invalid age!\nPlease enter a valid whole number.",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAge.Focus();
                    return;
                }

                if (age <= 0)
                {
                    MessageBox.Show(
                        "Age must be a positive number!",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAge.Focus();
                    return;
                }

                // ── Age is less than 25 ──────────────────────────────────────────
                if (age < 25)
                {
                    lblResult.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
                    lblResult.Text =
                        $"  Age          :  {age} years old\n\n" +
                        $"  ❌  Not Applicable\n" +
                        $"  You must be at least 25 years old to apply.";
                    return;
                }

                // ── Age >= 25: validate Income ───────────────────────────────────
                if (!double.TryParse(txtIncome.Text.Trim(), out double income))
                {
                    MessageBox.Show(
                        "Invalid income!\nPlease enter a valid number.",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIncome.Focus();
                    return;
                }

                if (income <= 0)
                {
                    MessageBox.Show(
                        "Income must be a positive number!",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIncome.Focus();
                    return;
                }

                // ── Validate Credit Score ────────────────────────────────────────
                if (!double.TryParse(txtCreditScore.Text.Trim(), out double creditScore))
                {
                    MessageBox.Show(
                        "Invalid credit score!\nPlease enter a valid number.",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCreditScore.Focus();
                    return;
                }

                if (creditScore <= 0)
                {
                    MessageBox.Show(
                        "Credit score must be a positive number!",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCreditScore.Focus();
                    return;
                }

                // ── Call CheckLoanEligibility method ─────────────────────────────
                string status = CheckLoanEligibility(income, creditScore);

                // Pick colour based on result
                switch (status)
                {
                    case "Applicable":
                        lblResult.ForeColor = System.Drawing.Color.FromArgb(0, 150, 80);
                        break;
                    case "Applicable with Conditions":
                        lblResult.ForeColor = System.Drawing.Color.FromArgb(200, 120, 0);
                        break;
                    default:
                        lblResult.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
                        break;
                }

                lblResult.Text =
                    $"  Age           :  {age} years old\n"          +
                    $"  Income        :  {income:N0} S.R\n"           +
                    $"  Credit Score  :  {creditScore:N0} S.R\n"      +
                    $"  ─────────────────────────────────\n"          +
                    $"  Status        :  {status}";
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
                txtAge.Clear();
                txtIncome.Clear();
                txtCreditScore.Clear();
                lblResult.Text      = "  Result will appear here...";
                lblResult.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                txtAge.Focus();
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

