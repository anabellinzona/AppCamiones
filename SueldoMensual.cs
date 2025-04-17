using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AppCamiones
{
    internal class SueldoMensual : Form
    {
        private RoundButton btnVolver = new RoundButton();

        public SueldoMensual(string dato)
        {
            InitializeUI(dato);
        }

        private void InitializeUI(string dato)
        {
            BtnVolverProperties();
            InfoForTableAndForm(dato);

            ConfigurarDataGrid();
        }

        private void BtnVolverProperties()
        {
            btnVolver.Text = "Volver";
            btnVolver.Size = new Size(140, 40);
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Location = new Point(40, 100);
            btnVolver.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnVolver.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            btnVolver.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btnVolver.Click += (s, e) =>
            {
                this.Close();
            };

            this.Controls.Add(btnVolver);
        }

        private void InfoForTableAndForm(string dato)
        {
            List<string> datosFormulario = new List<string> { "Fecha inicial", "Fecha final" };
            List<string> datos = new List<string> { "Inicio Intervalo de Pago", "Fin Intervalo de Pago", "Chofer", "Sueldo", "Pagado"};

            int cant = datosFormulario.Count;
            FormRegistro vv = new FormRegistro(datosFormulario, cant, dato, "sueldo", datos);
            vv.TopLevel = true;
            vv.ShowDialog();

            vv.addColumn("Pagado");
        }

        private void ConfigurarDataGrid()
        {
    
        }
    }
}
