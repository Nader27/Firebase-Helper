namespace FireBase_Helper
{
    partial class Start_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.add_button = new System.Windows.Forms.Button();
            this.submit_button = new System.Windows.Forms.Button();
            this.DatabaseGridView = new System.Windows.Forms.DataGridView();
            this.Table_Name_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit_Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete_Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(71, 197);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(139, 23);
            this.add_button.TabIndex = 0;
            this.add_button.Text = "Add Table";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.Add_button_Click);
            // 
            // submit_button
            // 
            this.submit_button.Location = new System.Drawing.Point(71, 226);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(139, 23);
            this.submit_button.TabIndex = 1;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = true;
            this.submit_button.Click += new System.EventHandler(this.Submit_button_Click);
            // 
            // DatabaseGridView
            // 
            this.DatabaseGridView.AllowUserToAddRows = false;
            this.DatabaseGridView.AllowUserToDeleteRows = false;
            this.DatabaseGridView.AllowUserToResizeColumns = false;
            this.DatabaseGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DatabaseGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.DatabaseGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DatabaseGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DatabaseGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DatabaseGridView.ColumnHeadersHeight = 25;
            this.DatabaseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DatabaseGridView.ColumnHeadersVisible = false;
            this.DatabaseGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Table_Name_Column,
            this.Edit_Column,
            this.Delete_Column});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DatabaseGridView.DefaultCellStyle = dataGridViewCellStyle19;
            this.DatabaseGridView.Location = new System.Drawing.Point(12, 12);
            this.DatabaseGridView.Name = "DatabaseGridView";
            this.DatabaseGridView.ReadOnly = true;
            this.DatabaseGridView.RowHeadersVisible = false;
            this.DatabaseGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DatabaseGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatabaseGridView.ShowCellErrors = false;
            this.DatabaseGridView.ShowCellToolTips = false;
            this.DatabaseGridView.ShowEditingIcon = false;
            this.DatabaseGridView.ShowRowErrors = false;
            this.DatabaseGridView.Size = new System.Drawing.Size(260, 179);
            this.DatabaseGridView.TabIndex = 2;
            this.DatabaseGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatabaseGridView_CellClick);
            // 
            // Table_Name_Column
            // 
            this.Table_Name_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Table_Name_Column.DefaultCellStyle = dataGridViewCellStyle16;
            this.Table_Name_Column.FillWeight = 133.2271F;
            this.Table_Name_Column.HeaderText = "Table_Name";
            this.Table_Name_Column.Name = "Table_Name_Column";
            this.Table_Name_Column.ReadOnly = true;
            this.Table_Name_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Edit_Column
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle17.NullValue")));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.Edit_Column.DefaultCellStyle = dataGridViewCellStyle17;
            this.Edit_Column.Description = "Edit";
            this.Edit_Column.FillWeight = 50F;
            this.Edit_Column.HeaderText = "Edit_Column";
            this.Edit_Column.Image = global::FireBase_Helper.Properties.Resources.edit_button_Image;
            this.Edit_Column.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edit_Column.Name = "Edit_Column";
            this.Edit_Column.ReadOnly = true;
            this.Edit_Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Edit_Column.Width = 50;
            // 
            // Delete_Column
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle18.NullValue")));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.Control;
            this.Delete_Column.DefaultCellStyle = dataGridViewCellStyle18;
            this.Delete_Column.Description = "Delete";
            this.Delete_Column.FillWeight = 50F;
            this.Delete_Column.HeaderText = "Delete_Column";
            this.Delete_Column.Image = global::FireBase_Helper.Properties.Resources.delete_button_Image;
            this.Delete_Column.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete_Column.Name = "Delete_Column";
            this.Delete_Column.ReadOnly = true;
            this.Delete_Column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Delete_Column.Width = 50;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle20.NullValue")));
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewImageColumn1.FillWeight = 50F;
            this.dataGridViewImageColumn1.HeaderText = "Edit_Column";
            this.dataGridViewImageColumn1.Image = global::FireBase_Helper.Properties.Resources.edit_button_Image;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle21.NullValue")));
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewImageColumn2.FillWeight = 50F;
            this.dataGridViewImageColumn2.HeaderText = "Delete_Column";
            this.dataGridViewImageColumn2.Image = global::FireBase_Helper.Properties.Resources.delete_button_Image;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "java";
            this.saveFileDialog.FileName = "FireBaseHelper";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "Class save location";
            // 
            // Start_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.DatabaseGridView);
            this.Controls.Add(this.submit_button);
            this.Controls.Add(this.add_button);
            this.Name = "Start_Form";
            this.Text = "Firebase Helper";
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.DataGridView DatabaseGridView;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Name_Column;
        private System.Windows.Forms.DataGridViewImageColumn Edit_Column;
        private System.Windows.Forms.DataGridViewImageColumn Delete_Column;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

