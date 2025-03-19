using System.Drawing;
using System.IO;
using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace AppCamiones
{
    internal class Login : Form
    {       
        //Form
        private NewRoundPanel form = new NewRoundPanel();
        private FlowLayoutPanel flowLayoutForm = new FlowLayoutPanel();

        private List<TextBox> textBoxList = new List<TextBox>();
        private System.Windows.Forms.Label pregunta = new System.Windows.Forms.Label();

        private TextBox textBoxNombreUsuario = new TextBox();
        private TextBox textBoxContraseña = new TextBox();

        private RoundButton btn_login = new RoundButton();
        private RoundButton btn_register = new RoundButton();

        private ArrayList campos_Login = new ArrayList();
        private String campo1 = "Username";
        private String campo2 = "Password";




        //Constructor
        public Login()
        {
            InitializeUI();

            this.WindowState = FormWindowState.Maximized;

            //Redirections
            btn_login.Click += new EventHandler(LoginUser_Click);
            btn_register.Click += new EventHandler(RegisterUser_Click);

            //Events
            Eventos();

            //Hovers
            textBoxNombreUsuario.Leave += new EventHandler(NombreUsuario_Leave);
            textBoxNombreUsuario.Click += new EventHandler(NombreUsuario_Click);

            textBoxContraseña.Leave += new EventHandler(Contraseña_Leave);
            textBoxContraseña.Click += new EventHandler(Contraseña_Click);
        }

        
        
        
        
        //Events
        private void Eventos()
        {
            foreach (TextBox txt in textBoxList)
            {
                switch (txt.Text)
                {
                    case "Username":
                        textBoxNombreUsuario = txt;
                        break;
                    case "Password":
                        textBoxContraseña = txt;
                        this.StartPosition = FormStartPosition.CenterScreen;
                        break;
                }
            }
        }

        
        
        
        
        
        //HoverFunctions
        private void NombreUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNombreUsuario.Text))
            {
                textBoxNombreUsuario.Text = "Username";
                textBoxNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77); // Cambia el color del texto placeholder
            }
        }
        private void NombreUsuario_Click(object sender, EventArgs e)
        {
            if (textBoxNombreUsuario.Text == "Username")
            {
                textBoxNombreUsuario.Text = "";
                textBoxNombreUsuario.ForeColor = Color.Black; // Cambia el color del texto
            }
        }

        private void Contraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxContraseña.Text))
            {
                textBoxContraseña.Text = "Password";
                textBoxContraseña.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
                textBoxContraseña.Font = new Font("Nunito", 10, FontStyle.Regular);
            }
        }
        private void Contraseña_Click(object sender, EventArgs e)
        {
            if(textBoxContraseña.Text == "Password")
            {
                textBoxContraseña.Text = "";
                textBoxContraseña.ForeColor = Color.Black;
            }
        }

        





        //RedirectionalFunctions
        private void LoginUser_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in textBoxList)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }
        private void RegisterUser_Click(object sender, EventArgs e)
        {
            Class1 rr = new Class1();
            this.Hide();
            rr.ShowDialog();
            this.Show();
        }







        //Initializations
        private void InitializeUI()
        {
            InitializeForm();
            InitializeBackImage();
            InitializeIconoApp();
        }
        private void InitializeForm()
        {
            FormProperties();
            LayoutFormProperties();
            TextBoxAndLabelProperties();
            ButtonsProperties();
            AddLabels();
            AddForm();
        }
        private void InitializeBackImage()
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "goma.jpg");

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






        //Adds
        private void AddLabels()
        {
            form.Controls.Add(flowLayoutForm);
            flowLayoutForm.Controls.Add(btn_login);
            flowLayoutForm.Controls.Add(pregunta);
            flowLayoutForm.Controls.Add(btn_register);
        }
        private void AddForm()
        {
            this.Controls.Add(form);
        }







        //FormProperties
        private void FormProperties()
        {
            form.Size = new Size(450, 450);
            this.Resize += (s, e) =>
            {
                form.Location = new Point((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
            };

            form.BackColor = System.Drawing.Color.FromArgb(130, Color.Black);
        }
        private void LayoutFormProperties()
        {
            flowLayoutForm.Size = new Size(400, 310);
            flowLayoutForm.BackColor = Color.Transparent;
            flowLayoutForm.Location = new Point((form.Width - flowLayoutForm.Width) / 2, (form.Height - flowLayoutForm.Height) / 2);
            flowLayoutForm.FlowDirection = FlowDirection.TopDown;

        }
        private void TextBoxAndLabelProperties()
        {
            campos_Login.Add(campo1);
            campos_Login.Add(campo2);
            

            for (int i = 0; i < campos_Login.Count; i++)
            {
                System.Windows.Forms.Label campos = new System.Windows.Forms.Label();
                TextBox textBoxCampos = new TextBox();

                
                    campos.Text = campos_Login[i].ToString();
                    textBoxCampos.Text = campos_Login[i].ToString();
               
                campos.Font = new Font("Nunito", 10, FontStyle.Regular);
                campos.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
                campos.BackColor = Color.Transparent;
                campos.Margin = new Padding(80, 10, 0, 0);
                campos.AutoSize = true;

                textBoxCampos.Font = new Font("Nunito", 10, FontStyle.Regular);
                textBoxCampos.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
                textBoxCampos.Multiline = true;
                textBoxCampos.Width = 200;
                textBoxCampos.Height = 30;
                textBoxCampos.BorderStyle = BorderStyle.None;
                textBoxCampos.Margin = new Padding(90, 10, 0, 10);
                textBoxCampos.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);


                flowLayoutForm.Controls.Add(campos);
                flowLayoutForm.Controls.Add(textBoxCampos);
                textBoxList.Add(textBoxCampos);

            }

            pregunta.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            pregunta.Text = "¿No tienes una cuenta?";
            pregunta.Font = new Font("Nunito", 10, FontStyle.Regular);
            pregunta.AutoSize = true;
            pregunta.TextAlign = ContentAlignment.TopCenter;
            pregunta.Margin = new Padding(113, 50, 0, 0); 
        }
        private void ButtonsProperties()
        {
            btn_login.BackColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btn_login.AutoSize = true;
            btn_login.Text = "Iniciar sesión";
            btn_login.Height = 30;
            btn_login.FlatStyle = FlatStyle.Flat;
            btn_login.FlatAppearance.BorderSize = 0;
            btn_login.Margin = new Padding(130, 10, 0, 0);
            btn_login.ForeColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_login.Font = new Font("Nunito", 12, FontStyle.Bold);

            btn_register.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_register.Size = new Size(150, 30);
            btn_register.Text = "Registrarse";
            btn_register.FlatStyle = FlatStyle.Flat;
            btn_register.FlatAppearance.BorderSize = 0;  // Grosor del borde
            btn_register.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 218, 28); // Color del borde
            btn_register.Margin = new Padding(118, 5, 0, 0);
            btn_register.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btn_register.Font = new Font("Nunito", 12, FontStyle.Bold);
        }
    }
}