using MSSQL.Utils;
using System;
using System.Windows.Forms;

namespace MSSQL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (!FieldsAreValid())
            {
                MessageBox.Show("Please fill in all the fields");
                return;
            }

            string instance = InstanceTextBox.Text;
            string database = DatabaseTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            MSSQLConnector connector = new MSSQLConnector(instance, database, username, password);

            bool isConnected = connector.Connect(out string connectionMessage);
            if (isConnected)
            {
                MessageBox.Show(string.Format("Successfully connected to {0}", database), "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(string.Format("Error connecting to {0}: {1}", database, connectionMessage), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FieldsAreValid()
        {
            bool areValid = true;
            if (string.IsNullOrEmpty(InstanceTextBox.Text) ||
                string.IsNullOrEmpty(DatabaseTextBox.Text) ||
                string.IsNullOrEmpty(UsernameTextBox.Text) ||
                string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                areValid = false;
            }

            return areValid;
        }
    }
}
