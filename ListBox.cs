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

        // ADD button – adds textbox1 value to ListBoxFruit
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter a fruit name before adding.",
                        "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ListBoxFruit.Items.Add(textBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while adding:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // VIEW button – displays selected item and its index
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBoxFruit.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item to view.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string selectedItem  = ListBoxFruit.SelectedItem.ToString();
                int    selectedIndex = ListBoxFruit.SelectedIndex;

                MessageBox.Show(
                    $"Selected Item  : {selectedItem}\n" +
                    $"Selected Index : {selectedIndex}",
                    "Selected Item Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while viewing:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // REMOVE1 button – removes the selected item by its NAME (value)
        private void btnRemove1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBoxFruit.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item to remove.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string itemName = ListBoxFruit.SelectedItem.ToString();
                ListBoxFruit.Items.Remove(itemName);

                MessageBox.Show($"'{itemName}' has been removed.",
                    "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while removing by name:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // REMOVE2 button – removes the selected item by its INDEX
        private void btnRemove2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBoxFruit.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item to remove.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int selectedIndex = ListBoxFruit.SelectedIndex;
                string itemName   = ListBoxFruit.Items[selectedIndex].ToString();
                ListBoxFruit.Items.RemoveAt(selectedIndex);

                MessageBox.Show($"Item at index [{selectedIndex}] ('{itemName}') has been removed.",
                    "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while removing by index:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CLEAR button – deletes ALL items from the ListBox
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListBoxFruit.Items.Count == 0)
                {
                    MessageBox.Show("The list is already empty.",
                        "List Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete ALL items?",
                    "Confirm Clear",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                    ListBoxFruit.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while clearing list:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CLEARDATA button – clears only the TextBox
        private void btnClearData_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while clearing textbox:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

