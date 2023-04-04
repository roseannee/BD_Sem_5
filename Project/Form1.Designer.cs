namespace project
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.from_lbl = new System.Windows.Forms.Label();
            this.to_lbl = new System.Windows.Forms.Label();
            this.subject_lbl = new System.Windows.Forms.Label();
            this.content_lbl = new System.Windows.Forms.Label();
            this.from_cmb = new System.Windows.Forms.ComboBox();
            this.to_cmb = new System.Windows.Forms.ComboBox();
            this.subject_txt = new System.Windows.Forms.TextBox();
            this.content_rtx = new System.Windows.Forms.RichTextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.save_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.find_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // from_lbl
            // 
            this.from_lbl.AutoSize = true;
            this.from_lbl.Location = new System.Drawing.Point(143, 15);
            this.from_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.from_lbl.Name = "from_lbl";
            this.from_lbl.Size = new System.Drawing.Size(63, 25);
            this.from_lbl.TabIndex = 0;
            this.from_lbl.Text = "From:";
            // 
            // to_lbl
            // 
            this.to_lbl.AutoSize = true;
            this.to_lbl.Location = new System.Drawing.Point(143, 52);
            this.to_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.to_lbl.Name = "to_lbl";
            this.to_lbl.Size = new System.Drawing.Size(42, 25);
            this.to_lbl.TabIndex = 1;
            this.to_lbl.Text = "To:";
            // 
            // subject_lbl
            // 
            this.subject_lbl.AutoSize = true;
            this.subject_lbl.Location = new System.Drawing.Point(143, 89);
            this.subject_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subject_lbl.Name = "subject_lbl";
            this.subject_lbl.Size = new System.Drawing.Size(84, 25);
            this.subject_lbl.TabIndex = 2;
            this.subject_lbl.Text = "Subject:";
            // 
            // content_lbl
            // 
            this.content_lbl.AutoSize = true;
            this.content_lbl.Location = new System.Drawing.Point(143, 124);
            this.content_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.content_lbl.Name = "content_lbl";
            this.content_lbl.Size = new System.Drawing.Size(87, 25);
            this.content_lbl.TabIndex = 3;
            this.content_lbl.Text = "Content:";
            // 
            // from_cmb
            // 
            this.from_cmb.FormattingEnabled = true;
            this.from_cmb.Location = new System.Drawing.Point(259, 12);
            this.from_cmb.Name = "from_cmb";
            this.from_cmb.Size = new System.Drawing.Size(231, 33);
            this.from_cmb.TabIndex = 4;
            // 
            // to_cmb
            // 
            this.to_cmb.FormattingEnabled = true;
            this.to_cmb.Location = new System.Drawing.Point(259, 49);
            this.to_cmb.Name = "to_cmb";
            this.to_cmb.Size = new System.Drawing.Size(231, 33);
            this.to_cmb.TabIndex = 5;
            // 
            // subject_txt
            // 
            this.subject_txt.Location = new System.Drawing.Point(259, 86);
            this.subject_txt.Name = "subject_txt";
            this.subject_txt.Size = new System.Drawing.Size(231, 30);
            this.subject_txt.TabIndex = 6;
            // 
            // content_rtx
            // 
            this.content_rtx.Location = new System.Drawing.Point(259, 121);
            this.content_rtx.Name = "content_rtx";
            this.content_rtx.Size = new System.Drawing.Size(231, 83);
            this.content_rtx.TabIndex = 7;
            this.content_rtx.Text = "";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 317);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(593, 191);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.Click += new System.EventHandler(this.dataGridView_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(86, 237);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(113, 42);
            this.save_btn.TabIndex = 9;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(205, 237);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(113, 42);
            this.delete_btn.TabIndex = 10;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // find_btn
            // 
            this.find_btn.Location = new System.Drawing.Point(324, 237);
            this.find_btn.Name = "find_btn";
            this.find_btn.Size = new System.Drawing.Size(113, 42);
            this.find_btn.TabIndex = 11;
            this.find_btn.Text = "Find";
            this.find_btn.UseVisualStyleBackColor = true;
            this.find_btn.Click += new System.EventHandler(this.find_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(443, 237);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(113, 42);
            this.clear_btn.TabIndex = 12;
            this.clear_btn.Text = "Clear all";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 520);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.find_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.content_rtx);
            this.Controls.Add(this.subject_txt);
            this.Controls.Add(this.to_cmb);
            this.Controls.Add(this.from_cmb);
            this.Controls.Add(this.content_lbl);
            this.Controls.Add(this.subject_lbl);
            this.Controls.Add(this.to_lbl);
            this.Controls.Add(this.from_lbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "d";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label from_lbl;
        private System.Windows.Forms.Label to_lbl;
        private System.Windows.Forms.Label subject_lbl;
        private System.Windows.Forms.Label content_lbl;
        private System.Windows.Forms.ComboBox from_cmb;
        private System.Windows.Forms.ComboBox to_cmb;
        private System.Windows.Forms.TextBox subject_txt;
        private System.Windows.Forms.RichTextBox content_rtx;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button find_btn;
        private System.Windows.Forms.Button clear_btn;
    }
}

