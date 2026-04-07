using System;
using System.Text;
using System.Windows.Forms;

namespace OddEvenCheckerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ── Method: ReverseArray ─────────────────────────────────────────────────
        // Takes an int array, returns a new array with elements in reversed order
        private int[] ReverseArray(int[] arr)
        {
            int[] reversed = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                reversed[i] = arr[arr.Length - 1 - i];
            }

            return reversed;
        }

        // ── Display Button ───────────────────────────────────────────────────────
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                // Read input — user enters comma or space separated numbers
                // e.g.  "5, 10, 15, 20, 25"
                string input = txtArray.Text.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show(
                        "Please enter array elements before clicking Display.\n" +
                        "Example:  5, 10, 15, 20, 25",
                        "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtArray.Focus();
                    return;
                }

                // Split on commas and spaces
                string[] tokens = input.Split(
                    new char[] { ',', ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                // Parse each token into an int array
                int[] original = new int[tokens.Length];

                for (int i = 0; i < tokens.Length; i++)
                {
                    if (!int.TryParse(tokens[i].Trim(), out original[i]))
                    {
                        MessageBox.Show(
                            $"Invalid element: '{tokens[i]}'\n" +
                            "Please enter whole numbers only, separated by commas.",
                            "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtArray.Focus();
                        return;
                    }
                }

                // Call ReverseArray method
                int[] reversed = ReverseArray(original);

                // Build original array string
                StringBuilder sbOriginal = new StringBuilder();
                sbOriginal.Append("  Original  :  [ ");
                for (int i = 0; i < original.Length; i++)
                {
                    sbOriginal.Append(original[i]);
                    if (i < original.Length - 1) sbOriginal.Append(", ");
                }
                sbOriginal.Append(" ]");

                // Build reversed array string
                StringBuilder sbReversed = new StringBuilder();
                sbReversed.Append("  Reversed  :  [ ");
                for (int i = 0; i < reversed.Length; i++)
                {
                    sbReversed.Append(reversed[i]);
                    if (i < reversed.Length - 1) sbReversed.Append(", ");
                }
                sbReversed.Append(" ]");

                // Display result
                lblResult.ForeColor = System.Drawing.Color.FromArgb(0, 100, 200);
                lblResult.Text = sbOriginal.ToString() + "\n\n" + sbReversed.ToString();
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
                txtArray.Clear();
                lblResult.Text      = "  Result will appear here...";
                lblResult.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                txtArray.Focus();
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

