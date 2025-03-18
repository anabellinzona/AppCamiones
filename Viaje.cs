using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Collections;
using System.Collections.Generic;

namespace AppCamiones
{
    internal class Viaje : Form
    {
        //Nav
        private MenuStrip menuStrip = new MenuStrip();

        private ToolStripMenuItem homeMenu = new ToolStripMenuItem("home");
        private ToolStripMenuItem viajesMenu = new ToolStripMenuItem("viajes");
        private ToolStripMenuItem chequesMenu = new ToolStripMenuItem("cheques");
        private ToolStripMenuItem registrosMenu = new ToolStripMenuItem("registro");
        private ToolStripMenuItem userMenu = new ToolStripMenuItem();
        private ToolStripMenuItem closeSesion = new ToolStripMenuItem("Cerrar sesión");

        //Filter
        private NewRoundPanel card = new NewRoundPanel();
        private FlowLayoutPanel cardsContainer = new FlowLayoutPanel();

        private NewRoundPanel filter = new NewRoundPanel();
        private FlowLayoutPanel filterFL = new FlowLayoutPanel();

        private ArrayList buttonsFilter = new ArrayList();
        private ArrayList buttonsNameFilter = new ArrayList();
        private RoundButton choferFilter = new RoundButton();
        private RoundButton camionFilter = new RoundButton();
        private RoundButton clienteFilter = new RoundButton();


        //Constructor
        public Viaje()
        {
            //HACE QUE SE ABRA EN PANTALLA COMPLETA
            this.WindowState = FormWindowState.Maximized;
            InitializeUI();
            this.WindowState = FormWindowState.Maximized;

            choferFilter.MouseEnter += new EventHandler(hoverToBtnChofer_MouseEnter);
            choferFilter.MouseLeave += new EventHandler(hoverToBtnChofer_MouseLeave);

            clienteFilter.MouseEnter += new EventHandler(hoverToBtnCliente_MouseEnter);
            clienteFilter.MouseLeave += new EventHandler(hoverToBtnCliente_MouseLeave);

            camionFilter.MouseEnter += new EventHandler(hoverToBtnCamion_MouseEnter);
            camionFilter.MouseLeave += new EventHandler(hoverToBtnCamion_MouseLeave);

            closeSesion.Click += new EventHandler(GoToFormUser_Click);
            registrosMenu.Click += new EventHandler(GoToRegistro_Click);
            viajesMenu.Click += new EventHandler(GoToViaje_Click);
            homeMenu.Click += new EventHandler(GoToHome_Click);


            choferFilter.Click += (s, e) => CardGenerator("Chofer");
            clienteFilter.Click += (s, e) => CardGenerator("Cliente");
            camionFilter.Click += (s, e) => CardGenerator("Camión");
        }





        //Events
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





