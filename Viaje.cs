using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
        private FlowLayoutPanel filterFL = new FlowLayoutPanel();
        private RoundButton choferFilter = new RoundButton();
        private RoundButton camionFilter = new RoundButton();
        private RoundButton clienteFilter = new RoundButton();

        private NewRoundPanel card = new NewRoundPanel();
        private FlowLayoutPanel cardsContainer = new FlowLayoutPanel();


        //Constructor
        public Viaje()
        {
            //HACE QUE SE ABRA EN PANTALLA COMPLETA
            this.WindowState = FormWindowState.Maximized;
            InitializeUI();
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
            AddItemsFilter();

            MenuProperties();
            ItemsColor();
            MarginToItems();
            ItemsCapitalLetter();

            FilterPanelProperties();
            FilterProperties();
            CardProperties();
            ButtonProperties();
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

        //Filter
        private void AddItemsFilter()
        {
            this.Controls.Add(cardsContainer);
            this.Controls.Add(filterFL);

            filterFL.Controls.Add(camionFilter);
            filterFL.Controls.Add(clienteFilter);
            filterFL.Controls.Add(choferFilter);
        }

        private void FilterPanelProperties()
        {
            filterFL.Size = new Size(400, 70);
            this.Resize += (s, e) =>
            {
                filterFL.Location = new Point((this.Width - filterFL.Width) / 2, (this.Height - filterFL.Height) / 5);
            };
            filterFL.BackColor = Color.FromArgb(50, 50, 50);
            filterFL.Padding = new Padding(0, 0, 0, 100);
        }
        private void FilterProperties()
        {
            camionFilter.Text = "CAMIÓN";
            clienteFilter.Text = "CLIENTE";
            choferFilter.Text = "CHOFER";

            camionFilter.Click += (s, e) => CardGenerator("Camión");
            clienteFilter.Click += (s, e) => CardGenerator("Cliente");
            choferFilter.Click += (s, e) => CardGenerator("Chofer");
        }
        private void CardProperties()
        {
            cardsContainer.Size = new Size(600, 300); // Ajustar tamaño del contenedor
            cardsContainer.AutoScroll = true;
            cardsContainer.BackColor = Color.FromArgb(50, 50, 50);
            cardsContainer.FlowDirection = FlowDirection.LeftToRight; // Mostrar las cards en fila
            cardsContainer.WrapContents = true; // Permitir varias líneas de cards
            cardsContainer.Margin = new Padding(0, 100, 0, 0);

            this.Resize += (s, e) =>
            {
                cardsContainer.Location = new Point((this.Width - cardsContainer.Width) / 2, (this.Height - cardsContainer.Height) / 2);
            };
        }
        private void ButtonProperties()
        {
            choferFilter.Size = new Size(125, 60);
            clienteFilter.Size = new Size(125, 60);
            camionFilter.Size = new Size(125, 60);
            camionFilter.FlatStyle = FlatStyle.Flat;
            camionFilter.FlatAppearance.BorderSize = 0;
            clienteFilter.FlatStyle = FlatStyle.Flat;
            clienteFilter.FlatAppearance.BorderSize = 0;
            choferFilter.FlatStyle = FlatStyle.Flat;
            choferFilter.FlatAppearance.BorderSize = 0;
            choferFilter.Font = new Font("Arial", 14, FontStyle.Regular);
            choferFilter.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            clienteFilter.Font = new Font("Arial", 14, FontStyle.Regular);
            clienteFilter.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            camionFilter.Font = new Font("Arial", 14, FontStyle.Regular);
            camionFilter.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void CardGenerator(String filtro)
        {
            cardsContainer.Controls.Clear(); // Limpiar las cards antes de agregar nuevas

            List<string> datos = GetFilterInfo(filtro);

            foreach (var dato in datos)
            {
                NewRoundPanel card = new NewRoundPanel()
                {
                    Size = new Size(200, 100),
                    Margin = new Padding(10),
                    BackColor = Color.LightGray
                };

                RoundButton c = new RoundButton()
                {
                    Text = dato,
                    Size = new Size(180, 80),
                    Margin = new Padding(10),
                    BackColor = Color.DarkGray
                };

                c.Click += (s, e) => ShowDetailsCard(dato);

                card.Controls.Add(c);
                cardsContainer.Controls.Add(card);
            }
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