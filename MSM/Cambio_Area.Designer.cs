namespace MSM
{
    partial class Cambio_Area
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
            this.textBoxNumeroEmpleado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelMostrarNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxNumeroEmpleado
            // 
            this.textBoxNumeroEmpleado.Location = new System.Drawing.Point(24, 36);
            this.textBoxNumeroEmpleado.Name = "textBoxNumeroEmpleado";
            this.textBoxNumeroEmpleado.Size = new System.Drawing.Size(187, 20);
            this.textBoxNumeroEmpleado.TabIndex = 0;
            this.textBoxNumeroEmpleado.TextChanged += new System.EventHandler(this.textBoxNumeroEmpleado_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelMostrarNombre
            // 
            this.labelMostrarNombre.AutoSize = true;
            this.labelMostrarNombre.Location = new System.Drawing.Point(27, 69);
            this.labelMostrarNombre.Name = "labelMostrarNombre";
            this.labelMostrarNombre.Size = new System.Drawing.Size(0, 13);
            this.labelMostrarNombre.TabIndex = 3;
            // 
            // Cambio_Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 166);
            this.Controls.Add(this.labelMostrarNombre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNumeroEmpleado);
            this.Name = "Cambio_Area";
            this.Text = "Cambio_Area";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNumeroEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMostrarNombre;
    }
}