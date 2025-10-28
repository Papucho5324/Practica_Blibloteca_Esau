namespace Practica_Blibloteca
{
    partial class Form1
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
            this.etc = new System.Windows.Forms.TabControl();
            this.tabPageOperaciones = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRealizarDevolucion = new System.Windows.Forms.Button();
            this.dgvPrestamosActivos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRealizarPrestamo = new System.Windows.Forms.Button();
            this.lblInfoPrestamo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSocio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageCatalogo = new System.Windows.Forms.TabPage();
            this.tabPageSocios = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.btnAgregarLibro = new System.Windows.Forms.Button();
            this.btnAgregarRevista = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.btnVerificarSanciones = new System.Windows.Forms.Button();
            this.btnAgregarSocio = new System.Windows.Forms.Button();
            this.btnEliminarSocio = new System.Windows.Forms.Button();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.etc.SuspendLayout();
            this.tabPageOperaciones.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).BeginInit();
            this.tabPageCatalogo.SuspendLayout();
            this.tabPageSocios.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.SuspendLayout();
            // 
            // etc
            // 
            this.etc.Controls.Add(this.tabPageOperaciones);
            this.etc.Controls.Add(this.tabPageCatalogo);
            this.etc.Controls.Add(this.tabPageSocios);
            this.etc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etc.Location = new System.Drawing.Point(0, 0);
            this.etc.Name = "etc";
            this.etc.SelectedIndex = 0;
            this.etc.Size = new System.Drawing.Size(1128, 587);
            this.etc.TabIndex = 0;
            // 
            // tabPageOperaciones
            // 
            this.tabPageOperaciones.Controls.Add(this.groupBox1);
            this.tabPageOperaciones.Location = new System.Drawing.Point(4, 25);
            this.tabPageOperaciones.Name = "tabPageOperaciones";
            this.tabPageOperaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOperaciones.Size = new System.Drawing.Size(1120, 558);
            this.tabPageOperaciones.TabIndex = 0;
            this.tabPageOperaciones.Text = "Préstamos y Devoluciones";
            this.tabPageOperaciones.UseVisualStyleBackColor = true;
            this.tabPageOperaciones.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMaterial);
            this.groupBox1.Controls.Add(this.btnRealizarDevolucion);
            this.groupBox1.Controls.Add(this.dgvPrestamosActivos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRealizarPrestamo);
            this.groupBox1.Controls.Add(this.lblInfoPrestamo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSocio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1114, 2608);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnRealizarDevolucion
            // 
            this.btnRealizarDevolucion.Location = new System.Drawing.Point(440, 479);
            this.btnRealizarDevolucion.Name = "btnRealizarDevolucion";
            this.btnRealizarDevolucion.Size = new System.Drawing.Size(191, 38);
            this.btnRealizarDevolucion.TabIndex = 10;
            this.btnRealizarDevolucion.Text = "Realizar Devolucion";
            this.btnRealizarDevolucion.UseVisualStyleBackColor = true;
            this.btnRealizarDevolucion.Click += new System.EventHandler(this.btnRealizarDevolucion_Click);
            // 
            // dgvPrestamosActivos
            // 
            this.dgvPrestamosActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamosActivos.Location = new System.Drawing.Point(33, 154);
            this.dgvPrestamosActivos.Name = "dgvPrestamosActivos";
            this.dgvPrestamosActivos.RowHeadersWidth = 51;
            this.dgvPrestamosActivos.RowTemplate.Height = 24;
            this.dgvPrestamosActivos.Size = new System.Drawing.Size(1032, 307);
            this.dgvPrestamosActivos.TabIndex = 9;
            this.dgvPrestamosActivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrestamosActivos_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(390, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Prestamos Activos";
            // 
            // btnRealizarPrestamo
            // 
            this.btnRealizarPrestamo.Location = new System.Drawing.Point(705, 43);
            this.btnRealizarPrestamo.Name = "btnRealizarPrestamo";
            this.btnRealizarPrestamo.Size = new System.Drawing.Size(170, 30);
            this.btnRealizarPrestamo.TabIndex = 7;
            this.btnRealizarPrestamo.Text = "Solicitar";
            this.btnRealizarPrestamo.UseVisualStyleBackColor = true;
            this.btnRealizarPrestamo.Click += new System.EventHandler(this.btnRealizarPrestamo_Click);
            // 
            // lblInfoPrestamo
            // 
            this.lblInfoPrestamo.AutoSize = true;
            this.lblInfoPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPrestamo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblInfoPrestamo.Location = new System.Drawing.Point(934, 51);
            this.lblInfoPrestamo.Name = "lblInfoPrestamo";
            this.lblInfoPrestamo.Size = new System.Drawing.Size(0, 20);
            this.lblInfoPrestamo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material";
            // 
            // txtSocio
            // 
            this.txtSocio.Location = new System.Drawing.Point(168, 45);
            this.txtSocio.Name = "txtSocio";
            this.txtSocio.Size = new System.Drawing.Size(162, 22);
            this.txtSocio.TabIndex = 1;
            this.txtSocio.TextChanged += new System.EventHandler(this.txtIdSocio_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Socio";
            // 
            // tabPageCatalogo
            // 
            this.tabPageCatalogo.Controls.Add(this.groupBox2);
            this.tabPageCatalogo.Location = new System.Drawing.Point(4, 25);
            this.tabPageCatalogo.Name = "tabPageCatalogo";
            this.tabPageCatalogo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCatalogo.Size = new System.Drawing.Size(1120, 558);
            this.tabPageCatalogo.TabIndex = 1;
            this.tabPageCatalogo.Text = "Catálogo";
            this.tabPageCatalogo.UseVisualStyleBackColor = true;
            // 
            // tabPageSocios
            // 
            this.tabPageSocios.Controls.Add(this.groupBox3);
            this.tabPageSocios.Location = new System.Drawing.Point(4, 25);
            this.tabPageSocios.Name = "tabPageSocios";
            this.tabPageSocios.Size = new System.Drawing.Size(1120, 558);
            this.tabPageSocios.TabIndex = 2;
            this.tabPageSocios.Text = "Socios";
            this.tabPageSocios.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnAgregarRevista);
            this.groupBox2.Controls.Add(this.btnAgregarLibro);
            this.groupBox2.Controls.Add(this.dgvCatalogo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1114, 552);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(212, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(381, 46);
            this.label4.TabIndex = 0;
            this.label4.Text = "Catalogo Completo";
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatalogo.Location = new System.Drawing.Point(34, 106);
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.RowHeadersWidth = 51;
            this.dgvCatalogo.RowTemplate.Height = 24;
            this.dgvCatalogo.Size = new System.Drawing.Size(843, 408);
            this.dgvCatalogo.TabIndex = 1;
            // 
            // btnAgregarLibro
            // 
            this.btnAgregarLibro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAgregarLibro.Location = new System.Drawing.Point(931, 180);
            this.btnAgregarLibro.Name = "btnAgregarLibro";
            this.btnAgregarLibro.Size = new System.Drawing.Size(140, 53);
            this.btnAgregarLibro.TabIndex = 2;
            this.btnAgregarLibro.Text = "Agregar Libro";
            this.btnAgregarLibro.UseVisualStyleBackColor = false;
            this.btnAgregarLibro.Click += new System.EventHandler(this.btnAgregarLibro_Click);
            // 
            // btnAgregarRevista
            // 
            this.btnAgregarRevista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAgregarRevista.Location = new System.Drawing.Point(931, 292);
            this.btnAgregarRevista.Name = "btnAgregarRevista";
            this.btnAgregarRevista.Size = new System.Drawing.Size(140, 53);
            this.btnAgregarRevista.TabIndex = 3;
            this.btnAgregarRevista.Text = "Agregar Revista";
            this.btnAgregarRevista.UseVisualStyleBackColor = false;
            this.btnAgregarRevista.Click += new System.EventHandler(this.btnAgregarRevista_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminar.Location = new System.Drawing.Point(931, 399);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEliminar.Size = new System.Drawing.Size(140, 53);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEliminarSocio);
            this.groupBox3.Controls.Add(this.btnVerificarSanciones);
            this.groupBox3.Controls.Add(this.btnAgregarSocio);
            this.groupBox3.Controls.Add(this.dgvSocios);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1120, 558);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(265, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 46);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lista de Socios";
            // 
            // dgvSocios
            // 
            this.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocios.Location = new System.Drawing.Point(21, 108);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.RowHeadersWidth = 51;
            this.dgvSocios.RowTemplate.Height = 24;
            this.dgvSocios.Size = new System.Drawing.Size(896, 442);
            this.dgvSocios.TabIndex = 1;
            // 
            // btnVerificarSanciones
            // 
            this.btnVerificarSanciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnVerificarSanciones.Location = new System.Drawing.Point(951, 312);
            this.btnVerificarSanciones.Name = "btnVerificarSanciones";
            this.btnVerificarSanciones.Size = new System.Drawing.Size(140, 53);
            this.btnVerificarSanciones.TabIndex = 5;
            this.btnVerificarSanciones.Text = "Actualizar Sanciones";
            this.btnVerificarSanciones.UseVisualStyleBackColor = false;
            this.btnVerificarSanciones.Click += new System.EventHandler(this.btnVerificarSanciones_Click);
            // 
            // btnAgregarSocio
            // 
            this.btnAgregarSocio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAgregarSocio.Location = new System.Drawing.Point(951, 239);
            this.btnAgregarSocio.Name = "btnAgregarSocio";
            this.btnAgregarSocio.Size = new System.Drawing.Size(140, 53);
            this.btnAgregarSocio.TabIndex = 4;
            this.btnAgregarSocio.Text = "Agregar Socio";
            this.btnAgregarSocio.UseVisualStyleBackColor = false;
            this.btnAgregarSocio.Click += new System.EventHandler(this.btnAgregarSocio_Click);
            // 
            // btnEliminarSocio
            // 
            this.btnEliminarSocio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminarSocio.Location = new System.Drawing.Point(951, 386);
            this.btnEliminarSocio.Name = "btnEliminarSocio";
            this.btnEliminarSocio.Size = new System.Drawing.Size(140, 53);
            this.btnEliminarSocio.TabIndex = 6;
            this.btnEliminarSocio.Text = "Eliminar";
            this.btnEliminarSocio.UseVisualStyleBackColor = false;
            this.btnEliminarSocio.Click += new System.EventHandler(this.btnEliminarSocio_Click);
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(480, 43);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(174, 24);
            this.cmbMaterial.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 587);
            this.Controls.Add(this.etc);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blibloteca";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.etc.ResumeLayout(false);
            this.tabPageOperaciones.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamosActivos)).EndInit();
            this.tabPageCatalogo.ResumeLayout(false);
            this.tabPageSocios.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl etc;
        private System.Windows.Forms.TabPage tabPageOperaciones;
        private System.Windows.Forms.TabPage tabPageCatalogo;
        private System.Windows.Forms.TabPage tabPageSocios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRealizarPrestamo;
        private System.Windows.Forms.Label lblInfoPrestamo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSocio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRealizarDevolucion;
        private System.Windows.Forms.DataGridView dgvPrestamosActivos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregarRevista;
        private System.Windows.Forms.Button btnAgregarLibro;
        private System.Windows.Forms.DataGridView dgvCatalogo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnVerificarSanciones;
        private System.Windows.Forms.Button btnAgregarSocio;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEliminarSocio;
        private System.Windows.Forms.ComboBox cmbMaterial;
    }
}

