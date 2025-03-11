using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        //CREACIÓN PANEL Y COMPONENTES
        private Panel table_travel = new Panel();

        private Label travel_title = new Label();
        private Label travel_title2 = new Label();
        private Panel table_pay = new Panel();
        private Label pay_title = new Label();

        private FlowLayoutPanel layoutTableTravelToday = new FlowLayoutPanel();
        private FlowLayoutPanel layoutTableTravelNext = new FlowLayoutPanel();
        private FlowLayoutPanel layoutTravelNext = new FlowLayoutPanel();
        private FlowLayoutPanel layoutTravelToday = new FlowLayoutPanel();
        private FlowLayoutPanel layoutTablePay = new FlowLayoutPanel();
        private FlowLayoutPanel layoutPay = new FlowLayoutPanel();

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            userMenu.Click += new EventHandler(GoToFormUser_Click);
        }

        private void GoToFormUser_Click(object sender, EventArgs e)
        {
            Class1 formUser = new Class1();
            formUser.Show();
            this.Close();
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

        // CREACIÓN PANEL Y COMPONENTES

        private void InitializePanel()
        {
            TableTravel();
            TablePay();
            AddTablesToControls();
        }

        private void TableTravel()
        {
            TableTravelProperties();
            LayoutTableTravelTodayProperties();
            LayoutTableTravelNextProperties();
            LayoutTravelNextProperties();
            LayoutTravelTodayProperties();
            TableTravelTitleProperties();
            AddTitleToTableTravel();
            AddTravelToday();
            AddTravel();
        }
        private void TableTravelProperties()
        {
            table_travel.Padding = new Padding(0);
            table_travel.Margin = new Padding(0);

            table_travel.Size = new Size(740, int.MaxValue);
            table_travel.Location = new Point(150, 180);
            table_travel.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
            table_travel.BorderStyle = BorderStyle.FixedSingle;
            table_travel.AutoSize = true;
        }

        private void LayoutTableTravelTodayProperties()
        {
            layoutTableTravelToday.Padding = new Padding(0);
            layoutTableTravelToday.Margin = new Padding(0);


            table_travel.Resize += (s, e) =>
            {
                layoutTableTravelToday.Location = new Point((table_travel.Width - layoutTableTravelToday.Width) / 2, 20);
            };

            layoutTableTravelToday.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTableTravelToday.BackColor = Color.Transparent;
            layoutTableTravelToday.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTableTravelToday.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTableTravelToday.WrapContents = false; // Evita que los elementos pasen a otra línea
            layoutTableTravelToday.Width = table_travel.Width;
            layoutTableTravelToday.Size = new Size(table_travel.Width, 200);
        }

        private void LayoutTableTravelNextProperties()
        {
            layoutTableTravelNext.Padding = new Padding(0);
            layoutTableTravelNext.Margin = new Padding(0);

            table_travel.Resize += (s, e) =>
            {
                layoutTableTravelNext.Location = new Point((table_travel.Width - layoutTableTravelNext.Width) / 2, 240);
            };
            layoutTableTravelNext.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTableTravelNext.Size = new Size(table_travel.Width, 200);
            //layoutTableTravelNext.AutoScroll = true;
            layoutTableTravelNext.BackColor = Color.Transparent;
            layoutTableTravelNext.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTableTravelNext.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTableTravelNext.WrapContents = true;//Evita que los elementos pasen a otra línea
        }

        private void LayoutTravelNextProperties()
        {
            layoutTravelNext.Padding = new Padding(0);
            layoutTravelNext.Margin = new Padding(0);

            table_travel.Resize += (s, e) =>
            {
                layoutTableTravelNext.Location = new Point((layoutTableTravelNext.Width - layoutTravelNext.Width) / 2, 240);
            };
            layoutTravelNext.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTravelNext.Size = new Size(layoutTableTravelNext.Width, 160);
            layoutTravelNext.AutoScroll = true;
            layoutTravelNext.BackColor = Color.Transparent;
            layoutTravelNext.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTravelNext.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTravelNext.WrapContents = true;//Evita que los elementos pasen a otra línea
        }

        private void LayoutTravelTodayProperties()
        {
            layoutTravelToday.Padding = new Padding(0);
            layoutTravelToday.Margin = new Padding(0);

            table_travel.Resize += (s, e) =>
            {
                layoutTableTravelToday.Location = new Point((layoutTableTravelToday.Width - layoutTravelToday.Width) / 2, 20);
            };
            layoutTravelToday.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTravelToday.Size = new Size(layoutTableTravelToday.Width, 180);
            layoutTravelToday.AutoScroll = true;
            layoutTravelToday.BackColor = Color.Transparent;
            layoutTravelToday.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTravelToday.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTravelToday.WrapContents = true;//Permite que los elementos pasen a otra línea
        }

        private void TableTravelTitleProperties()
        {
            travel_title.Text = "viajes programados para hoy:";
            travel_title.Font = new Font("Arial", 14, FontStyle.Regular);
            travel_title.Text = travel_title.Text.ToUpper();
            travel_title.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            travel_title.BackColor = Color.Transparent;
            travel_title.TextAlign = ContentAlignment.TopCenter;
            travel_title.AutoSize = false;
            travel_title.Width = layoutTableTravelToday.Width; 
            //-------------------------------------------------------------------------
            travel_title2.Text = "viajes próximos:";
            travel_title2.Font = new Font("Arial", 14, FontStyle.Regular);
            travel_title2.Text = travel_title2.Text.ToUpper();
            travel_title2.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            travel_title2.BackColor = Color.Transparent;
            travel_title2.TextAlign = ContentAlignment.TopCenter;
            travel_title2.AutoSize = false;
            travel_title2.Width = layoutTableTravelNext.Width; 
        }

        private void AddTravelToday()
        {
            for (int i = 0; i < 8; i++)
            {
                Label travel = new Label();
                if (i >= 4)
                {
                    travel.Margin = new Padding(0, 10, 0, 0);
                }
                else
                {
                    travel.Margin = new Padding(60, 10, 0, 0);
                }
                TravelProperties(travel);
                layoutTravelToday.Controls.Add(travel);
                travel.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            }
        }

        private void AddTravel()
        {
            for (int i = 0; i < 8; i++)
            {
                Label travel = new Label();
                if (i >= 4)
                {
                    travel.Margin = new Padding(0, 10, 0, 0);
                }
                else
                {
                    travel.Margin = new Padding(60, 10, 0, 0);
                }
                    TravelProperties(travel);
                layoutTravelNext.Controls.Add(travel);
                travel.ForeColor = System.Drawing.Color.FromArgb(141, 138, 138);
            }
        }

        private void TravelProperties(Label travel)
        {
            travel.Text = "- Dolores - 10:00hs";
            travel.Font = new Font("Arial", 14, FontStyle.Regular);
            travel.Size = new Size(200, 30);
            //travel.Margin = new Padding(0, 10, 0, 0);
        }

        private void AddTitleToTableTravel()
        {
            table_travel.Controls.Add(layoutTableTravelToday);
            table_travel.Controls.Add(layoutTableTravelNext);
            layoutTableTravelToday.Controls.Add(travel_title);
            layoutTableTravelNext.Controls.Add(travel_title2);
            layoutTableTravelNext.Controls.Add(layoutTravelNext);
            layoutTableTravelToday.Controls.Add(layoutTravelToday);

        }

        //TABLA DE PAGOS
        private void TablePay()
        { 
            TablePayProperties();
            LayoutTablePayProperties();
            TravelPayTitleProperties();
            AddTitleToTablePay();
            AddPendingPayments();
            LayoutPayProperties();
        }

        private void TablePayProperties()
        {
            table_pay.Size = new Size(320, 440);
            table_pay.Location = new Point(1100, 180);
            table_pay.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
            table_pay.BorderStyle = BorderStyle.FixedSingle;
            //table_pay.AutoScroll = true;
            //layoutTablePay.WrapContents = true;
        }

        private void LayoutTablePayProperties()
        {
            layoutTablePay.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTablePay.AutoSize = true;
            layoutTablePay.AutoScroll = true;
            layoutTablePay.BackColor = Color.Transparent;
            layoutTablePay.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTablePay.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTablePay.WrapContents = true; // Evita que los elementos pasen a otra línea
           
        }

        private void LayoutPayProperties()
        {
            layoutPay.Padding = new Padding(0);
            layoutPay.Margin = new Padding(0);

            table_pay.Resize += (s, e) =>
            {
                layoutTablePay.Location = new Point((layoutTablePay.Width - layoutPay.Width) / 2, 10);
            };
            layoutPay.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutPay.Size = new Size(layoutTablePay.Width, 420);
            layoutPay.AutoScroll = true;
            layoutPay.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutPay.BackColor = Color.Transparent;
            layoutPay.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutPay.WrapContents = true;//Evita que los elementos pasen a otra línea
        }

        private void TravelPayTitleProperties()
        {
            pay_title.Text = "pagos pendientes:";
            pay_title.Font = new Font("Arial", 14, FontStyle.Regular);
            pay_title.Text = pay_title.Text.ToUpper();
            pay_title.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            pay_title.BackColor = Color.Transparent;
            pay_title.AutoSize = false;
            pay_title.TextAlign = ContentAlignment.TopCenter;
            pay_title.Width = table_pay.Width;  // Ocupa todo el ancho del contenedor
            pay_title.Margin = new Padding(0, 20, 0, 0);
        }

        private void AddPendingPayments()
        {
            CheckedListBox pay = new CheckedListBox();
            for (int i = 0; i < 8; i++)
            {
                pay.Items.Add("Apellido, nombre");
                PayProperties(pay);
                layoutPay.Controls.Add(pay);
            }
        }

        private void PayProperties(CheckedListBox pay)
        {
            pay.Font = new Font("Arial", 14, FontStyle.Regular);
            pay.AutoSize = true;
            pay.Margin = new Padding(60, 10, 0, 0);
            pay.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            pay.BackColor = Color.Black;
            pay.BorderStyle = BorderStyle.None;
        }

        private void AddTitleToTablePay()
        {
            table_pay.Controls.Add(layoutTablePay);
            layoutTablePay.Controls.Add(pay_title);
            layoutTablePay.Controls.Add(layoutPay);
            
        }
        // AGREGAR TABLAS

        private void AddTablesToControls()
        {
            this.Controls.Add(table_travel);
            this.Controls.Add(table_pay);
        }
    }
}
