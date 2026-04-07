using System;
using System.Text;
using System.Windows.Forms;

namespace OddEvenCheckerApp
{
    public partial class Form1 : Form
    {
        // ── Jagged Array Declaration ─────────────────────────────────────────────
        int[][] jagValues = { new int[] {1, 2, 3},
                              new int[] {4, 5, 6},
                              new int[] {7, 8}     };

        public Form1()
        {
            InitializeComponent();
        }

        // ── Method: CalcSummation ────────────────────────────────────────────────
        // Takes a jagged array, returns a string with the summation of each row
        private string CalcSummation(int[][] arr)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < arr.Length; row++)
            {
                int rowSum = 0;

                for (int col = 0; col < arr[row].Length; col++)
                {
                    rowSum += arr[row][col];
                }

                sb.AppendLine($"  Row {row + 1}  →  Sum = {rowSum}");
            }

            return sb.ToString();
        }

        // ── Calculate Button ─────────────────────────────────────────────────────
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string result = CalcSummation(jagValues);
                lblResult.Text = "Summation Results:\r\n" + result;
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

