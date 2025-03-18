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
    internal class Cheque : Form
    {
        //Nav
        private MenuStrip menuStrip = new MenuStrip();

        private ToolStripMenuItem homeMenu = new ToolStripMenuItem("home");
        private ToolStripMenuItem viajesMenu = new ToolStripMenuItem("viajes");
        private ToolStripMenuItem chequesMenu = new ToolStripMenuItem("cheques");
        private ToolStripMenuItem registrosMenu = new ToolStripMenuItem("registro");
        private ToolStripMenuItem userMenu = new ToolStripMenuItem();
        private ToolStripMenuItem closeSesion = new ToolStripMenuItem("Cerrar sesión");

        //Grid
        private NewRoundPanel form = new NewRoundPanel();

        private DataGridView cheq = new DataGridView();
        private Panel panelGrid = new Panel();

        private FlowLayoutPanel flForm = new FlowLayoutPanel();


        public Cheque()
        {
            InitializeUI();
            //HACE QUE SE ABRA EL FORMULARIO EN PANTALLA COMPLETA
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            closeSesion.Click += new EventHandler(GoToFormUser_Click);
            registrosMenu.Click += new EventHandler(GoToRegistro_Click);
            //viajesMenu.Click += new EventHandler(GoToViaje_Click);
            homeMenu.Click += new EventHandler(GoToHome_Click);
        }

        private void GoToRegistro_Click(object sender, EventArgs e)
        {

            Registro formRegistro = new Registro();
            formRegistro.ShowDialog();
            this.Close();
        }
        private void GoToFormUser_Click(object sender, EventArgs e)
        {
            Login formUser = new Login();
            formUser.ShowDialog();
            this.Close();
        }
        private void GoToHome_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Close();
        }
        private void GoToViaje_Click(object sender, EventArgs e)
        {
            Viaje viaje = new Viaje();
            viaje.Show();
            this.Close();
        }




        //Initializations
        private void InitializeUI()
        {
            InitializeBackImage();
            InitializeToolBar();
            InitializeIconoUser();
        }
        private void InitializeToolBar()
        {
            AddItemsToMenu();
            AddItemsToGrid();
            MenuProperties();
            ItemsColor();
            MarginToItems();
            ItemsCapitalLetter();
            GridChequesProperties();
        }
        private void InitializeIconoUser()
        {
            string icono_user = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "icono_user.png");
            if (File.Exists(icono_user))
            {
                userMenu.Image = Image.FromFile(icono_user);
            }
            else
            {
                MessageBox.Show("La imagen no se encuentra: " + icono_user);
            }
        }
        private void InitializeBackImage()
        {
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "goma.jpg");
            if (File.Exists(imagePath))
            {
                Image img = Image.FromFile(imagePath);
                if (Array.Exists(img.PropertyIdList, id => id == 0x0112))
                {
                    int orientation = BitConverter.ToUInt16(img.GetPropertyItem(0x0112).Value, 0);
                    switch (orientation)
                    {
                        case 1:
                            break;
                        case 3:
                            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 6:
                            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 8:
                            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                }
                this.BackgroundImage = img;
            }
            else
            {
                MessageBox.Show("La imagen no se encuentra: " + imagePath);
            }
        }
        //Adds
        private void addForm()
        {
            this.Controls.Add(form);
        }
        private void addFormFL()
        {
            form.Controls.Add(flForm);
        }





        //Nav
        private void AddItemsToMenu()
        {
            menuStrip.Items.Add(homeMenu);
            menuStrip.Items.Add(viajesMenu);
            menuStrip.Items.Add(chequesMenu);
            menuStrip.Items.Add(registrosMenu);
            menuStrip.Items.Add(userMenu);

            userMenu.DropDownItems.Add(closeSesion);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void MenuProperties()
        {
            menuStrip.Font = new Font("Arial", 14, FontStyle.Regular);
            menuStrip.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            menuStrip.ImageScalingSize = new Size(34, 34);
            menuStrip.AutoSize = false;
            menuStrip.Width = this.Width;
            menuStrip.Height = 80;
            menuStrip.Dock = DockStyle.Top;
            chequesMenu.Font = new Font("Arial", 16, FontStyle.Underline);
        }
        private void ItemsColor()
        {
            homeMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            viajesMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            chequesMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            registrosMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            userMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            closeSesion.ForeColor = System.Drawing.Color.FromArgb(141, 138, 138);
        }
        private void ItemsCapitalLetter()
        {
            homeMenu.Text = homeMenu.Text.ToUpper();
            viajesMenu.Text = viajesMenu.Text.ToUpper();
            chequesMenu.Text = chequesMenu.Text.ToUpper();
            registrosMenu.Text = registrosMenu.Text.ToUpper();
            userMenu.Text = userMenu.Text.ToUpper();
        }
        private void MarginToItems()
        {
            int x = this.Width;
            int y = x / 10;
            int t = (menuStrip.Width - userMenu.Width);

            homeMenu.Margin = new Padding(y, 0, 0, 0);
            viajesMenu.Margin = new Padding(y, 0, 0, 0);
            chequesMenu.Margin = new Padding(y, 0, 0, 0);
            registrosMenu.Margin = new Padding(y, 0, 0, 0);
            userMenu.Margin = new Padding(t, 0, 0, 0);
            closeSesion.Margin = new Padding(0, 10, 0, 0);

            //Grid
            cheq.Margin = new Padding(0, 1000, 0, 0);
        }




        //Grid
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

        private void GridChequesProperties()
        {
            panelGrid.Size = new Size(1200, 450);
            //panelGrid.Location = new Point(50, 150);7
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