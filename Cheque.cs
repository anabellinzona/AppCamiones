using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AppCamiones
{
    internal class Cheque : Home
    {
        //Grid
        private FlowLayoutPanel flForm = new FlowLayoutPanel();
        private NewRoundPanel form = new NewRoundPanel();

        private DataGridView cheq = new DataGridView();
        private Panel panelGrid = new Panel();


        //Constructor
        public Cheque()
        {
            InitializeToolBar();
            ResaltarBoton(chequesMenu);
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeToolBar()
        {
            AddItemsToGrid();
            GridChequesProperties();
        }
       
        private void AddItemsToGrid()
        {
            cheq.Columns.Add("fEntrega", "Fecha de entrega");
            cheq.Columns.Add("entrega", "Entregado por");
            cheq.Columns.Add("banco", "Banco");
            cheq.Columns.Add("nroCheque", "Nro. de cheque");
            cheq.Columns.Add("monto", "Monto");
            cheq.Columns.Add("fCobro", "Fecha de cobro");
            cheq.Columns.Add("entregado", "Entregado a");

            panelGrid.Controls.Add(cheq);
            this.Controls.Add(panelGrid);

            CargarDatos();
        }

        //GridProperties
        private void GridChequesProperties()
        {
            panelGrid.Size = new Size(1200, 450);
            this.Resize += (s, e) =>
            {
                panelGrid.Location = new Point((this.Width - panelGrid.Width) / 2, (this.Height - panelGrid.Height) / 2);
            };
            panelGrid.BackColor = Color.Transparent;

            
            cheq.Size = new Size(1200, 450);
            cheq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cheq.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cheq.BackgroundColor = Color.DarkGray;
            cheq.GridColor = Color.Black;
            cheq.Font = new Font("Nunito", 12, FontStyle.Regular);
            cheq.Margin = new Padding(0, 1000, 0, 0);


            cheq.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            cheq.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            cheq.EnableHeadersVisualStyles = false;
            cheq.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            cheq.AllowUserToResizeRows = false;

        }

        //Otros
        private void CargarDatos()
        {
            for(int i = 0; i<30; i++)
            {
                cheq.Rows.Add("2025-01-15", "x", "Banco Nación", "123456", "$5000", "2025-03-20", "Pendiente");

            }
        }
    }
}