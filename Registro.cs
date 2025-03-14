using System.Drawing;
using System.IO;
using System;
using System.Windows.Forms;

namespace AppCamiones
{
    internal class Registro : Form
    {

        //CREACIÓN DE LA BARRA DE HERRAMIENTAS Y CADA ÍTEM
        private MenuStrip menuStrip = new MenuStrip();

        private ToolStripMenuItem homeMenu = new ToolStripMenuItem("home");
        private ToolStripMenuItem viajesMenu = new ToolStripMenuItem("viajes");
        private ToolStripMenuItem chequesMenu = new ToolStripMenuItem("cheques");
        private ToolStripMenuItem registrosMenu = new ToolStripMenuItem("registro");
        private ToolStripMenuItem userMenu = new ToolStripMenuItem();
        private ToolStripMenuItem closeSesion = new ToolStripMenuItem("Cerrar sesión");

        //MENÚ DE OPCIONES
        private RoundPanel optionsMenu = new RoundPanel();
        private FlowLayoutPanel layoutOptionsMenu = new FlowLayoutPanel();

        private Button btnCamion = new Button();
        private Button btnChofer = new Button();
        private Button btnCliente = new Button();
        private Button btnCheque = new Button();
        private Button btnViaje = new Button();

        public Registro()
        {
            InitializeUI();
            InitializeOptionsMenu();


            this.StartPosition = FormStartPosition.CenterScreen;

            btnViaje.MouseEnter += new EventHandler(hoverToBtnViaje_MouseEnter);
            btnViaje.MouseLeave += new EventHandler(hoverToBtnViaje_MouseLeave);

            btnChofer.MouseEnter += new EventHandler(hoverToBtnChofer_MouseEnter);
            btnChofer.MouseLeave += new EventHandler(hoverToBtnChofer_MouseLeave);

            btnCliente.MouseEnter += new EventHandler(hoverToBtnCliente_MouseEnter);
            btnCliente.MouseLeave += new EventHandler(hoverToBtnCliente_MouseLeave);

            btnCheque.MouseEnter += new EventHandler(hoverToBtnCheque_MouseEnter);
            btnCheque.MouseLeave += new EventHandler(hoverToBtnCheque_MouseLeave);

            btnCamion.MouseEnter += new EventHandler(hoverToBtnCamion_MouseEnter);
            btnCamion.MouseLeave += new EventHandler(hoverToBtnCamion_MouseLeave);

            btnViaje.Click += new EventHandler(GoToFormViaje);
            btnChofer.Click += new EventHandler(GoToFormChofer);
            btnCliente.Click += new EventHandler(GoToFormCliente);
            btnCheque.Click += new EventHandler(GoToFormCheque);
            btnCamion.Click += new EventHandler(GoToFormCamion);
        }

        private void GoToFormViaje(object sender, EventArgs e)
        {
            AbrirFormulario("Viaje");
        }

        private void GoToFormChofer(object sender, EventArgs e)
        {
            AbrirFormulario("Chofer");
        }

        private void GoToFormCliente(object sender, EventArgs e)
        {
            AbrirFormulario("Cliente");
        }

        private void GoToFormCheque(object sender, EventArgs e)
        {
            AbrirFormulario("Cheque");
        }

        private void GoToFormCamion(object sender, EventArgs e)
        {
            AbrirFormulario("Camion");
        }

        private void AbrirFormulario(string tipoRegistro)
        {
            //FormRegistro formularioRegistro = new FormRegistro(tipoRegistro);
            //formularioRegistro.StartPosition = FormStartPosition.CenterScreen;
            //formularioRegistro.ShowDialog();
        }

