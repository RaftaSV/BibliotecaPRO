namespace AdminLabrary.formularios.principales
{
    partial class frmLibros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibros));
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Libro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero_Edicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Editorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUEVO = new System.Windows.Forms.DataGridViewImageColumn();
            this.EDITAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.ELIMINAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.rbtnLibro = new System.Windows.Forms.RadioButton();
            this.rbtnAutor = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLibros
            // 
            this.dgvLibros.AllowUserToAddRows = false;
            this.dgvLibros.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLibros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLibros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLibros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLibros.BackgroundColor = System.Drawing.Color.White;
            this.dgvLibros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLibros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Libro,
            this.Cantidad,
            this.Año,
            this.Numero_Edicion,
            this.Autor,
            this.Editorial,
            this.Categoria,
            this.Id_Autor,
            this.Id_Editorial,
            this.Id_Categoria,
            this.NUEVO,
            this.EDITAR,
            this.ELIMINAR});
            this.dgvLibros.GridColor = System.Drawing.Color.Teal;
            this.dgvLibros.Location = new System.Drawing.Point(10, 134);
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.ReadOnly = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLibros.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLibros.Size = new System.Drawing.Size(924, 389);
            this.dgvLibros.TabIndex = 1;
            this.dgvLibros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLibros_CellClick);
            this.dgvLibros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLibros_CellContentClick);
            // 
            // ID
            // 
            this.ID.FillWeight = 40F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Libro
            // 
            this.Libro.FillWeight = 125.7808F;
            this.Libro.HeaderText = "LIBRO";
            this.Libro.Name = "Libro";
            this.Libro.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.FillWeight = 50.31232F;
            this.Cantidad.HeaderText = "CANTIDAD";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Año
            // 
            this.Año.FillWeight = 75.46847F;
            this.Año.HeaderText = "AÑO";
            this.Año.Name = "Año";
            this.Año.ReadOnly = true;
            // 
            // Numero_Edicion
            // 
            this.Numero_Edicion.FillWeight = 62.8904F;
            this.Numero_Edicion.HeaderText = "NUMERO DE EDICION";
            this.Numero_Edicion.Name = "Numero_Edicion";
            this.Numero_Edicion.ReadOnly = true;
            // 
            // Autor
            // 
            this.Autor.FillWeight = 125.7808F;
            this.Autor.HeaderText = "AUTOR";
            this.Autor.Name = "Autor";
            this.Autor.ReadOnly = true;
            // 
            // Editorial
            // 
            this.Editorial.FillWeight = 125.7808F;
            this.Editorial.HeaderText = "EDITORIAL";
            this.Editorial.Name = "Editorial";
            this.Editorial.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.FillWeight = 100.6246F;
            this.Categoria.HeaderText = "CATEGORIA";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Id_Autor
            // 
            this.Id_Autor.HeaderText = "Id_Autor";
            this.Id_Autor.Name = "Id_Autor";
            this.Id_Autor.ReadOnly = true;
            this.Id_Autor.Visible = false;
            // 
            // Id_Editorial
            // 
            this.Id_Editorial.HeaderText = "Id_Editorial";
            this.Id_Editorial.Name = "Id_Editorial";
            this.Id_Editorial.ReadOnly = true;
            this.Id_Editorial.Visible = false;
            // 
            // Id_Categoria
            // 
            this.Id_Categoria.HeaderText = "Id_Categoria";
            this.Id_Categoria.Name = "Id_Categoria";
            this.Id_Categoria.ReadOnly = true;
            this.Id_Categoria.Visible = false;
            // 
            // NUEVO
            // 
            this.NUEVO.FillWeight = 54.30214F;
            this.NUEVO.HeaderText = "NUEVO";
            this.NUEVO.Image = ((System.Drawing.Image)(resources.GetObject("NUEVO.Image")));
            this.NUEVO.Name = "NUEVO";
            this.NUEVO.ReadOnly = true;
            // 
            // EDITAR
            // 
            this.EDITAR.FillWeight = 50.07491F;
            this.EDITAR.HeaderText = "EDITAR";
            this.EDITAR.Image = ((System.Drawing.Image)(resources.GetObject("EDITAR.Image")));
            this.EDITAR.Name = "EDITAR";
            this.EDITAR.ReadOnly = true;
            // 
            // ELIMINAR
            // 
            this.ELIMINAR.FillWeight = 58.98477F;
            this.ELIMINAR.HeaderText = "ELIMINAR";
            this.ELIMINAR.Image = ((System.Drawing.Image)(resources.GetObject("ELIMINAR.Image")));
            this.ELIMINAR.Name = "ELIMINAR";
            this.ELIMINAR.ReadOnly = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(552, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(388, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuscar.Location = new System.Drawing.Point(12, 79);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(402, 26);
            this.txtBuscar.TabIndex = 27;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(394, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // rbtnLibro
            // 
            this.rbtnLibro.AutoSize = true;
            this.rbtnLibro.Location = new System.Drawing.Point(98, 61);
            this.rbtnLibro.Name = "rbtnLibro";
            this.rbtnLibro.Size = new System.Drawing.Size(48, 17);
            this.rbtnLibro.TabIndex = 29;
            this.rbtnLibro.TabStop = true;
            this.rbtnLibro.Text = "Libro";
            this.rbtnLibro.UseVisualStyleBackColor = true;
            // 
            // rbtnAutor
            // 
            this.rbtnAutor.AutoSize = true;
            this.rbtnAutor.Location = new System.Drawing.Point(152, 61);
            this.rbtnAutor.Name = "rbtnAutor";
            this.rbtnAutor.Size = new System.Drawing.Size(50, 17);
            this.rbtnAutor.TabIndex = 30;
            this.rbtnAutor.TabStop = true;
            this.rbtnAutor.Text = "Autor";
            this.rbtnAutor.UseVisualStyleBackColor = true;
            this.rbtnAutor.CheckedChanged += new System.EventHandler(this.rbtnAutor_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 35;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "BUSCAR POR:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-760, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2437, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // frmLibros
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 551);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbtnAutor);
            this.Controls.Add(this.rbtnLibro);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dgvLibros);
            this.Name = "frmLibros";
            this.Load += new System.EventHandler(this.frmLibros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton rbtnLibro;
        private System.Windows.Forms.RadioButton rbtnAutor;
        public System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Libro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Año;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero_Edicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Editorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Editorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Categoria;
        private System.Windows.Forms.DataGridViewImageColumn NUEVO;
        private System.Windows.Forms.DataGridViewImageColumn EDITAR;
        private System.Windows.Forms.DataGridViewImageColumn ELIMINAR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}