using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FireBase_Helper
{
    public partial class Start_Form : Form
    {
        private static Dictionary<int,Table> Database;

        public Start_Form()
        {
            Database = new Dictionary<int,Table>();

            InitializeComponent();

            UpdateDatabase();

        }

        private void UpdateDatabase()
        {
            DatabaseGridView.Rows.Clear();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Start_Form));
            foreach (Table table in Database.Values)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell tablenameCell = new DataGridViewTextBoxCell
                {
                    Value = table.Name
                };
                row.Cells.Add(tablenameCell);
                DatabaseGridView.Rows.Add(row);
            }
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            AddForm addform = new AddForm(Database);
            addform.ShowDialog();
            UpdateDatabase();
        }

        private void DatabaseGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = DatabaseGridView.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[0];
            string TableName = (string)cell.Value;
            int TableID = Database.Last(t => t.Value.Name.Equals(TableName)).Key;
            switch (e.ColumnIndex)
            {
                case 1: //Edit
                    new AddForm(Database, TableID).ShowDialog();
                    UpdateDatabase();
                    break;
                case 2: //Remove

                    DialogResult DG = MessageBox.Show(this, "Are you sure you want to delete " + TableName + "table", "Delete Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (DG == DialogResult.Yes)
                    {
                        foreach (KeyValuePair<int,Relation_Type> item in Database[TableID].Relations)
                        {
                            Database[item.Key].Relations.Remove(TableID);
                        } 
                        Database.Remove(TableID);
                        UpdateDatabase();
                    }
                    break;
                default:
                    break;
            }
        }

        private void Submit_button_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Print_Class print = new Print_Class(saveFileDialog.FileName);
                print.DoPrint(Database);
            }
            this.Close();
        }
    }
}
