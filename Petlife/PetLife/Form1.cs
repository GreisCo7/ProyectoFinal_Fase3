using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Negocio;

namespace PetLife
{
    public partial class Form1 : Form
    {
        private readonly ControladorCitas _controlador = new ControladorCitas();

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable duenos = _controlador.ListarDuenos();

                cmbDueno.DisplayMember = "nombre";
                cmbDueno.ValueMember = "id_dueno";
                cmbDueno.DataSource = duenos;

                DataTable vets = _controlador.ListarVeterinarios();

                DataRow todos = vets.NewRow();
                todos["id_veterinario"] = 0u;
                todos["nombre"] = "-- Cualquiera --";
                todos["especialidad"] = "Todas";

                vets.Rows.InsertAt(todos, 0);

                cmbVeterinario.DisplayMember = "nombre";
                cmbVeterinario.ValueMember = "id_veterinario";
                cmbVeterinario.DataSource = vets;

                lblEstado.Text =
                    "Seleccione los datos y consulte disponibilidad.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar catálogos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            dgvHorarios.BackgroundColor = Color.White;
            dgvHorarios.BorderStyle = BorderStyle.None;
            dgvHorarios.RowHeadersVisible = false;

            dgvHorarios.EnableHeadersVisualStyles = false;

            dgvHorarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(67, 188, 188);

            dgvHorarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvHorarios.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvHorarios.Dock = DockStyle.Fill;

            dgvHorarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvHorarios.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgvHorarios.RowHeadersVisible = false;

            dgvHorarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHorarios.MultiSelect = false;

            dgvHorarios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(0, 150, 136);

            dgvHorarios.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvHorarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHorarios.MultiSelect = false;

            dgvHorarios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(0, 150, 136);

            dgvHorarios.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvHorarios.CurrentCell = null;

            dgvHorarios.RowTemplate.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(0, 150, 136);

            dgvHorarios.RowTemplate.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvHorarios.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

        }

        private void cmbDueño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDueno.SelectedValue == null ||
                cmbDueno.SelectedValue is DataRowView)
                return;

            try
            {
                int idDueno =
                    Convert.ToInt32(cmbDueno.SelectedValue);

                DataTable mascotas =
                    _controlador.ListarMascotasPorDueno(idDueno);

                cmbMascota.DisplayMember = "nombre";
                cmbMascota.ValueMember = "id_mascota";
                cmbMascota.DataSource = mascotas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar mascotas: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmbVeterinario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMascota_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbVeterinario.SelectedValue == null ||
    cmbVeterinario.SelectedValue is DataRowView)
                return;

            try
            {
                int idVet =
                    Convert.ToInt32(cmbVeterinario.SelectedValue);

                DateTime fecha =
                    dtpFecha.Value.Date;

                DataTable disponibles =
                    _controlador.ConsultarHorariosDisponibles(
                        idVet,
                        fecha);

                dgvHorarios.DataSource = disponibles;


                if (dgvHorarios.Columns.Contains("id_veterinario"))
                    dgvHorarios.Columns["id_veterinario"].Visible =
                        false;

                if (dgvHorarios.Columns.Contains("fecha_hora"))
                    dgvHorarios.Columns["fecha_hora"].Visible =
                        false;

                lblEstado.ForeColor = Color.DarkBlue;

                lblEstado.Text =
                    disponibles.Rows.Count > 0
                    ? $"Se encontraron {disponibles.Rows.Count} espacios disponibles."
                    : "No hay espacios disponibles para la fecha seleccionada.";
            }
            catch (Exception ex)
            {
                lblEstado.ForeColor = Color.Firebrick;

                lblEstado.Text =
                    "Error al consultar disponibilidad: "
                    + ex.Message;
            }

            dgvHorarios.ClearSelection();

        }

        private void dgvHorarios_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            dgvHorarios.Rows[e.RowIndex].Selected = true;
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un horario disponible.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbMascota.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione una mascota.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRowView filaDueno =
                cmbDueno.SelectedItem as DataRowView;

            if (filaDueno == null)
            {
                MessageBox.Show(
                    "Seleccione un dueño.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idDueno =
                Convert.ToInt32(filaDueno["id_dueno"]);

            int idUsuario =
                Convert.ToInt32(filaDueno["id_usuario"]);

            int idMascota =
                Convert.ToInt32(cmbMascota.SelectedValue);

            int idVet =
                Convert.ToInt32(
                    dgvHorarios.CurrentRow.Cells["id_veterinario"].Value);

            DateTime fechaHora =
                Convert.ToDateTime(
                    dgvHorarios.CurrentRow.Cells["fecha_hora"].Value);

            ResultadoOperacion res =
                _controlador.VerificarYRegistrarCita(
                    idDueno,
                    idMascota,
                    idVet,
                    fechaHora,
                    txtMotivo.Text,
                    idUsuario
                );

            if (res.Exito)
            {
                lblEstado.ForeColor = Color.DarkGreen;

                lblEstado.Text =
                    $"{res.Mensaje} (ID Cita: {res.IdGenerado})";

                txtMotivo.Clear();

                btnConsultar_Click(null, null);

                MessageBox.Show(
                    $"Cita #{res.IdGenerado} confirmada para el {fechaHora:dd/MM/yyyy HH:mm}.",
                    "Confirmación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                lblEstado.ForeColor = Color.Firebrick;

                lblEstado.Text = res.Mensaje;

                MessageBox.Show(
                    res.Mensaje,
                    "No disponible",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}