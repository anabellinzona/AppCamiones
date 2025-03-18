using System.Drawing;
using System.IO;
using System;
using System.Windows.Forms;
using System.Collections;

namespace AppCamiones
{
    internal class Registro : Form
    {
        //Nav
        private MenuStrip menuStrip = new MenuStrip();

        private ToolStripMenuItem homeMenu = new ToolStripMenuItem("home");
        private ToolStripMenuItem viajesMenu = new ToolStripMenuItem("viajes");
        private ToolStripMenuItem chequesMenu = new ToolStripMenuItem("cheques");
        private ToolStripMenuItem registrosMenu = new ToolStripMenuItem("registro");
        private ToolStripMenuItem userMenu = new ToolStripMenuItem();
        private ToolStripMenuItem closeSesion = new ToolStripMenuItem("Cerrar sesión");

        //RegisterOptions
        private NewRoundPanel optionsMenu = new NewRoundPanel();
        private FlowLayoutPanel layoutOptionsMenu = new FlowLayoutPanel();

        private Button btnCamion = new Button();
        private Button btnChofer = new Button();
        private Button btnCliente = new Button();
        private Button btnCheque = new Button();
        private Button btnViaje = new Button();

        private ArrayList botonesRegistro = new ArrayList();
        private ArrayList nombreBotonesRegistro = new ArrayList();


        //Constructir
        public Registro()
        {
            InitializeUI();

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            Login formUser = new Login();
            
            
            //Hovers
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


            //NavRedirections
            closeSesion.Click += new EventHandler(GoToFormUser_Click);
            chequesMenu.Click += new EventHandler(GoToCheque_Click);
            viajesMenu.Click += new EventHandler(GoToViaje_Click);
            homeMenu.Click += new EventHandler(GoToHome_Click);


            //RegisterFormRedirections
            btnViaje.Click += new EventHandler(GoToFormViaje);
            btnChofer.Click += new EventHandler(GoToFormChofer);
            btnCliente.Click += new EventHandler(GoToFormCliente);
            btnCheque.Click += new EventHandler(GoToFormCheque);
            btnCamion.Click += new EventHandler(GoToFormCamion);
        }






        //NavRedirectionalFunctions
        private void GoToViaje_Click(object sender, EventArgs e)
        {
            Viaje viaje = new Viaje();
            viaje.Show();
            this.Close();
        }
        private void GoToCheque_Click(object sender, EventArgs e)
        {
            Cheque tablaCheque = new Cheque();
            tablaCheque.ShowDialog();
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






        //FormRedirectionalFunctions
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
            FormRegistro formularioRegistro = new FormRegistro(tipoRegistro);
            formularioRegistro.StartPosition = FormStartPosition.CenterScreen;
            formularioRegistro.ShowDialog();
        }






        //HoverFunctions
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





        //Initializations
        private void InitializeUI()
        {
            InitializeBackImage();
            InitializeIconoApp();
            InitializeIconoUser();
            InitializeToolBar();
            InitializeOptionsMenu();
        }
        private void InitializeToolBar()
        {
            ItemsCapitalLetter();
            MenuProperties();
            ItemsColor();
            MarginToItems();
            AddItemsToMenu();
        }
        private void InitializeOptionsMenu()
        {
            OptionsMenuProperties();
            LayoutOptionsMenuProperties();
            ButtonsProperties();
            AddButtonsToPanel();
            AddPanelToForm();
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

                this.BackgroundImage = img;
            }
            else
            {
                MessageBox.Show("La imagen no se encuentra: " + imagePath);
            }
        }
        private void InitializeIconoApp()
        {
            string iconoApp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "icono_camion.ico");

            if (File.Exists(iconoApp))
            {
                this.Icon = new Icon(iconoApp);
            }
            else
            {
                MessageBox.Show("La imagen no se encuentra: " + iconoApp);
            }
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





        //Adds
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
        private void AddPanelToForm()
        {
            this.Controls.Add(optionsMenu);
        }

        private void AddButtonsToPanel()
        {
            optionsMenu.Controls.Add(layoutOptionsMenu);
        }





        //NavProperties
        private void ItemsCapitalLetter()
        {
            homeMenu.Text = homeMenu.Text.ToUpper();
            viajesMenu.Text = viajesMenu.Text.ToUpper();
            chequesMenu.Text = chequesMenu.Text.ToUpper();
            registrosMenu.Text = registrosMenu.Text.ToUpper();
            userMenu.Text = userMenu.Text.ToUpper();
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
            registrosMenu.Font = new Font("Arial", 16, FontStyle.Underline);
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

        

        
        //RegisterOptionsProperties
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
            int j = 0;

            botonesRegistro.Add(btnChofer);
            botonesRegistro.Add(btnViaje);
            botonesRegistro.Add(btnCamion);
            botonesRegistro.Add(btnCliente);
            botonesRegistro.Add(btnCheque);

            nombreBotonesRegistro.Add("Chofer");
            nombreBotonesRegistro.Add("Viaje");
            nombreBotonesRegistro.Add("Camión");
            nombreBotonesRegistro.Add("Cliente");
            nombreBotonesRegistro.Add("Cheque");
            for (int i = 0; i < botonesRegistro.Count; i++)
            {
                Button btn = (Button)botonesRegistro[i];

                btn.Size = new Size(150, 50);
                btn.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
                btn.Font = new Font("Nunito", 16, FontStyle.Regular);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.TextAlign = ContentAlignment.MiddleLeft;

                if (j < nombreBotonesRegistro.Count)
                {
                    btn.Text = nombreBotonesRegistro[j].ToString();
                    btn.Text = nombreBotonesRegistro[j].ToString().ToUpper();
                    j++;
                }

                layoutOptionsMenu.Controls.Add(btn);
            }
        }
    }
}