        private void hoverToBtnViaje_MouseEnter(object sender, EventArgs e)
        {
            btnViaje.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnViaje.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnViaje_MouseLeave(object sender, EventArgs e)
        {
            btnViaje.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnViaje.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnChofer_MouseEnter(object sender, EventArgs e)
        {
            btnChofer.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnChofer.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnChofer_MouseLeave(object sender, EventArgs e)
        {
            btnChofer.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnChofer.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnCliente_MouseEnter(object sender, EventArgs e)
        {
            btnCliente.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnCliente.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnCliente_MouseLeave(object sender, EventArgs e)
        {
            btnCliente.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCliente.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnCheque_MouseEnter(object sender, EventArgs e)
        {
            btnCheque.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnCheque.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnCheque_MouseLeave(object sender, EventArgs e)
        {
            btnCheque.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCheque.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }

        private void hoverToBtnCamion_MouseEnter(object sender, EventArgs e)
        {
            btnCamion.Font = new Font("Nunito", 20, FontStyle.Regular);
            btnCamion.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
        }

        private void hoverToBtnCamion_MouseLeave(object sender, EventArgs e)
        {
            btnCamion.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCamion.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
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
            registrosMenu.Font = new Font("Arial", 16, FontStyle.Underline);
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

        private void InitializeOptionsMenu()
        {
            OptionsMenuProperties();
            LayoutOptionsMenuProperties();
            ButtonsProperties();
            AddButtonsToPanel();
            AddPanelToForm();
        }

        private void OptionsMenuProperties()
        {
            optionsMenu.Size = new Size(300, 400);
            this.Resize += (s, e) =>
            {
                optionsMenu.Location = new Point((this.Width - optionsMenu.Width) / 2, (this.Height - optionsMenu.Height) / 2);
            };
            optionsMenu.BackColor = System.Drawing.Color.FromArgb(100, Color.Black);
            optionsMenu.BorderStyle = BorderStyle.FixedSingle;
        }

        private void LayoutOptionsMenuProperties()
        {
            layoutOptionsMenu.AutoSize = true;
            layoutOptionsMenu.Width = btnCheque.Width;
            layoutOptionsMenu.BackColor = Color.Transparent;
            layoutOptionsMenu.FlowDirection = FlowDirection.TopDown;
            optionsMenu.Resize += (s, e) =>
            {
                layoutOptionsMenu.Location = new Point((optionsMenu.Width - layoutOptionsMenu.Width) / 2, (optionsMenu.Height - layoutOptionsMenu.Height) / 2);
            };
        }

        private void ButtonsProperties()
        {
            btnChofer.Text = "chofer";
            btnChofer.Size = new Size(150, 50);
            btnChofer.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnChofer.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnChofer.FlatStyle = FlatStyle.Flat;
            btnChofer.BackColor = Color.Transparent;
            btnChofer.FlatAppearance.BorderSize = 0;
            btnChofer.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnChofer.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnChofer.Text = btnChofer.Text.ToUpper();
            btnChofer.TextAlign = ContentAlignment.MiddleLeft;

            btnCamion.Text = "camión";
            btnCamion.Size = new Size(150, 50);
            btnCamion.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnCamion.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCamion.FlatStyle = FlatStyle.Flat;
            btnCamion.BackColor = Color.Transparent;
            btnCamion.FlatAppearance.BorderSize = 0;
            btnCamion.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCamion.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCamion.Text = btnCamion.Text.ToUpper();
            btnCamion.TextAlign = ContentAlignment.MiddleLeft;

            btnCliente.Text = "cliente";
            btnCliente.Size = new Size(150, 50);
            btnCliente.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnCliente.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCliente.FlatStyle = FlatStyle.Flat;
            btnCliente.BackColor = Color.Transparent;
            btnCliente.FlatAppearance.BorderSize = 0;
            btnCliente.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCliente.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCliente.Text = btnCliente.Text.ToUpper();
            btnCliente.TextAlign = ContentAlignment.MiddleLeft;

            btnCheque.Text = "cheque";
            btnCheque.Size = new Size(150, 50);
            btnCheque.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnCheque.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnCheque.FlatStyle = FlatStyle.Flat;
            btnCheque.BackColor = Color.Transparent;
            btnCheque.FlatAppearance.BorderSize = 0;
            btnCheque.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCheque.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCheque.Text = btnCheque.Text.ToUpper();
            btnCheque.TextAlign = ContentAlignment.MiddleLeft;

            btnViaje.Text = "viaje";
            btnViaje.Size = new Size(150, 50);
            btnViaje.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnViaje.Font = new Font("Nunito", 16, FontStyle.Regular);
            btnViaje.FlatStyle = FlatStyle.Flat;
            btnViaje.BackColor = Color.Transparent;
            btnViaje.FlatAppearance.BorderSize = 0;
            btnViaje.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnViaje.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnViaje.Text = btnViaje.Text.ToUpper();
            btnViaje.TextAlign = ContentAlignment.MiddleLeft;

        }

        private void AddPanelToForm()
        {
            this.Controls.Add(optionsMenu);
        }

        private void AddButtonsToPanel()
        {
            optionsMenu.Controls.Add(layoutOptionsMenu);
            layoutOptionsMenu.Controls.Add(btnChofer);
            layoutOptionsMenu.Controls.Add(btnViaje);
            layoutOptionsMenu.Controls.Add(btnCamion);
            layoutOptionsMenu.Controls.Add(btnCliente);
            layoutOptionsMenu.Controls.Add(btnCheque);
        }
    }
}