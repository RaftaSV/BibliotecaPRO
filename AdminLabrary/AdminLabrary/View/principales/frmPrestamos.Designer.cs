namespace AdminLabrary.View.principales
{
    partial class FrmPrestamos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrestamos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnVer = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnRetrazo = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LECTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIBRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENTREGADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDLector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entregadoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recibir = new System.Windows.Forms.DataGridViewImageColumn();
            this.rbtnLector = new System.Windows.Forms.RadioButton();
            this.rbtnLibro = new System.Windows.Forms.RadioButton();
            this.rbtnAdministrador = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVer
            // 
            this.btnVer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVer.BackColor = System.Drawing.Color.Teal;
            this.btnVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVer.FlatAppearance.BorderSize = 2;
            this.btnVer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnVer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer.ForeColor = System.Drawing.Color.White;
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(182, 96);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(157, 46);
            this.btnVer.TabIndex = 15;
            this.btnVer.Text = "         PRESTAMOS         FINALIZADOS";
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscar.Location = new System.Drawing.Point(12, 64);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtBuscar.Size = new System.Drawing.Size(502, 26);
            this.txtBuscar.TabIndex = 16;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnRetrazo
            // 
            this.btnRetrazo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRetrazo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRetrazo.BackColor = System.Drawing.Color.Teal;
            this.btnRetrazo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetrazo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRetrazo.FlatAppearance.BorderSize = 2;
            this.btnRetrazo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnRetrazo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnRetrazo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetrazo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetrazo.ForeColor = System.Drawing.Color.White;
            this.btnRetrazo.Image = ((System.Drawing.Image)(resources.GetObject("btnRetrazo.Image")));
            this.btnRetrazo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetrazo.Location = new System.Drawing.Point(350, 96);
            this.btnRetrazo.Name = "btnRetrazo";
            this.btnRetrazo.Size = new System.Drawing.Size(164, 46);
            this.btnRetrazo.TabIndex = 20;
            this.btnRetrazo.Text = "HISTORIAL CON RETRASO";
            this.btnRetrazo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetrazo.UseVisualStyleBackColor = false;
            this.btnRetrazo.Click += new System.EventHandler(this.btnRetrazo_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNuevo.BackColor = System.Drawing.Color.Teal;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(11, 96);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(155, 46);
            this.btnNuevo.TabIndex = 21;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(476, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(520, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(430, 135);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPrestamos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPrestamos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrestamos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrestamos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrestamos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.LECTOR,
            this.LIBRO,
            this.CANTIDAD,
            this.ENTREGADO,
            this.FECHAS,
            this.FECHAP,
            this.IDLector,
            this.IDLibro,
            this.Entregadoid,
            this.Recibir});
            this.dgvPrestamos.GridColor = System.Drawing.Color.Teal;
            this.dgvPrestamos.Location = new System.Drawing.Point(-2, 168);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.ReadOnly = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPrestamos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPrestamos.Size = new System.Drawing.Size(952, 324);
            this.dgvPrestamos.TabIndex = 2;
            this.dgvPrestamos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrestamos_CellContentClick_1);
            // 
            // ID
            // 
            this.ID.FillWeight = 50F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // LECTOR
            // 
            this.LECTOR.FillWeight = 119.5357F;
            this.LECTOR.HeaderText = "LECTOR";
            this.LECTOR.Name = "LECTOR";
            this.LECTOR.ReadOnly = true;
            // 
            // LIBRO
            // 
            this.LIBRO.FillWeight = 149.4195F;
            this.LIBRO.HeaderText = "LIBRO";
            this.LIBRO.Name = "LIBRO";
            this.LIBRO.ReadOnly = true;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.FillWeight = 59.76783F;
            this.CANTIDAD.HeaderText = "CANTIDAD";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            // 
            // ENTREGADO
            // 
            this.ENTREGADO.FillWeight = 59.76783F;
            this.ENTREGADO.HeaderText = "ENTREGADO POR";
            this.ENTREGADO.Name = "ENTREGADO";
            this.ENTREGADO.ReadOnly = true;
            // 
            // FECHAS
            // 
            this.FECHAS.FillWeight = 99.61308F;
            this.FECHAS.HeaderText = "FECHA  DE SALIDA";
            this.FECHAS.Name = "FECHAS";
            this.FECHAS.ReadOnly = true;
            // 
            // FECHAP
            // 
            this.FECHAP.FillWeight = 99.61308F;
            this.FECHAP.HeaderText = "FECHA PREVISTA ENTREGA";
            this.FECHAP.Name = "FECHAP";
            this.FECHAP.ReadOnly = true;
            // 
            // IDLector
            // 
            this.IDLector.HeaderText = "IDLector";
            this.IDLector.Name = "IDLector";
            this.IDLector.ReadOnly = true;
            this.IDLector.Visible = false;
            // 
            // IDLibro
            // 
            this.IDLibro.HeaderText = "IDLibro";
            this.IDLibro.Name = "IDLibro";
            this.IDLibro.ReadOnly = true;
            this.IDLibro.Visible = false;
            // 
            // Entregadoid
            // 
            this.Entregadoid.HeaderText = "Entregadoid";
            this.Entregadoid.MinimumWidth = 100;
            this.Entregadoid.Name = "Entregadoid";
            this.Entregadoid.ReadOnly = true;
            this.Entregadoid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Entregadoid.Visible = false;
            // 
            // Recibir
            // 
            this.Recibir.FillWeight = 77.68674F;
            this.Recibir.HeaderText = "RECIBIR";
            this.Recibir.Image = ((System.Drawing.Image)(resources.GetObject("Recibir.Image")));
            this.Recibir.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Recibir.MinimumWidth = 23;
            this.Recibir.Name = "Recibir";
            this.Recibir.ReadOnly = true;
            this.Recibir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // rbtnLector
            // 
            this.rbtnLector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnLector.AutoSize = true;
            this.rbtnLector.BackColor = System.Drawing.Color.Transparent;
            this.rbtnLector.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.rbtnLector.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnLector.Location = new System.Drawing.Point(98, 35);
            this.rbtnLector.Name = "rbtnLector";
            this.rbtnLector.Size = new System.Drawing.Size(55, 17);
            this.rbtnLector.TabIndex = 17;
            this.rbtnLector.TabStop = true;
            this.rbtnLector.Text = "Lector";
            this.rbtnLector.UseVisualStyleBackColor = false;
            // 
            // rbtnLibro
            // 
            this.rbtnLibro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnLibro.AutoSize = true;
            this.rbtnLibro.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.rbtnLibro.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnLibro.Location = new System.Drawing.Point(159, 35);
            this.rbtnLibro.Name = "rbtnLibro";
            this.rbtnLibro.Size = new System.Drawing.Size(48, 17);
            this.rbtnLibro.TabIndex = 18;
            this.rbtnLibro.TabStop = true;
            this.rbtnLibro.Text = "Libro";
            this.rbtnLibro.UseVisualStyleBackColor = true;
            // 
            // rbtnAdministrador
            // 
            this.rbtnAdministrador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnAdministrador.AutoSize = true;
            this.rbtnAdministrador.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.rbtnAdministrador.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.rbtnAdministrador.Location = new System.Drawing.Point(213, 35);
            this.rbtnAdministrador.Name = "rbtnAdministrador";
            this.rbtnAdministrador.Size = new System.Drawing.Size(88, 17);
            this.rbtnAdministrador.TabIndex = 19;
            this.rbtnAdministrador.TabStop = true;
            this.rbtnAdministrador.Text = "Administrador";
            this.rbtnAdministrador.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "BUSCAR POR:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-743, 148);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2437, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // frmPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 551);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRetrazo);
            this.Controls.Add(this.rbtnAdministrador);
            this.Controls.Add(this.rbtnLibro);
            this.Controls.Add(this.rbtnLector);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnVer);
            this.Name = "FrmPrestamos";
            this.Text = "frmPrestamos";
            this.Load += new System.EventHandler(this.frmPrestamos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnRetrazo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.RadioButton rbtnLector;
        private System.Windows.Forms.RadioButton rbtnLibro;
        private System.Windows.Forms.RadioButton rbtnAdministrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LECTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIBRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENTREGADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDLector;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entregadoid;
        private System.Windows.Forms.DataGridViewImageColumn Recibir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}