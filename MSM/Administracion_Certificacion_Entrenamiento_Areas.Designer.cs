namespace MSM
{
    partial class Administracion_Certificacion_Entrenamiento_Areas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administracion_Certificacion_Entrenamiento_Areas));
            this.checkedListBoxAreas = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxAreas
            // 
            this.checkedListBoxAreas.FormattingEnabled = true;
            this.checkedListBoxAreas.Location = new System.Drawing.Point(12, 31);
            this.checkedListBoxAreas.Name = "checkedListBoxAreas";
            this.checkedListBoxAreas.Size = new System.Drawing.Size(178, 394);
            this.checkedListBoxAreas.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Administracion_Certificacion_Entrenamiento_Areas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 493);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBoxAreas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Administracion_Certificacion_Entrenamiento_Areas";
            this.Text = "Administracion_Certificacion_Entrenamiento_Areas";
            this.Load += new System.EventHandler(this.Administracion_Certificacion_Entrenamiento_Areas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxAreas;
        private System.Windows.Forms.Button button1;
    }
}