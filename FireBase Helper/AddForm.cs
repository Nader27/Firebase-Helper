using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FireBase_Helper
{
    public partial class AddForm : Form
    {
        private bool TableName_Valid; //Flag
        private bool isEdit; //Flag

        private int Tableindex; //if not in EditMode Index = -1
        private Table Table;    //Currunt Table

        private const string Key_Column = "Key";    //Key Column Name


        private static Dictionary<int, Table> Database;    //Static DataBase

        public AddForm(Dictionary<int, Table> database)
        {
            TableName_Valid = false;
            isEdit = false;
            Tableindex = -1;

            Table = new Table();
            Database = database;

            InitializeComponent();

            InitRelation();

            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell
            {
                Value = Key_Column
            };
            row.Cells.Add(cell);
            Columns_data.Rows.Add(row);
            Table.Columns.Add(Key_Column);
        }

        public AddForm(Dictionary<int, Table> database, int index)
        {
            TableName_Valid = true;
            isEdit = true;
            Tableindex = index;

            Table = database[index];
            Database = database;

            InitializeComponent();

            this.Text = "Edit Table";

            InitRelation();

            Columns_groupBox.Enabled = true;
            Properites_groupBox.Enabled = true;
            Relations_groupBox.Enabled = true;
            Submit_button.Enabled = true;

            PreviewTable(Table);
        }

        private void InitRelation()
        {
            Relation_Table_Column.Items.Clear();
            int Counter = 0;
            foreach (Table item in Database.Values)
            {
                if (!isEdit || Counter != Tableindex)
                {
                    Relation_Table_Column.Items.Add(item.Name);
                }
                Counter++;
            }

        }

        private void PreviewTable(Table table)
        {
            TableName_textBox.Text = table.Name;
            int Counter = 0;
            foreach (string column in table.Columns)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell
                {
                    Value = column
                };
                row.Cells.Add(cell);
                Columns_data.Rows.Add(row);
            }
            Add_checkBox.Checked = table.properites.has_Add;
            Update_checkBox.Checked = table.properites.has_Update;
            Remove_checkBox.Checked = table.properites.has_Remove;
            Find_checkBox.Checked = table.properites.has_Find;
            Where_checkBox.Checked = table.properites.has_Where;
            Tolist_checkBox.Checked = table.properites.has_ToList;

            Counter = 0;
            foreach (KeyValuePair<int, Relation_Type> item in table.Relations)
            {
                DataGridViewRow row = new DataGridViewRow();
                Relation_Data.Rows.Add(row);
                Relation_Data[0, Counter].Value = Database[item.Key].Name;
                Relation_Data[1, Counter].Value = (string)Relation_Type_Column.Items[(int)item.Value];

                Counter++;
            }
        }

        private void TableName_textBox_Validating(object sender, CancelEventArgs e)
        {
            String text = TableName_textBox.Text.Trim();
            if (text.Length == 0)
            {
                TableName_Valid = false;
                e.Cancel = false;
            }
            else if (text.Contains(' '))
            {
                TableName_Valid = false;
                AddForm_errorProvider.SetError(TableName_textBox, "Cannot Contain Space Character");
                e.Cancel = true;
            }
            else
            {
                text = text.ToLower();
                char[] chartext = text.ToCharArray();
                chartext[0] = text.ToUpper().ToCharArray()[0];
                text = String.Concat(chartext);
                bool Found = false;
                int Counter = 0;
                foreach (Table item in Database.Values)
                {
                    if (item.Name.Equals(text))
                    {
                        if (!isEdit && Counter != Tableindex)
                            Found = true;
                        break;
                    }
                    Counter++;
                }
                if (Found)
                {
                    TableName_Valid = false;
                    AddForm_errorProvider.SetError(TableName_textBox, "Table Name Already Used");
                    e.Cancel = true;
                }
                else
                {
                    TableName_Valid = true;
                    TableName_textBox.Text = text;
                    AddForm_errorProvider.SetError(TableName_textBox, "");
                    e.Cancel = false;
                }
            }
        }

        private void TableName_textBox_Validated(object sender, EventArgs e)
        {
            if (TableName_Valid)
            {
                Columns_groupBox.Enabled = true;
                Properites_groupBox.Enabled = true;
                Relations_groupBox.Enabled = true;
                Submit_button.Enabled = true;
            }
            else
            {
                Columns_groupBox.Enabled = false;
                Properites_groupBox.Enabled = false;
                Relations_groupBox.Enabled = false;
                Submit_button.Enabled = false;
            }
        }

        private void TableName_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                focus_button.Focus();
        }

        private void Columns_data_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index == 0)
                e.Cancel = true;
            else
                Table.Columns.RemoveAt(e.Row.Index);
        }

        private void Columns_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            String text = Columns_data[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString().Trim();
            AddForm_errorProvider.SetError(Columns_data, "");
            if (text.Length == 0)
            {
                if (Columns_data.Rows.Count != e.RowIndex + 1)
                {
                    Columns_data.Rows.RemoveAt(e.RowIndex);
                    Table.Columns.RemoveAt(e.RowIndex);
                }
            }
            else if (text.Contains(' '))
            {
                Columns_data.Rows.RemoveAt(e.RowIndex);
                Table.Columns.RemoveAt(e.RowIndex);
                AddForm_errorProvider.SetError(Columns_data, "Cannot Contain Space Character");
            }
            else
            {
                text = text.ToLower();
                char[] chartext = text.ToCharArray();
                chartext[0] = text.ToUpper().ToCharArray()[0];
                text = String.Concat(chartext);
                if (Table.Columns.Contains(text) && !Table.Columns.ElementAt(e.RowIndex).Equals(text))
                {
                    Columns_data.Rows.RemoveAt(e.RowIndex);
                    AddForm_errorProvider.SetError(Columns_data, "This Column Name Already Used");
                }
                Columns_data[e.ColumnIndex, e.RowIndex].Value = text;
                if (Table.Columns.Count == e.RowIndex)
                    Table.Columns.Add(text);
                else
                {
                    Table.Columns.RemoveAt(e.RowIndex);
                    Table.Columns.Insert(e.RowIndex, text);
                }
            }
        }

        private void Relation_Data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AddForm_errorProvider.SetError(Relation_Data, "");
            Submit_button.Enabled = true;
            Relation_Data.AllowUserToAddRows = true;
            if (Relation_Data[0, e.RowIndex].Value == null || Relation_Data[1, e.RowIndex].Value == null)
                if (Relation_Data[0, e.RowIndex].Value == null && Relation_Data[1, e.RowIndex].Value == null)
                {
                }
                else
                {
                    AddForm_errorProvider.SetError(Relation_Data, "Not all Fields are Filled");
                    Relation_Data.AllowUserToAddRows = false;
                    Submit_button.Enabled = false;
                }
            else
            {

                int DeleteIndex = -1;
                for (int i = 0; i < Relation_Data.Rows.Count; i++)
                {
                    if (i == e.RowIndex || String.IsNullOrEmpty((string)Relation_Data[0, i].Value))
                        continue;
                    if (Relation_Data[0, i].Value.Equals(Relation_Data[0, e.RowIndex].Value))
                    {
                        DeleteIndex = i;
                        break;
                    }
                }
                if (DeleteIndex != -1)
                    Relation_Data.Rows.RemoveAt(DeleteIndex);
            }
            InitRelation();
        }

        private void Submit_button_Click(object sender, EventArgs e)
        {
            Table.Name = TableName_textBox.Text;


            
            if (isEdit)
            {
                Database.Remove(Tableindex);
                Database.Add(Tableindex, Table);
            }
            else
            {
                if(Database.Keys.Count == 0)
                {
                    Database.Add(0, Table);
                }
                else
                {
                    Database.Add(Database.Keys.Max() + 1, Table);

                }
            }

            Table.properites.has_Add = Add_checkBox.Checked;
            Table.properites.has_Update = Update_checkBox.Checked;
            Table.properites.has_Remove = Remove_checkBox.Checked;
            Table.properites.has_Find = Find_checkBox.Checked;
            Table.properites.has_Where = Where_checkBox.Checked;
            Table.properites.has_ToList = Tolist_checkBox.Checked;

            Table.Relations.Clear();
            for (int i = 0; i < Relation_Data.Rows.Count; i++)
            {
                if (!String.IsNullOrEmpty((string)Relation_Data[0, i].Value) && !String.IsNullOrEmpty((string)Relation_Data[1, i].Value))
                {
                    int key = Database.First(t => t.Value.Name.Equals(Relation_Data[0, i].Value)).Key;
                    int value = Relation_Type_Column.Items.IndexOf(Relation_Data[1, i].Value);
                    Table.Relations.Add(key, (Relation_Type)value);
                }

            }
            int Index = Database.Last(t=>t.Value.Name.Equals(Table.Name)).Key;
            if (isEdit)
            {
                foreach (Table item in Database.Values)
                {
                    if (item.Relations.ContainsKey(Index))
                        item.Relations.Remove(Index);
                }
            }

            foreach (KeyValuePair<int, Relation_Type> item in Table.Relations)
            {
                switch (item.Value)
                {
                    case Relation_Type.One_to_One:
                        break;
                    case Relation_Type.One_to_Many:
                        Database[item.Key].Relations.Add(Index, Relation_Type.Many_to_One);

                        break;
                    case Relation_Type.Many_to_One:
                        Database[item.Key].Relations.Add(Index, Relation_Type.One_to_Many);

                        break;
                    default:
                        break;
                }
            }

            this.Close();
        }

        private void Find_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(Find_checkBox.Checked == false)
            {
                Tolist_checkBox.Checked = false;
                Where_checkBox.Checked = false;
            }
        }

        private void Tolist_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(Tolist_checkBox.Checked == true)
            {
                Find_checkBox.Checked = true;
            }
        }

        private void Where_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Where_checkBox.Checked == true)
            {
                Find_checkBox.Checked = true;
            }
        }
    }
}
