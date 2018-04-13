using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjPasswordGenerator
{
    public partial class FrmMain : MetroFramework.Forms.MetroForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int length = Convert.ToInt32(txtLength.Value);
            var letters = chkLetters;
            var numbers = chkNumbers;

            var pass = generatePassw(length, letters, numbers);
            txtPassword.Text = pass;
        }

        static string generatePassw(int length, CheckBox letters, CheckBox numbers)
        {
            #region Variables and Instance
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZñÑáéÈÓÙÜóúÿú";
            const string validNumbers = "1234567890";
            StringBuilder result = new StringBuilder();
            StringBuilder resultAlt = new StringBuilder();
            Random rnd = new Random();
            #endregion

            try
            {
                #region If (letters and numbers)
                if (letters.Checked & numbers.Checked)
                {
                    int lengthAlt = length / 2;
                    while (0 < lengthAlt--)
                    {

                        result.Append(validChars[rnd.Next(validChars.Length)]);
                        resultAlt.Append(validNumbers[rnd.Next(validNumbers.Length)]);

                    }
                    return result.ToString() + resultAlt.ToString();

                }
                #endregion
                #region else if (letters)
                else if (letters.Checked)
                {
                    while (0 < length--)
                    {

                        result.Append(validChars[rnd.Next(validChars.Length)]);

                    }
                    return result.ToString();

                }
                #endregion
                #region else if (numbers)
                else if (numbers.Checked)
                {
                    while (0 < length--)
                    {
                        result.Append(validNumbers[rnd.Next(validNumbers.Length)]);

                    }
                    return result.ToString();

                }
                #endregion
                #region else
                else
                {
                    MessageBox.Show("You must select an option!!", "RandomPasswordGenerator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
            return result.ToString();


        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {

                MessageBox.Show("Does not have a password, so it was not copied to the clipboard", "RandomPasswordGenerator", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Clipboard.SetDataObject(txtPassword.Text);
                MessageBox.Show("Was copied to clipboard", "RandomPasswordGenerator", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Integrante it = new Integrante();
            it.ShowDialog();
        }
    }
}
