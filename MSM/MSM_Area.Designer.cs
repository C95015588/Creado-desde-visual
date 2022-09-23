namespace MSM
{
    partial class MSM_Area
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewMultiskill = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxArea = new System.Windows.Forms.ComboBox();
            this.TittleBar = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonMinimizar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMultiskill)).BeginInit();
            this.TittleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMultiskill
            // 
            this.dataGridViewMultiskill.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.dataGridViewMultiskill.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(17)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMultiskill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMultiskill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMultiskill.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMultiskill.EnableHeadersVisualStyles = false;
            this.dataGridViewMultiskill.Location = new System.Drawing.Point(12, 198);
            this.dataGridViewMultiskill.Name = "dataGridViewMultiskill";
            this.dataGridViewMultiskill.RowHeadersVisible = false;
            this.dataGridViewMultiskill.Size = new System.Drawing.Size(1359, 539);
            this.dataGridViewMultiskill.TabIndex = 0;
            this.dataGridViewMultiskill.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMultiskill_ColumnHeaderMouseClick);
            this.dataGridViewMultiskill.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMultiskill_ColumnHeaderMouseDoubleClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(17)))), ((int)(((byte)(38)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(229, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar/Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxArea
            // 
            this.comboBoxArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxArea.FormattingEnabled = true;
            this.comboBoxArea.Location = new System.Drawing.Point(23, 154);
            this.comboBoxArea.Name = "comboBoxArea";
            this.comboBoxArea.Size = new System.Drawing.Size(200, 21);
            this.comboBoxArea.TabIndex = 2;
            // 
            // TittleBar
            // 
            this.TittleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.TittleBar.Controls.Add(this.button2);
            this.TittleBar.Controls.Add(this.buttonMinimizar);
            this.TittleBar.Controls.Add(this.buttonCerrar);
            this.TittleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TittleBar.Location = new System.Drawing.Point(0, 0);
            this.TittleBar.Name = "TittleBar";
            this.TittleBar.Size = new System.Drawing.Size(1383, 30);
            this.TittleBar.TabIndex = 25;
            this.TittleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            this.TittleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TittleBar_MouseMove);
            this.TittleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(1281, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonMinimizar
            // 
            this.buttonMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinimizar.FlatAppearance.BorderSize = 0;
            this.buttonMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinimizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMinimizar.Location = new System.Drawing.Point(1315, 0);
            this.buttonMinimizar.Name = "buttonMinimizar";
            this.buttonMinimizar.Size = new System.Drawing.Size(34, 30);
            this.buttonMinimizar.TabIndex = 1;
            this.buttonMinimizar.Text = "-";
            this.buttonMinimizar.UseVisualStyleBackColor = false;
            this.buttonMinimizar.Click += new System.EventHandler(this.buttonMinimizar_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.BackColor = System.Drawing.Color.Transparent;
            this.buttonCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCerrar.FlatAppearance.BorderSize = 0;
            this.buttonCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCerrar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCerrar.Location = new System.Drawing.Point(1349, 0);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(34, 30);
            this.buttonCerrar.TabIndex = 0;
            this.buttonCerrar.Text = "X";
            this.buttonCerrar.UseVisualStyleBackColor = false;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(18, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 89);
            this.panel1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(298, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Check the multiskillmatrix by area";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Consulta las multiskillmatrix por area";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(298, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 16);
            this.label8.TabIndex = 27;
            this.label8.Text = "multiskillmatrix by area";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Snow;
            this.label9.Location = new System.Drawing.Point(0, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(292, 30);
            this.label9.TabIndex = 23;
            this.label9.Text = "Multiskillmatrix por area";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "Seleccionar area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(142, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Select area";
            // 
            // MSM_Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1383, 749);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TittleBar);
            this.Controls.Add(this.comboBoxArea);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewMultiskill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MSM_Area";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSM_Area";
            this.Load += new System.EventHandler(this.MSM_Area_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMultiskill)).EndInit();
            this.TittleBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMultiskill;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxArea;
        private System.Windows.Forms.Panel TittleBar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonMinimizar;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}