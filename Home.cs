using System.Drawing;
using System.IO;
using System;
using System.Windows.Forms;

namespace AppCamiones
{
    public class Home : Form
    {
        //CREACIÓN DE LA BARRA DE HERRAMIENTAS Y CADA ÍTEM
        protected MenuStrip menuStrip = new MenuStrip();

        protected ToolStripMenuItem homeMenu = new ToolStripMenuItem("home");
        protected ToolStripMenuItem viajesMenu = new ToolStripMenuItem("viajes");
        protected ToolStripMenuItem chequesMenu = new ToolStripMenuItem("cheques");
        protected ToolStripMenuItem registrosMenu = new ToolStripMenuItem("registro");
        private ToolStripMenuItem userMenu = new ToolStripMenuItem();
        protected ToolStripMenuItem closeSesion = new ToolStripMenuItem("Cerrar sesión");



        public Home()
        {
            InitializeUI();

            closeSesion.Click += new EventHandler(GoToFormUser_Click);
            chequesMenu.Click += new EventHandler(GoToCheque_Click);
            viajesMenu.Click += new EventHandler(GoToViaje_Click);
            registrosMenu.Click += new EventHandler(GoToRegistro_Click);
            homeMenu.Click += new EventHandler(GoToHome_Click);
        }
        private void GoToCheque_Click(object sender, EventArgs e)
        {
            Cheque cheque = new Cheque(); 
            cheque.Show();
        }

        private void GoToViaje_Click(object sender, EventArgs e)
        {
            Viaje vv = new Viaje();
            vv.Show();
        }

        private void GoToRegistro_Click(object sender, EventArgs e)
        {
            Registro formRegistro = new Registro();
            formRegistro.Show();
        }

        private void GoToFormUser_Click(object sender, EventArgs e)
        {
            Login formUser = new Login();
            formUser.ShowDialog();
        }

        private void GoToHome_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
        }

        public void ResaltarBoton(ToolStripMenuItem menuItem)
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                item.BackColor = Color.Transparent;
                item.Font = new Font(item.Font, FontStyle.Regular);
            }

            if (menuItem != null)
            {
                menuItem.Font = new Font("Nunito", 16, FontStyle.Underline);
            }
        }

        private void InitializeUI()
        {
            InitializeBackImage();
            InitializeIconoApp();
            InitializeIconoUser();
            InitializeToolBar();
        }

        private void InitializeBackImage()
        {
            // Ruta absoluta a la imagen en la carpeta de Descargas
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "goma.jpg");

            // Verifica si existe el archivo
            if (File.Exists(imagePath))
            {
                // Carga la imagen
                Image img = Image.FromFile(imagePath);

                // Verifica si la imagen tiene un valor de orientación en sus metadatos EXIF
                if (Array.Exists(img.PropertyIdList, id => id == 0x0112)) // 0x0112 es el ID de la propiedad "Orientation"
                {
                    // Lee el valor de la propiedad de orientación EXIF
                    int orientation = BitConverter.ToUInt16(img.GetPropertyItem(0x0112).Value, 0);

                    // Corrige la orientación de la imagen en base al valor EXIF
                    switch (orientation)
                    {
                        case 1:
                            // Sin rotación (normal)
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

                // Asigna la imagen corregida al fondo
                this.BackgroundImage = img;
            }
            else
            {
                // Muestra un mensaje de error si no se encuentra la imagen
                MessageBox.Show("La imagen no se encuentra: " + imagePath);
            }
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
            menuStrip.Width = this.Width;
            menuStrip.Height = 80;
            menuStrip.Dock = DockStyle.Top;
        }

        private void ItemsColor()
        {
            //ASIGNA EL COLOR A LOS ÍTEMS
            homeMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            viajesMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            chequesMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            registrosMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            userMenu.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            closeSesion.ForeColor = System.Drawing.Color.FromArgb(141, 138, 138);
        }

        private void MarginToItems()
        {
            //MARGIN
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

        private void AddItemsToMenu()
        {
            //AGREGA AL MENÚ LOS ÍTEMS
            menuStrip.Items.Add(homeMenu);
            menuStrip.Items.Add(viajesMenu);
            menuStrip.Items.Add(chequesMenu);
            menuStrip.Items.Add(registrosMenu);
            menuStrip.Items.Add(userMenu);

            userMenu.DropDownItems.Add(closeSesion);

            // AGREGA AL FORM LA BARRA DE HERRAMIENTAS
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

    }
}