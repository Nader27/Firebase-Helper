namespace FireBase_Helper
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.TableName_textBox = new System.Windows.Forms.TextBox();
            this.Columns_data = new System.Windows.Forms.DataGridView();
            this.column_Name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columns_groupBox = new System.Windows.Forms.GroupBox();
            this.Properites_groupBox = new System.Windows.Forms.GroupBox();
            this.Tolist_checkBox = new System.Windows.Forms.CheckBox();
            this.Where_checkBox = new System.Windows.Forms.CheckBox();
            this.Find_checkBox = new System.Windows.Forms.CheckBox();
            this.Remove_checkBox = new System.Windows.Forms.CheckBox();
            this.Update_checkBox = new System.Windows.Forms.CheckBox();
            this.Add_checkBox = new System.Windows.Forms.CheckBox();
            this.Relations_groupBox = new System.Windows.Forms.GroupBox();
            this.Relation_Data = new System.Windows.Forms.DataGridView();
            this.Relation_Table_Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Relation_Type_Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AddForm_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.focus_button = new System.Windows.Forms.Button();
            this.Submit_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Columns_data)).BeginInit();
            this.Columns_groupBox.SuspendLayout();
            this.Properites_groupBox.SuspendLayout();
            this.Relations_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Relation_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddForm_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table Name : ";
            // 
            // TableName_textBox
            // 
            this.TableName_textBox.Location = new System.Drawing.Point(89, 9);
            this.TableName_textBox.Name = "TableName_textBox";
            this.TableName_textBox.Size = new System.Drawing.Size(242, 20);
            this.TableName_textBox.TabIndex = 2;
            this.TableName_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TableName_textBox_KeyPress);
            this.TableName_textBox.Validating += new System.ComponentModel.CancelEventHandler(this.TableName_textBox_Validating);
            this.TableName_textBox.Validated += new System.EventHandler(this.TableName_textBox_Validated);
            // 
            // Columns_data
            // 
            this.Columns_data.AllowUserToResizeColumns = false;
            this.Columns_data.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Columns_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Columns_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Columns_data.ColumnHeadersVisible = false;
            this.Columns_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_Name_Column});
            this.Columns_data.Location = new System.Drawing.Point(3, 16);
            this.Columns_data.MultiSelect = false;
            this.Columns_data.Name = "Columns_data";
            this.Columns_data.RowHeadersVisible = false;
            this.Columns_data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.Columns_data.RowTemplate.Height = 25;
            this.Columns_data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Columns_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Columns_data.Size = new System.Drawing.Size(148, 147);
            this.Columns_data.TabIndex = 4;
            this.Columns_data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Columns_data_CellEndEdit);
            this.Columns_data.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Columns_data_UserDeletingRow);
            // 
            // column_Name_Column
            // 
            this.column_Name_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column_Name_Column.HeaderText = "Column Name";
            this.column_Name_Column.MinimumWidth = 100;
            this.column_Name_Column.Name = "column_Name_Column";
            this.column_Name_Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column_Name_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Columns_groupBox
            // 
            this.Columns_groupBox.Controls.Add(this.Columns_data);
            this.Columns_groupBox.Enabled = false;
            this.Columns_groupBox.Location = new System.Drawing.Point(15, 35);
            this.Columns_groupBox.Name = "Columns_groupBox";
            this.Columns_groupBox.Size = new System.Drawing.Size(177, 166);
            this.Columns_groupBox.TabIndex = 5;
            this.Columns_groupBox.TabStop = false;
            this.Columns_groupBox.Text = "Columns";
            // 
            // Properites_groupBox
            // 
            this.Properites_groupBox.Controls.Add(this.Tolist_checkBox);
            this.Properites_groupBox.Controls.Add(this.Where_checkBox);
            this.Properites_groupBox.Controls.Add(this.Find_checkBox);
            this.Properites_groupBox.Controls.Add(this.Remove_checkBox);
            this.Properites_groupBox.Controls.Add(this.Update_checkBox);
            this.Properites_groupBox.Controls.Add(this.Add_checkBox);
            this.Properites_groupBox.Enabled = false;
            this.Properites_groupBox.Location = new System.Drawing.Point(198, 36);
            this.Properites_groupBox.Name = "Properites_groupBox";
            this.Properites_groupBox.Size = new System.Drawing.Size(149, 165);
            this.Properites_groupBox.TabIndex = 6;
            this.Properites_groupBox.TabStop = false;
            this.Properites_groupBox.Text = "Properites";
            // 
            // Tolist_checkBox
            // 
            this.Tolist_checkBox.AutoSize = true;
            this.Tolist_checkBox.Checked = true;
            this.Tolist_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Tolist_checkBox.Location = new System.Drawing.Point(7, 140);
            this.Tolist_checkBox.Name = "Tolist_checkBox";
            this.Tolist_checkBox.Size = new System.Drawing.Size(51, 17);
            this.Tolist_checkBox.TabIndex = 5;
            this.Tolist_checkBox.Text = "Tolist";
            this.Tolist_checkBox.UseVisualStyleBackColor = true;
            this.Tolist_checkBox.CheckedChanged += new System.EventHandler(this.Tolist_checkBox_CheckedChanged);
            // 
            // Where_checkBox
            // 
            this.Where_checkBox.AutoSize = true;
            this.Where_checkBox.Checked = true;
            this.Where_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Where_checkBox.Location = new System.Drawing.Point(7, 116);
            this.Where_checkBox.Name = "Where_checkBox";
            this.Where_checkBox.Size = new System.Drawing.Size(58, 17);
            this.Where_checkBox.TabIndex = 4;
            this.Where_checkBox.Text = "Where";
            this.Where_checkBox.UseVisualStyleBackColor = true;
            this.Where_checkBox.CheckedChanged += new System.EventHandler(this.Where_checkBox_CheckedChanged);
            // 
            // Find_checkBox
            // 
            this.Find_checkBox.AutoSize = true;
            this.Find_checkBox.Checked = true;
            this.Find_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Find_checkBox.Location = new System.Drawing.Point(7, 92);
            this.Find_checkBox.Name = "Find_checkBox";
            this.Find_checkBox.Size = new System.Drawing.Size(75, 17);
            this.Find_checkBox.TabIndex = 3;
            this.Find_checkBox.Text = "FindbyKey";
            this.Find_checkBox.UseVisualStyleBackColor = true;
            this.Find_checkBox.CheckedChanged += new System.EventHandler(this.Find_checkBox_CheckedChanged);
            // 
            // Remove_checkBox
            // 
            this.Remove_checkBox.AutoSize = true;
            this.Remove_checkBox.Checked = true;
            this.Remove_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Remove_checkBox.Location = new System.Drawing.Point(7, 68);
            this.Remove_checkBox.Name = "Remove_checkBox";
            this.Remove_checkBox.Size = new System.Drawing.Size(66, 17);
            this.Remove_checkBox.TabIndex = 2;
            this.Remove_checkBox.Text = "Remove";
            this.Remove_checkBox.UseVisualStyleBackColor = true;
            // 
            // Update_checkBox
            // 
            this.Update_checkBox.AutoSize = true;
            this.Update_checkBox.Checked = true;
            this.Update_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Update_checkBox.Location = new System.Drawing.Point(7, 44);
            this.Update_checkBox.Name = "Update_checkBox";
            this.Update_checkBox.Size = new System.Drawing.Size(61, 17);
            this.Update_checkBox.TabIndex = 1;
            this.Update_checkBox.Text = "Update";
            this.Update_checkBox.UseVisualStyleBackColor = true;
            // 
            // Add_checkBox
            // 
            this.Add_checkBox.AutoSize = true;
            this.Add_checkBox.Checked = true;
            this.Add_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Add_checkBox.Location = new System.Drawing.Point(7, 20);
            this.Add_checkBox.Name = "Add_checkBox";
            this.Add_checkBox.Size = new System.Drawing.Size(45, 17);
            this.Add_checkBox.TabIndex = 0;
            this.Add_checkBox.Text = "Add";
            this.Add_checkBox.UseVisualStyleBackColor = true;
            // 
            // Relations_groupBox
            // 
            this.Relations_groupBox.Controls.Add(this.Relation_Data);
            this.Relations_groupBox.Enabled = false;
            this.Relations_groupBox.Location = new System.Drawing.Point(18, 207);
            this.Relations_groupBox.Name = "Relations_groupBox";
            this.Relations_groupBox.Size = new System.Drawing.Size(329, 120);
            this.Relations_groupBox.TabIndex = 7;
            this.Relations_groupBox.TabStop = false;
            this.Relations_groupBox.Text = "Relations";
            // 
            // Relation_Data
            // 
            this.Relation_Data.AllowUserToResizeColumns = false;
            this.Relation_Data.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Relation_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Relation_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Relation_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Relation_Table_Column,
            this.Relation_Type_Column});
            this.Relation_Data.Location = new System.Drawing.Point(3, 16);
            this.Relation_Data.MultiSelect = false;
            this.Relation_Data.Name = "Relation_Data";
            this.Relation_Data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.Relation_Data.RowTemplate.Height = 25;
            this.Relation_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Relation_Data.Size = new System.Drawing.Size(310, 101);
            this.Relation_Data.TabIndex = 5;
            this.Relation_Data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Relation_Data_CellEndEdit);
            // 
            // Relation_Table_Column
            // 
            this.Relation_Table_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Relation_Table_Column.HeaderText = "Relation Table";
            this.Relation_Table_Column.MinimumWidth = 100;
            this.Relation_Table_Column.Name = "Relation_Table_Column";
            this.Relation_Table_Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Relation_Type_Column
            // 
            this.Relation_Type_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Relation_Type_Column.HeaderText = "Relation Type";
            this.Relation_Type_Column.Items.AddRange(new object[] {
            "One to One",
            "One to Many",
            "Many to One"});
            this.Relation_Type_Column.Name = "Relation_Type_Column";
            // 
            // AddForm_errorProvider
            // 
            this.AddForm_errorProvider.ContainerControl = this;
            // 
            // focus_button
            // 
            this.focus_button.Location = new System.Drawing.Point(0, 0);
            this.focus_button.Name = "focus_button";
            this.focus_button.Size = new System.Drawing.Size(0, 0);
            this.focus_button.TabIndex = 8;
            this.focus_button.UseVisualStyleBackColor = true;
            // 
            // Submit_button
            // 
            this.Submit_button.Enabled = false;
            this.Submit_button.Location = new System.Drawing.Point(132, 330);
            this.Submit_button.Name = "Submit_button";
            this.Submit_button.Size = new System.Drawing.Size(75, 23);
            this.Submit_button.TabIndex = 9;
            this.Submit_button.Text = "Submit";
            this.Submit_button.UseVisualStyleBackColor = true;
            this.Submit_button.Click += new System.EventHandler(this.Submit_button_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 359);
            this.Controls.Add(this.Submit_button);
            this.Controls.Add(this.focus_button);
            this.Controls.Add(this.Relations_groupBox);
            this.Controls.Add(this.Properites_groupBox);
            this.Controls.Add(this.Columns_groupBox);
            this.Controls.Add(this.TableName_textBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.Text = "Add Table";
            ((System.ComponentModel.ISupportInitialize)(this.Columns_data)).EndInit();
            this.Columns_groupBox.ResumeLayout(false);
            this.Properites_groupBox.ResumeLayout(false);
            this.Properites_groupBox.PerformLayout();
            this.Relations_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Relation_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddForm_errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TableName_textBox;
        private System.Windows.Forms.DataGridView Columns_data;
        private System.Windows.Forms.GroupBox Columns_groupBox;
        private System.Windows.Forms.GroupBox Properites_groupBox;
        private System.Windows.Forms.CheckBox Tolist_checkBox;
        private System.Windows.Forms.CheckBox Where_checkBox;
        private System.Windows.Forms.CheckBox Find_checkBox;
        private System.Windows.Forms.CheckBox Remove_checkBox;
        private System.Windows.Forms.CheckBox Update_checkBox;
        private System.Windows.Forms.CheckBox Add_checkBox;
        private System.Windows.Forms.GroupBox Relations_groupBox;
        private System.Windows.Forms.DataGridView Relation_Data;
        private System.Windows.Forms.ErrorProvider AddForm_errorProvider;
        private System.Windows.Forms.Button focus_button;
        private System.Windows.Forms.Button Submit_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_Name_Column;
        private System.Windows.Forms.DataGridViewComboBoxColumn Relation_Table_Column;
        private System.Windows.Forms.DataGridViewComboBoxColumn Relation_Type_Column;
    }
}