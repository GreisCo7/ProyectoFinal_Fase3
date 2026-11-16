namespace PetLife
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Encabezado = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbMascota = new System.Windows.Forms.ComboBox();
            this.cmbVeterinario = new System.Windows.Forms.ComboBox();
            this.cmbDueno = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblMascota = new System.Windows.Forms.Label();
            this.lblVeterinario = new System.Windows.Forms.Label();
            this.lblDueño = new System.Windows.Forms.Label();
            this.dgvHorarios = new System.Windows.Forms.DataGridView();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnSolicitar = new System.Windows.Forms.Button();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblDisponibilidad = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.Encabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // Encabezado
            // 
            this.Encabezado.Controls.Add(this.pictureBox4);
            this.Encabezado.Controls.Add(this.pictureBox2);
            this.Encabezado.Controls.Add(this.pictureBox3);
            this.Encabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.Encabezado.Location = new System.Drawing.Point(0, 0);
            this.Encabezado.Name = "Encabezado";
            this.Encabezado.Size = new System.Drawing.Size(1110, 148);
            this.Encabezado.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(506, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(604, 148);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(23, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(151, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(198, 25);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(242, 99);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.cmbMascota);
            this.panel1.Controls.Add(this.cmbVeterinario);
            this.panel1.Controls.Add(this.cmbDueno);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblMascota);
            this.panel1.Controls.Add(this.lblVeterinario);
            this.panel1.Controls.Add(this.lblDueño);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 134);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(187)))), ((int)(((byte)(177)))));
            this.btnConsultar.Font = new System.Drawing.Font("Noto Sans SC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.ImageIndex = 1;
            this.btnConsultar.Location = new System.Drawing.Point(879, 41);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(153, 53);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar Disponibilidad";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(557, 83);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(216, 22);
            this.dtpFecha.TabIndex = 7;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // cmbMascota
            // 
            this.cmbMascota.FormattingEnabled = true;
            this.cmbMascota.Location = new System.Drawing.Point(557, 30);
            this.cmbMascota.Name = "cmbMascota";
            this.cmbMascota.Size = new System.Drawing.Size(216, 24);
            this.cmbMascota.TabIndex = 6;
            this.cmbMascota.SelectedIndexChanged += new System.EventHandler(this.cmbMascota_SelectedIndexChanged);
            // 
            // cmbVeterinario
            // 
            this.cmbVeterinario.FormattingEnabled = true;
            this.cmbVeterinario.Location = new System.Drawing.Point(166, 81);
            this.cmbVeterinario.Name = "cmbVeterinario";
            this.cmbVeterinario.Size = new System.Drawing.Size(216, 24);
            this.cmbVeterinario.TabIndex = 5;
            this.cmbVeterinario.SelectedIndexChanged += new System.EventHandler(this.cmbVeterinario_SelectedIndexChanged);
            // 
            // cmbDueno
            // 
            this.cmbDueno.FormattingEnabled = true;
            this.cmbDueno.Location = new System.Drawing.Point(166, 30);
            this.cmbDueno.Name = "cmbDueno";
            this.cmbDueno.Size = new System.Drawing.Size(216, 24);
            this.cmbDueno.TabIndex = 4;
            this.cmbDueno.SelectedIndexChanged += new System.EventHandler(this.cmbDueño_SelectedIndexChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Noto Sans SC Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFecha.ImageIndex = 2;
            this.lblFecha.ImageList = this.imageList1;
            this.lblFecha.Location = new System.Drawing.Point(442, 80);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(91, 25);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "      Fecha:";
            this.lblFecha.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "enviar.png");
            this.imageList1.Images.SetKeyName(1, "lupa (1).png");
            this.imageList1.Images.SetKeyName(2, "calendario.png");
            this.imageList1.Images.SetKeyName(3, "huella.png");
            this.imageList1.Images.SetKeyName(4, "estetoscopio.png");
            this.imageList1.Images.SetKeyName(5, "usuario (1).png");
            // 
            // lblMascota
            // 
            this.lblMascota.AutoSize = true;
            this.lblMascota.Font = new System.Drawing.Font("Noto Sans SC Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMascota.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMascota.ImageIndex = 3;
            this.lblMascota.ImageList = this.imageList1;
            this.lblMascota.Location = new System.Drawing.Point(442, 29);
            this.lblMascota.Name = "lblMascota";
            this.lblMascota.Size = new System.Drawing.Size(109, 25);
            this.lblMascota.TabIndex = 2;
            this.lblMascota.Text = "      Mascota:";
            // 
            // lblVeterinario
            // 
            this.lblVeterinario.AutoSize = true;
            this.lblVeterinario.Font = new System.Drawing.Font("Noto Sans SC Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeterinario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVeterinario.ImageIndex = 4;
            this.lblVeterinario.ImageList = this.imageList1;
            this.lblVeterinario.Location = new System.Drawing.Point(27, 81);
            this.lblVeterinario.Name = "lblVeterinario";
            this.lblVeterinario.Size = new System.Drawing.Size(133, 25);
            this.lblVeterinario.TabIndex = 1;
            this.lblVeterinario.Text = "      Veterinario:";
            // 
            // lblDueño
            // 
            this.lblDueño.AutoSize = true;
            this.lblDueño.Font = new System.Drawing.Font("Noto Sans SC Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueño.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDueño.ImageIndex = 5;
            this.lblDueño.ImageList = this.imageList1;
            this.lblDueño.Location = new System.Drawing.Point(27, 30);
            this.lblDueño.Name = "lblDueño";
            this.lblDueño.Size = new System.Drawing.Size(95, 25);
            this.lblDueño.TabIndex = 0;
            this.lblDueño.Text = "      Dueño:";
            this.lblDueño.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvHorarios
            // 
            this.dgvHorarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvHorarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(187)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHorarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHorarios.EnableHeadersVisualStyles = false;
            this.dgvHorarios.Location = new System.Drawing.Point(0, 0);
            this.dgvHorarios.Margin = new System.Windows.Forms.Padding(10);
            this.dgvHorarios.Name = "dgvHorarios";
            this.dgvHorarios.RowHeadersVisible = false;
            this.dgvHorarios.RowHeadersWidth = 51;
            this.dgvHorarios.RowTemplate.Height = 24;
            this.dgvHorarios.Size = new System.Drawing.Size(1110, 261);
            this.dgvHorarios.TabIndex = 2;
            this.dgvHorarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(307, 39);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(532, 22);
            this.txtMotivo.TabIndex = 3;
            this.txtMotivo.TextChanged += new System.EventHandler(this.txtMotivo_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.btnSolicitar);
            this.panel2.Controls.Add(this.lblMotivo);
            this.panel2.Controls.Add(this.txtMotivo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 604);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1110, 100);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(87, 24);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(62, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(187)))), ((int)(((byte)(177)))));
            this.btnSolicitar.Font = new System.Drawing.Font("Noto Sans SC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitar.ForeColor = System.Drawing.Color.White;
            this.btnSolicitar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSolicitar.ImageIndex = 0;
            this.btnSolicitar.Location = new System.Drawing.Point(878, 24);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(154, 51);
            this.btnSolicitar.TabIndex = 5;
            this.btnSolicitar.Text = "Registrar Cita";
            this.btnSolicitar.UseVisualStyleBackColor = false;
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Noto Sans SC Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(155, 40);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(146, 21);
            this.lblMotivo.TabIndex = 4;
            this.lblMotivo.Text = "Motivo de consulta:";
            // 
            // lblDisponibilidad
            // 
            this.lblDisponibilidad.AutoSize = true;
            this.lblDisponibilidad.Font = new System.Drawing.Font("Noto Sans SC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibilidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(122)))), ((int)(((byte)(175)))));
            this.lblDisponibilidad.Location = new System.Drawing.Point(15, 14);
            this.lblDisponibilidad.Name = "lblDisponibilidad";
            this.lblDisponibilidad.Size = new System.Drawing.Size(185, 25);
            this.lblDisponibilidad.TabIndex = 5;
            this.lblDisponibilidad.Text = "Horarios Disponibles";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox6);
            this.panel3.Controls.Add(this.lblEstado);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 704);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1110, 34);
            this.panel3.TabIndex = 6;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Noto Sans SC", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Firebrick;
            this.lblEstado.Location = new System.Drawing.Point(71, 6);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(302, 19);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Seleccione los datos y consulte disponibilidad.";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblDisponibilidad);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 282);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1110, 56);
            this.panel4.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvHorarios);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 338);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1110, 261);
            this.panel5.TabIndex = 8;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(12, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(38, 28);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 1;
            this.pictureBox6.TabStop = false;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1110, 738);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Encabezado);
            this.Name = "Form1";
            this.Text = "Sistema de Gestión de Citas Veterinarias";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Encabezado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Encabezado;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbMascota;
        private System.Windows.Forms.ComboBox cmbVeterinario;
        private System.Windows.Forms.ComboBox cmbDueno;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblMascota;
        private System.Windows.Forms.Label lblVeterinario;
        private System.Windows.Forms.Label lblDueño;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvHorarios;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSolicitar;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblDisponibilidad;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}

