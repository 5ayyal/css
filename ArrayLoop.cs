using System;
using System.Text;
using System.Windows.Forms;

namespace OddEvenCheckerApp
{
    public partial class Form1 : Form
    {
        // ── Jagged Array Declaration ─────────────────────────────────────────────
        int[][] jagValues = { new int[] { 1, 2 },
                              new int[] { 3, 4 },
                              new int[] { 5, 6 } };

        public Form1()
        {
            InitializeComponent();
        }

        // ── Method: CalcProduct ──────────────────────────────────────────────────
        // Iterates through the entire jagged array and multiplies ALL numbers
        private int CalcProduct(int[][] arr)
        {
            int product = 1;

            for (int row = 0; row < arr.Length; row++)
            {
                for (int col = 0; col < arr[row].Length; col++)
                {
                    product *= arr[row][col];
                }
            }

            return product;
        }

        // ── Calculate Button ─────────────────────────────────────────────────────
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Build a step-by-step breakdown string
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("  Iteration breakdown:");
                sb.AppendLine();

                int runningProduct = 1;
                for (int row = 0; row < jagValues.Length; row++)
                {
                    for (int col = 0; col < jagValues[row].Length; col++)
                    {
                        int val = jagValues[row][col];
                        sb.AppendLine($"  Row[{row}][{col}] = {val}  →  Running Product = {runningProduct} × {val} = {runningProduct * val}");
                        runningProduct *= val;
                    }
                }

                sb.AppendLine();
                sb.AppendLine($"  ═══════════════════════════════");
                sb.AppendLine($"  Final Product  =  {CalcProduct(jagValues)}");

                lblResult.Text = sb.ToString();
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

