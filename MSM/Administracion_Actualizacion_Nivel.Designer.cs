namespace MSM
{
    partial class Administracion_Actualizacion_Nivel
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
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.comboBoxCertificacionEntrenamiento = new System.Windows.Forms.ComboBox();
            this.labelCertificacionEntrenamiento = new System.Windows.Forms.Label();
            this.labelNumeroEmpleado = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.comboBoxCodigo = new System.Windows.Forms.ComboBox();
            this.labelMostrarNombre = new System.Windows.Forms.Label();
            this.dateTimePickerFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.comboBoxNivelCompetencia = new System.Windows.Forms.ComboBox();
            this.labelNivelCompetencia = new System.Windows.Forms.Label();
            this.labelFechaInicioText = new System.Windows.Forms.Label();
            this.labelFechaVencimientoText = new System.Windows.Forms.Label();
            this.panelFechas = new System.Windows.Forms.Panel();
            this.labelFechaInicio = new System.Windows.Forms.Label();
            this.labelFechaVencimiento = new System.Windows.Forms.Label();
            this.panelFechas.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNumeroEmpleado
            // 
            this.textBoxNumeroEmpleado.Location = new System.Drawing.Point(37, 141);
            this.textBoxNumeroEmpleado.Name = "textBoxNumeroEmpleado";
            this.textBoxNumeroEmpleado.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumeroEmpleado.TabIndex = 0;
            this.textBoxNumeroEmpleado.TextChanged += new System.EventHandler(this.textBoxNumeroEmpleado_TextChanged);
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Location = new System.Drawing.Point(360, 230);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(75, 23);
            this.buttonActualizar.TabIndex = 1;
            this.buttonActualizar.Text = "Actualizar";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxCertificacionEntrenamiento
            // 
            this.comboBoxCertificacionEntrenamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCertificacionEntrenamiento.FormattingEnabled = true;
            this.comboBoxCertificacionEntrenamiento.Location = new System.Drawing.Point(37, 43);
            this.comboBoxCertificacionEntrenamiento.Name = "comboBoxCertificacionEntrenamiento";
            this.comboBoxCertificacionEntrenamiento.Size = new System.Drawing.Size(432, 21);
            this.comboBoxCertificacionEntrenamiento.TabIndex = 2;
            this.comboBoxCertificacionEntrenamiento.SelectedIndexChanged += new System.EventHandler(this.comboBoxCertificacionEntrenamiento_SelectedIndexChanged);
            // 
            // labelCertificacionEntrenamiento
            // 
            this.labelCertificacionEntrenamiento.AutoSize = true;
            this.labelCertificacionEntrenamiento.Location = new System.Drawing.Point(34, 27);
            this.labelCertificacionEntrenamiento.Name = "labelCertificacionEntrenamiento";
            this.labelCertificacionEntrenamiento.Size = new System.Drawing.Size(144, 13);
            this.labelCertificacionEntrenamiento.TabIndex = 3;
            this.labelCertificacionEntrenamiento.Text = "Certificacion o entrenamiento";
            // 
            // labelNumeroEmpleado
            // 
            this.labelNumeroEmpleado.AutoSize = true;
            this.labelNumeroEmpleado.Location = new System.Drawing.Point(34, 125);
            this.labelNumeroEmpleado.Name = "labelNumeroEmpleado";
            this.labelNumeroEmpleado.Size = new System.Drawing.Size(108, 13);
            this.labelNumeroEmpleado.TabIndex = 4;
            this.labelNumeroEmpleado.Text = "Numero de empleado";
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(34, 71);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(40, 13);
            this.labelCodigo.TabIndex = 6;
            this.labelCodigo.Text = "Codigo";
            // 
            // comboBoxCodigo
            // 
            this.comboBoxCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodigo.FormattingEnabled = true;
            this.comboBoxCodigo.Location = new System.Drawing.Point(37, 87);
            this.comboBoxCodigo.Name = "comboBoxCodigo";
            this.comboBoxCodigo.Size = new System.Drawing.Size(432, 21);
            this.comboBoxCodigo.TabIndex = 5;
            this.comboBoxCodigo.SelectedIndexChanged += new System.EventHandler(this.comboBoxCodigo_SelectedIndexChanged);
            // 
            // labelMostrarNombre
            // 
            this.labelMostrarNombre.AutoSize = true;
            this.labelMostrarNombre.Location = new System.Drawing.Point(164, 159);
            this.labelMostrarNombre.Name = "labelMostrarNombre";
            this.labelMostrarNombre.Size = new System.Drawing.Size(0, 13);
            this.labelMostrarNombre.TabIndex = 7;
            // 
            // dateTimePickerFechaVencimiento
            // 
            this.dateTimePickerFechaVencimiento.CustomFormat = "MMM-dd-yyyy";
            this.dateTimePickerFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFechaVencimiento.Location = new System.Drawing.Point(7, 18);
            this.dateTimePickerFechaVencimiento.Name = "dateTimePickerFechaVencimiento";
            this.dateTimePickerFechaVencimiento.Size = new System.Drawing.Size(105, 20);
            this.dateTimePickerFechaVencimiento.TabIndex = 8;
            this.dateTimePickerFechaVencimiento.Value = new System.DateTime(2022, 10, 5, 0, 0, 0, 0);
            this.dateTimePickerFechaVencimiento.ValueChanged += new System.EventHandler(this.dateTimePickerFechaVencimiento_ValueChanged);
            // 
            // comboBoxNivelCompetencia
            // 
            this.comboBoxNivelCompetencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNivelCompetencia.FormattingEnabled = true;
            this.comboBoxNivelCompetencia.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxNivelCompetencia.Location = new System.Drawing.Point(328, 141);
            this.comboBoxNivelCompetencia.Name = "comboBoxNivelCompetencia";
            this.comboBoxNivelCompetencia.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNivelCompetencia.TabIndex = 11;
            // 
            // labelNivelCompetencia
            // 
            this.labelNivelCompetencia.AutoSize = true;
            this.labelNivelCompetencia.Location = new System.Drawing.Point(325, 125);
            this.labelNivelCompetencia.Name = "labelNivelCompetencia";
            this.labelNivelCompetencia.Size = new System.Drawing.Size(110, 13);
            this.labelNivelCompetencia.TabIndex = 12;
            this.labelNivelCompetencia.Text = "Nivel de competencia";
            // 
            // labelFechaInicioText
            // 
            this.labelFechaInicioText.AutoSize = true;
            this.labelFechaInicioText.Location = new System.Drawing.Point(134, 18);
            this.labelFechaInicioText.Name = "labelFechaInicioText";
            this.labelFechaInicioText.Size = new System.Drawing.Size(79, 13);
            this.labelFechaInicioText.TabIndex = 13;
            this.labelFechaInicioText.Text = "Fecha de inicio";
            // 
            // labelFechaVencimientoText
            // 
            this.labelFechaVencimientoText.AutoSize = true;
            this.labelFechaVencimientoText.Location = new System.Drawing.Point(134, 65);
            this.labelFechaVencimientoText.Name = "labelFechaVencimientoText";
            this.labelFechaVencimientoText.Size = new System.Drawing.Size(112, 13);
            this.labelFechaVencimientoText.TabIndex = 14;
            this.labelFechaVencimientoText.Text = "Fecha de vencimiento";
            // 
            // panelFechas
            // 
            this.panelFechas.Controls.Add(this.labelFechaVencimiento);
            this.panelFechas.Controls.Add(this.labelFechaInicio);
            this.panelFechas.Controls.Add(this.dateTimePickerFechaVencimiento);
            this.panelFechas.Controls.Add(this.labelFechaVencimientoText);
            this.panelFechas.Controls.Add(this.labelFechaInicioText);
            this.panelFechas.Location = new System.Drawing.Point(30, 266);
            this.panelFechas.Name = "panelFechas";
            this.panelFechas.Size = new System.Drawing.Size(310, 113);
            this.panelFechas.TabIndex = 15;
            this.panelFechas.Visible = false;
            // 
            // labelFechaInicio
            // 
            this.labelFechaInicio.AutoSize = true;
            this.labelFechaInicio.Location = new System.Drawing.Point(134, 41);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(35, 13);
            this.labelFechaInicio.TabIndex = 15;
            this.labelFechaInicio.Text = "--/--/--";
            // 
            // labelFechaVencimiento
            // 
            this.labelFechaVencimiento.AutoSize = true;
            this.labelFechaVencimiento.Location = new System.Drawing.Point(134, 87);
            this.labelFechaVencimiento.Name = "labelFechaVencimiento";
            this.labelFechaVencimiento.Size = new System.Drawing.Size(35, 13);
            this.labelFechaVencimiento.TabIndex = 16;
            this.labelFechaVencimiento.Text = "--/--/--";
            // 
            // Administracion_Actualizacion_Nivel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 391);
            this.Controls.Add(this.panelFechas);
            this.Controls.Add(this.labelNivelCompetencia);
            this.Controls.Add(this.comboBoxNivelCompetencia);
            this.Controls.Add(this.labelMostrarNombre);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.comboBoxCodigo);
            this.Controls.Add(this.labelNumeroEmpleado);
            this.Controls.Add(this.labelCertificacionEntrenamiento);
            this.Controls.Add(this.comboBoxCertificacionEntrenamiento);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.textBoxNumeroEmpleado);
            this.Name = "Administracion_Actualizacion_Nivel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion_Actualizacion_Nivel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Administracion_Actualizacion_Nivel_FormClosed);
            this.Load += new System.EventHandler(this.Administracion_Actualizacion_Nivel_Load);
            this.panelFechas.ResumeLayout(false);
            this.panelFechas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNumeroEmpleado;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.ComboBox comboBoxCertificacionEntrenamiento;
        private System.Windows.Forms.Label labelCertificacionEntrenamiento;
        private System.Windows.Forms.Label labelNumeroEmpleado;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.ComboBox comboBoxCodigo;
        private System.Windows.Forms.Label labelMostrarNombre;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaVencimiento;
        private System.Windows.Forms.ComboBox comboBoxNivelCompetencia;
        private System.Windows.Forms.Label labelNivelCompetencia;
        private System.Windows.Forms.Label labelFechaInicioText;
        private System.Windows.Forms.Label labelFechaVencimientoText;
        private System.Windows.Forms.Panel panelFechas;
        private System.Windows.Forms.Label labelFechaVencimiento;
        private System.Windows.Forms.Label labelFechaInicio;
    }
}