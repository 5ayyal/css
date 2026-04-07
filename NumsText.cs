using System;
using System.IO;
using System.Windows.Forms;

namespace OddEvenCheckerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ── btnCheckValue Button ─────────────────────────────────────────────────
        private void btnCheckValue_Click(object sender, EventArgs e)
        {
            try
            {
                // ── Check file exists ────────────────────────────────────────────
                string filePath = "munumber.txt";

                if (!File.Exists(filePath))
                {
                    MessageBox.Show(
                        $"File not found:\n{Path.GetFullPath(filePath)}\n\n" +
                        "Please make sure 'munumber.txt' exists in the application folder.",
                        "File Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // ── Read all lines ───────────────────────────────────────────────
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    MessageBox.Show(
                        "The file 'munumber.txt' is empty.\n" +
                        "Please add numbers to the file.",
                        "Empty File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // ── Count odd and even numbers ───────────────────────────────────
                int oddCount  = 0;
                int evenCount = 0;
                int skipped   = 0;

                foreach (string line in lines)
                {
                    // Support multiple numbers per line (space or comma separated)
                    string[] tokens = line.Split(
                        new char[] { ' ', ',', '\t' },
                        StringSplitOptions.RemoveEmptyEntries);

                    foreach (string token in tokens)
                    {
                        if (int.TryParse(token.Trim(), out int number))
                        {
                            if (number % 2 == 0)
                                evenCount++;
                            else
                                oddCount++;
                        }
                        else
                        {
                            skipped++;
                        }
                    }
                }

                // ── Build result message ─────────────────────────────────────────
                int totalValid = oddCount + evenCount;

                string resultMessage =
                    "════════════════════════════\n"  +
                    "      Number Check Result     \n"  +
                    "════════════════════════════\n\n" +
                    $"  Total Valid Numbers : {totalValid}\n"  +
                    $"  Even Numbers        : {evenCount}\n"   +
                    $"  Odd  Numbers        : {oddCount}\n";

                if (skipped > 0)
                    resultMessage += $"\n  (Skipped {skipped} non-integer token(s))";

                MessageBox.Show(
                    resultMessage,
                    "Odd / Even Results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show(
                    "Access denied while reading the file.\n\nDetails: " + uaEx.Message,
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show(
                    "A file I/O error occurred.\n\nDetails: " + ioEx.Message,
                    "I/O Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (OutOfMemoryException memEx)
            {
                MessageBox.Show(
                    "The file is too large to process.\n\nDetails: " + memEx.Message,
                    "Out of Memory",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred.\n\nDetails: " + ex.Message,
                    "Unexpected Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

