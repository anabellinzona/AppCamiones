using System.Drawing;
using System.IO;
using System;
using System.Windows.Forms;
using System.Collections;

namespace AppCamiones
{
    internal class Registro : Home
    {

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


        //Constructor
        public Registro()
        {
            InitializeOptionsMenu();

            ResaltarBoton(registrosMenu);

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            Login formUser = new Login();


            // Hovers
            btnViaje.MouseEnter += (s, e) => HoverEffect(s, e, true);
            btnViaje.MouseLeave += (s, e) => HoverEffect(s, e, false);

            btnChofer.MouseEnter += (s, e) => HoverEffect(s, e, true);
            btnChofer.MouseLeave += (s, e) => HoverEffect(s, e, false);

            btnCliente.MouseEnter += (s, e) => HoverEffect(s, e, true);
            btnCliente.MouseLeave += (s, e) => HoverEffect(s, e, false);

            btnCheque.MouseEnter += (s, e) => HoverEffect(s, e, true);
            btnCheque.MouseLeave += (s, e) => HoverEffect(s, e, false);

            btnCamion.MouseEnter += (s, e) => HoverEffect(s, e, true);
            btnCamion.MouseLeave += (s, e) => HoverEffect(s, e, false);

            //RegisterFormRedirections
            btnViaje.Click += new EventHandler(GoToFormViaje);
            btnChofer.Click += new EventHandler(GoToFormChofer);
            btnCliente.Click += new EventHandler(GoToFormCliente);
            btnCheque.Click += new EventHandler(GoToFormCheque);
            btnCamion.Click += new EventHandler(GoToFormCamion);
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


        private void HoverEffect(object sender, EventArgs e, bool isHover)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.Font = new Font("Nunito", isHover ? 20 : 16, FontStyle.Regular);
                button.ForeColor = isHover ? Color.FromArgb(218, 218, 28) : Color.FromArgb(224, 224, 224);
            }
        }







        //Initializations
        private void InitializeOptionsMenu()
        {
            OptionsMenuProperties();
            LayoutOptionsMenuProperties();
            ButtonsProperties();
            AddButtonsToPanel();
            AddPanelToForm();
        }
       






        //Adds
        private void AddPanelToForm()
        {
            this.Controls.Add(optionsMenu);
        }

        private void AddButtonsToPanel()
        {
            optionsMenu.Controls.Add(layoutOptionsMenu);
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