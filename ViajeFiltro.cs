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
    internal class ViajeFiltro : Home
    {
        //Grid
        private NewRoundPanel form = new NewRoundPanel();
        private FlowLayoutPanel flForm = new FlowLayoutPanel();

        private DataGridView info = new DataGridView();
        private Panel panelGrid = new Panel();


        //Constructor
        public ViajeFiltro()
        {
            InitializeUI();

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

        }



        //Initializations
        private void InitializeUI()
        {
            InitializeGrid();
        }
        private void InitializeGrid()
        {
            AddItemsToGrid();
            GridChequesProperties();
        }
        



        //Adds
        private void AddItemsToGrid()
        {
            for (int i = 0; i < 7; i++)
            {
                info.Columns.Add(i.ToString(), "Dato");
            }

            panelGrid.Controls.Add(info);
            this.Controls.Add(panelGrid);

            CargarDatos();
        }





        //Grid
        private void GridChequesProperties()
        {
            panelGrid.Size = new Size(1200, 450);
            this.Resize += (s, e) =>
            {
                panelGrid.Location = new Point((this.Width - panelGrid.Width) / 2, (this.Height - panelGrid.Height) / 2);
            };
            panelGrid.BackColor = Color.Transparent;

            info.Size = new Size(1200, 450);
            info.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            info.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            info.BackgroundColor = Color.DarkGray;
            info.GridColor = Color.Black;
            info.Font = new Font("Nunito", 12, FontStyle.Regular);
            info.Margin = new Padding(0, 1000, 0, 0);

            info.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            info.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            info.EnableHeadersVisualStyles = false;
            info.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            info.AllowUserToResizeRows = false;

        }




        //Otros
        private void CargarDatos()
        {
            for (int i = 0; i < 30; i++)
            {
                info.Rows.Add("D1", "D2", "D3", "D4", "D5", "D6", "D7");

            }
        }
    }
}