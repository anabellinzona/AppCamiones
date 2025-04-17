using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppCamiones
{
    internal class CuentaCorriente : Home
    {
        private RoundButton btnVolver = new RoundButton();

        public CuentaCorriente(string dato)
        {
            InitializeUI(dato);
        }

        private void InitializeUI(string dato)
        {
            btnVolverProperties();
            infoForTableAndForm(dato);
        }

        private void btnVolverProperties()
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
        
        private void infoForTableAndForm(string dato)
        {
            List<string> datos = new List<string> { "Fecha", "Nro factura", "Pagó", "Debe" };
            List<string> campoFaltanteTabla = new List<string> { "Total " };
            int cant = datos.Count;
            FormRegistro vv = new FormRegistro(datos, cant, dato, "Cuenta corriente", campoFaltanteTabla);
            vv.TopLevel = true;
            vv.ShowDialog();
        }
    }
}