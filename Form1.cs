using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCamiones
{
    public partial class Form1: Form
    {
        //CREACIÓN DE LA BARRA DE HERRAMIENTAS Y CADA ÍTEM
        private MenuStrip menuStrip = new MenuStrip();
        private ToolStripMenuItem homeMenu = new ToolStripMenuItem("home");
        private ToolStripMenuItem viajesMenu = new ToolStripMenuItem("viajes");
        private ToolStripMenuItem chequesMenu = new ToolStripMenuItem("cheques");
        private ToolStripMenuItem registrosMenu = new ToolStripMenuItem("registro");
        private ToolStripMenuItem userMenu = new ToolStripMenuItem();

        private Panel table_travel = new Panel();
        private Label travel_title = new Label();
        private Label travel_title2 = new Label();
        private Panel table_pay = new Panel();
        private Label pay_title = new Label();


        private TextBox nn = new TextBox();

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeUI()
        {
            InitializeBackImage();
            InitializeIconoApp();
            InitializeIconoUser();
            InitializeToolBar();
            InitializePanel();

        }

        private void InitializeBackImage()
        {
            //ASIGNA LA RUTA D ELA IMAGEN DE MANERA RELATIVA
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "goma.jpg");

            //PREGUNTA SI EXISTE DICHO ARCHIVO
            if (File.Exists(imagePath))
            {
                //LE ASGINA A BACKGROUNDIMAGE LA IMAGEN
                this.BackgroundImage = Image.FromFile(imagePath);
            }
            else
            {
                //TIRA EXCEPCIÓN
                MessageBox.Show("La imagen no se encuentra: " + imagePath);
            }

            //Path.Combine(...) --> se asegura de unir correctamente partes de una ruta de archivo sin problema
            //AppDomain.CurrentDomain.BaseDirectory --> Obtiene el directorio base de dónde se está ejecutando la aplicación
            //"Resources", "goma.jpg" --> Resources es la carpeta donde se encuentra el archivo goma.jpg
        }

        private void InitializeIconoApp()
        {
            //ASIGNA ÍCONO AL FORMULARIO
            string iconoApp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "icono_camion.ico");

            //PREGUNTA SI EXISTE EL ARCHIVO
            if (File.Exists(iconoApp))
            {
                //LE ASIGNA EL ICONO A LA APLICACIÓN
                this.Icon = new Icon(iconoApp);
            } 
            else
            {
                //TIRA EXCEPCIÓN
                MessageBox.Show("La imagen no se encuentra: " + iconoApp);
            }
        }

        private void InitializeIconoUser()
        {
            //ASIGNA ÍCONO A LA BARRA DE HERRAMIENTAS
            string icono_user = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "icono_user.png");


            //PREGUNTA SI EXISTE EL ARCHIVO
            if (File.Exists(icono_user))
            {
                //LE ASIGNA LA IMAGEN A USERMENU
                userMenu.Image = Image.FromFile(icono_user);
            }
            else
            {
                //TIRA EXCEPCIÓN
                MessageBox.Show("La imagen no se encuentra: " + icono_user);
            }
        }

        private void InitializeToolBar()
        {
            ItemsCapitalLetter();
            MenuProperties();
            ItemsColor();
            MarginToItems();
            AddItemsToMenu();
        }

        private void ItemsCapitalLetter()
        {
            //PONE EN MAYÚSUCLA LAS PALABRAS DE LOS ÍTEMS
            homeMenu.Text = homeMenu.Text.ToUpper();
            viajesMenu.Text = viajesMenu.Text.ToUpper();
            chequesMenu.Text = chequesMenu.Text.ToUpper();
            registrosMenu.Text = registrosMenu.Text.ToUpper();
            userMenu.Text = userMenu.Text.ToUpper();
        }

        private void MenuProperties()
        {
            //PROPIEDADES DEL MENÚ
            menuStrip.Font = new Font("Arial", 14, FontStyle.Regular);
            menuStrip.BackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            menuStrip.ImageScalingSize = new Size(34, 34);
            menuStrip.AutoSize = false;
            menuStrip.Width = 200;
            menuStrip.Height = 80;
            menuStrip.Dock = DockStyle.Top;
            //homeMenu.DropDownItems.Add(salirItem); pone un elemento dentro del suyo
            //HOME  MENÚ  ARCHIVO
            //SALIR
        }

        private void ItemsColor()
        {
            //ASIGNA EL COLOR A LOS ÍTEMS
            homeMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            viajesMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            chequesMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            registrosMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            userMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void MarginToItems()
        {
            //MARGIN
            homeMenu.Margin = new Padding(50, 0, 50, 0);
            viajesMenu.Margin = new Padding(50, 0, 50, 0);
            chequesMenu.Margin = new Padding(50, 0, 50, 0);
            registrosMenu.Margin = new Padding(50, 0, 50, 0);
            userMenu.Margin = new Padding(650, 0, 650, 0);
        }

        private void AddItemsToMenu()
        { 
            //AGREGA AL MENÚ LOS ÍTEMS
            menuStrip.Items.Add(homeMenu);
            menuStrip.Items.Add(viajesMenu);
            menuStrip.Items.Add(chequesMenu);
            menuStrip.Items.Add(registrosMenu);
            menuStrip.Items.Add(userMenu);

            // AGREGA AL FORM LA BARRA DE HERRAMIENTAS
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void InitializePanel()
        {
            TableTravelProperties();
            TableTravelTitleProperties();
            TablePayProperties();
            TravelPayTitleProperties();
            AddTablesToControls();
            AddTitleToTables();
        }

        private void TableTravelProperties()
        {
            table_travel.Size = new Size(740, 440);
            table_travel.Location = new Point(150, 180);
            table_travel.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
            table_travel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void TableTravelTitleProperties()
        {
            travel_title.Text = "viajes programados para el hoy:";
            travel_title.Font = new Font("Arial", 14, FontStyle.Regular);
            travel_title.Text = travel_title.Text.ToUpper();
            travel_title.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            travel_title.TextAlign = ContentAlignment.TopCenter;
            travel_title.Dock = DockStyle.Fill;
            travel_title.BackColor = Color.Transparent;
            travel_title.Padding = new Padding(0, 20, 0, 0);

            travel_title2.Text = "viajes próximos:";
            travel_title2.Font = new Font("Arial", 14, FontStyle.Regular);
            travel_title2.Text = travel_title2.Text.ToUpper();
            travel_title2.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            travel_title2.BackColor = Color.Transparent;
            travel_title2.TextAlign = ContentAlignment.MiddleCenter;
            travel_title2.Dock = DockStyle.Fill;
        }

        private void TablePayProperties()
        {
            table_pay.Location = new Point(1100, 180);
            table_pay.Size = new Size(320, 440);
            table_pay.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
        }

        private void TravelPayTitleProperties()
        {
            pay_title.Text = "pagos pendientes:";
            pay_title.Font = new Font("Arial", 14, FontStyle.Regular);
            pay_title.Text = pay_title.Text.ToUpper();
            pay_title.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            pay_title.BackColor = Color.Transparent;
            pay_title.AutoSize = true;
            pay_title.TextAlign = ContentAlignment.TopCenter;
            pay_title.Dock = DockStyle.Fill;
            pay_title.Padding = new Padding(60, 20, 0, 0);
        }

        private void AddTablesToControls()
        {
            this.Controls.Add(table_travel);
            this.Controls.Add(table_pay);
        }

        private void AddTitleToTables()
        {
            table_travel.Controls.Add(travel_title);
            table_travel.Controls.Add(nn);
            table_travel.Controls.Add(travel_title2);
            table_pay.Controls.Add(pay_title);
            table_pay.Controls.Add(travel_title2);
        }
    }
}
