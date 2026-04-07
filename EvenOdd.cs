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

        private void btnCheckValue_Click(object sender, EventArgs e)
        {
            try
            {
                // ── 1. Locate the file ───────────────────────────────────────────
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

                // ── 2. Read all lines from the file ──────────────────────────────
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    MessageBox.Show(
                        "The file 'munumber.txt' is empty.\nPlease add numbers to the file.",
                        "Empty File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // ── 3. Parse and classify numbers ────────────────────────────────
                int oddCount  = 0;
                int evenCount = 0;
                int skipped   = 0;

                foreach (string line in lines)
                {
                    // Support multiple numbers on a single line (space / comma separated)
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
                            // Token exists but is not a valid integer
                            skipped++;
                        }
                    }
                }

                // ── 4. Build and show result message ─────────────────────────────
                int totalValid = oddCount + evenCount;

                string resultMessage =
                    "═══════════════════════════════\n" +
                    "        Number Check Result       \n" +
                    "═══════════════════════════════\n\n" +
                    $"  Total valid numbers : {totalValid}\n" +
                    $"  Even numbers        : {evenCount}\n" +
                    $"  Odd  numbers        : {oddCount}\n";

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
                // File exists but the app has no read permission
                MessageBox.Show(
                    "Access denied while reading 'munumber.txt'.\n\n" +
                    "Details: " + uaEx.Message,
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (IOException ioEx)
            {
                // Disk error, file locked by another process, etc.
                MessageBox.Show(
                    "A file I/O error occurred while reading 'munumber.txt'.\n\n" +
                    "Details: " + ioEx.Message,
                    "I/O Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (OutOfMemoryException memEx)
            {
                // File is too large to read into memory
                MessageBox.Show(
                    "The file is too large to process.\n\n" +
                    "Details: " + memEx.Message,
                    "Out of Memory",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Catch-all for any other unexpected runtime errors
                MessageBox.Show(
                    "An unexpected error occurred.\n\n" +
                    "Details: " + ex.Message,
                    "Unexpected Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