        //Functions
        private void hoverToBtnChofer_MouseEnter(object sender, EventArgs e)
        {
            choferFilter.Font = new Font("Nunito", 20, FontStyle.Regular);
            choferFilter.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }
        private void hoverToBtnChofer_MouseLeave(object sender, EventArgs e)
        {
            choferFilter.Font = new Font("Nunito", 16, FontStyle.Regular);
            choferFilter.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnCliente_MouseEnter(object sender, EventArgs e)
        {
            clienteFilter.Font = new Font("Nunito", 20, FontStyle.Regular);
            clienteFilter.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }
        private void hoverToBtnCliente_MouseLeave(object sender, EventArgs e)
        {
            clienteFilter.Font = new Font("Nunito", 16, FontStyle.Regular);
            clienteFilter.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnCamion_MouseEnter(object sender, EventArgs e)
        {
            camionFilter.Font = new Font("Nunito", 20, FontStyle.Regular);
            camionFilter.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }
        private void hoverToBtnCamion_MouseLeave(object sender, EventArgs e)
        {
            camionFilter.Font = new Font("Nunito", 16, FontStyle.Regular);
            camionFilter.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
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
            InitializeNavBar();
            InitializarMenuTipoRegistro();
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
        private void InitializarMenuTipoRegistro()
        {
            OptionsMenuProperties();
            LayoutOptionsMenuProperties();
            ButtonsProperties();
            AddLayoutOptionsMenu();
            AddPanelToForm();
            CardProperties();
        }
        private void InitializeNavBar()
        {
            AddItemsToMenu();
            MenuProperties();
            ItemsColor();
            MarginToItems();
            ItemsCapitalLetter();
        }






        //NavProperties
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
            viajesMenu.Font = new Font("Arial", 16, FontStyle.Underline);
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
        }






        //FilterProperties
        private void OptionsMenuProperties()
        {
            filter.Size = new Size(800, 60);
            this.Resize += (s, e) =>
            {
                filter.Location = new Point((this.Width - filter.Width) / 2, 100);
            };
            filter.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            filter.BorderStyle = BorderStyle.FixedSingle;
        }
        private void LayoutOptionsMenuProperties()
        {
            filterFL.AutoSize = true;
            filterFL.Width = choferFilter.Width;
            filterFL.BackColor = Color.Transparent;
            filterFL.FlowDirection = FlowDirection.LeftToRight;
            filter.Resize += (s, e) =>
            {
                filterFL.Location = new Point((filter.Width - filterFL.Width) / 2, (filter.Height - filterFL.Height) / 2);
            };
        }

        private void ButtonsProperties()
        {
            int j = 0;

            buttonsFilter.Add(choferFilter);
            buttonsFilter.Add(clienteFilter);
            buttonsFilter.Add(camionFilter);

            buttonsNameFilter.Add("Chofer");
            buttonsNameFilter.Add("Cliente");
            buttonsNameFilter.Add("Camión");

            for (int i = 0; i < buttonsFilter.Count; i++)
            {
                Button btn = (Button)buttonsFilter[i];

                btn.Size = new Size(150, 50);
                btn.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
                btn.Font = new Font("Nunito", 16, FontStyle.Regular);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.Margin = new Padding(0, 20, 0, 0);
                btn.TextAlign = ContentAlignment.MiddleCenter;

                if (j < buttonsNameFilter.Count)
                {
                    btn.Text = buttonsNameFilter[j].ToString().ToUpper();
                    j++;
                }

                btn.Click += (s, e) => CardGenerator(btn.Text);

                filterFL.Controls.Add(btn);
            }
        }
        private void AddPanelToForm()
        {
            this.Controls.Add(filter);
            this.Controls.Add(cardsContainer);
        }

        private void AddLayoutOptionsMenu()
        {
            filter.Controls.Add(filterFL);
        }

        private void CardProperties()
        {
            cardsContainer.Size = new Size(800, 400);
            cardsContainer.AutoScroll = true;
            cardsContainer.BackColor = Color.FromArgb(50, 50, 50);
            cardsContainer.FlowDirection = FlowDirection.LeftToRight;
            cardsContainer.WrapContents = true;
            cardsContainer.Margin = new Padding(10, 10, 10, 10);
            cardsContainer.BackColor = System.Drawing.Color.FromArgb(130, Color.Black);

            this.Resize += (s, e) =>
            {
                cardsContainer.Location = new Point((this.Width - cardsContainer.Width) / 2, filter.Bottom + 10);
            };

        }
        private void CardGenerator(string filtro)
        {
            Console.WriteLine($"Generando cards para: {filtro}");
            cardsContainer.Controls.Clear();

            List<string> datos = GetFilterInfo(filtro);
            Console.WriteLine($"Se encontraron {datos.Count} elementos.");

            foreach (string dato in datos)
            {
                Panel card = new Panel
                {
                    Size = new Size(200, 100),
                    BackColor = System.Drawing.Color.FromArgb(48, 48, 48),
                    Margin = new Padding(10),
                    Font = new Font("Arial", 16, FontStyle.Regular)
                };

                Label label = new Label
                {
                    Text = dato,
                    ForeColor = System.Drawing.Color.FromArgb(218, 218, 28),
                    AutoSize = true
                };

                card.Controls.Add(label);
                cardsContainer.Controls.Add(card);

                card.Click += (s, e) =>
                {
                    ViajeFiltro form = new ViajeFiltro();
                    form.Show();
                };
            }
            Console.WriteLine($"Total de cards en el contenedor: {cardsContainer.Controls.Count}");

            
        }


        private List<string> GetFilterInfo(string filtro)
        {
            if (filtro == "Camión")
                return new List<string> { "ABC123", "DEF456", "GHI789" };
            else if (filtro == "Cliente")
                return new List<string> { "Gómez", "Pérez", "Rodríguez" };
            else if (filtro == "Chofer")
                return new List<string> { "López", "Fernández", "Martínez" };
            else
                return new List<string>();
        }
        private void ShowDetailsCard(string datoSeleccionado)
        {
            MessageBox.Show($"Redirigiendo a detalles de {datoSeleccionado}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Redireccion a las tablas de datos
        }
    }
}
