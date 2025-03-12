using System.Drawing;
using System.IO;
using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AppCamiones
{
    public partial class Login : Form
    {
        
        

        //DECLARACIÓN DEL FORM
        private RoundPanel form = new RoundPanel();

        private FlowLayoutPanel flowLayoutForm = new FlowLayoutPanel();

        private Label nombre_usuario = new Label();
        private Label contraseña = new Label();
        private Label pregunta = new Label();

        private RoundTextBox textBoxNombreUsuario = new RoundTextBox();
        private RoundTextBox textBoxContraseña = new RoundTextBox();

        private RoundButton btn_login = new RoundButton();
        private RoundButton btn_register = new RoundButton();


        public Login()
        {
            InitializeUI();
            btn_login.Click += new EventHandler(LoginUser_Click);
            btn_register.Click += new EventHandler(RegisterUser_Click);

            textBoxNombreUsuario.Leave += new EventHandler(NombreUsuario_Leave);
            textBoxNombreUsuario.Click += new EventHandler(NombreUsuario_Click);

            textBoxContraseña.Leave += new EventHandler(Contraseña_Leave);
            textBoxContraseña.Click += new EventHandler(Contraseña_Click);
        }

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
                textBoxContraseña.Text = "PassWord";
                textBoxContraseña.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
            }
        }

        private void Contraseña_Click(object sender, EventArgs e)
        {
            if(textBoxContraseña.Text == "Password")
            {
                textBoxContraseña.Text = "";
                textBoxContraseña.PasswordChar = '*';
                textBoxContraseña.Font = new Font("Nunito", 14, FontStyle.Regular);
                textBoxContraseña.ForeColor = Color.Black;
            }
        }

        private void LoginUser_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void RegisterUser_Click(object sender, EventArgs e)
        {
            Class1 rr = new Class1();
            this.Hide();
            rr.ShowDialog();
            this.Show();
        }

        private void InitializeUI()
        {
            InitializeBackImage();
            InitializeIconoApp();
            InitializeForm();
        }

        private void InitializeBackImage()
        {
            // Ruta absoluta a la imagen en la carpeta de Descargas
            string imagePath = @"C:\Users\usuario\Downloads\goma.jpeg";

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


        //FORMULARIO DE LOGIN
        private void InitializeForm()
        {
            FormProperties();
            LayoutFormProperties();
            LabelProperties();
            TextBoxProperties();
            ButtonsProperties();
            AddLabels();
            AddForm();
        }

        private void FormProperties()
        {
            form.Size = new Size(450, 450);
            this.Resize += (s, e) =>
            {
                form.Location = new Point((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
            };

            form.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
        }

        private void LayoutFormProperties()
        {
            flowLayoutForm.Size = new Size(400, 310);
            flowLayoutForm.BackColor = Color.Transparent;
            flowLayoutForm.Location = new Point((form.Width - flowLayoutForm.Width) / 2, (form.Height - flowLayoutForm.Height) / 2);
            flowLayoutForm.FlowDirection = FlowDirection.TopDown;

        }

        private void LabelProperties()
        {
            contraseña.Text = "Contraseña:";
            contraseña.Font = new Font("Nunito", 12, FontStyle.Regular);
            contraseña.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            contraseña.BackColor = Color.Transparent;
            contraseña.Margin = new Padding(80, 10, 0, 0);
            contraseña.AutoSize = true;

            nombre_usuario.Text = "Nombre de usuario:";
            nombre_usuario.Font = new Font("Nunito", 12, FontStyle.Regular);
            nombre_usuario.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            nombre_usuario.BackColor = Color.Transparent;
            nombre_usuario.Margin = new Padding(80, 10, 0, 0);
            nombre_usuario.AutoSize = true;

            pregunta.ForeColor = System.Drawing.Color.FromArgb(217, 217, 217);
            pregunta.Text = "¿No tienes una cuenta?";
            pregunta.Font = new Font("Nunito", 12, FontStyle.Regular);
            pregunta.AutoSize = true;
            pregunta.TextAlign = ContentAlignment.TopCenter;
            pregunta.Margin = new Padding(100, 30, 0, 0); 
        }

        private void TextBoxProperties()
        {
            textBoxContraseña.Text = "Password";
            textBoxContraseña.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxContraseña.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxContraseña.Multiline = true;
            textBoxContraseña.Width = 200;
            textBoxContraseña.Height = 25;
            textBoxContraseña.BorderStyle = BorderStyle.None;
            textBoxContraseña.Margin = new Padding(90, 10, 0, 10);
            textBoxContraseña.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);

            textBoxNombreUsuario.Text = "Username";
            textBoxNombreUsuario.Font = new Font("Nunito", 10, FontStyle.Regular);
            textBoxNombreUsuario.BackColor = System.Drawing.Color.FromArgb(153, 145, 145);
            textBoxNombreUsuario.Multiline = true;
            textBoxNombreUsuario.Width = 200;
            textBoxNombreUsuario.Height = 25;
            textBoxNombreUsuario.BorderStyle = BorderStyle.None;
            textBoxNombreUsuario.Margin = new Padding(90, 10, 0, 10);
            textBoxNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(81, 77, 77);
        }

        private void ButtonsProperties()
        {
            btn_login.BackColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btn_login.AutoSize = true;
            btn_login.Text = "Iniciar sesión";
            btn_login.FlatStyle = FlatStyle.Flat;
            btn_login.FlatAppearance.BorderSize = 0;
            btn_login.Margin = new Padding(130, 10, 0, 0);
            btn_login.ForeColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_login.Font = new Font("Nunito", 12, FontStyle.Bold);

            btn_register.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            btn_register.Size = new Size(150, 40);
            btn_register.Text = "Registrarse";
            btn_register.FlatStyle = FlatStyle.Flat;
            btn_register.FlatAppearance.BorderSize = 2;  // Grosor del borde
            btn_register.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 218, 28); // Color del borde
            btn_register.Margin = new Padding(115, 20, 0, 0);
            btn_register.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            btn_register.Font = new Font("Nunito", 12, FontStyle.Bold);
        }
        private void AddLabels()
        {
            form.Controls.Add(flowLayoutForm);
            flowLayoutForm.Controls.Add(nombre_usuario);
            flowLayoutForm.Controls.Add(textBoxNombreUsuario);
            flowLayoutForm.Controls.Add(contraseña);
            flowLayoutForm.Controls.Add(textBoxContraseña);
            flowLayoutForm.Controls.Add(btn_login);
            flowLayoutForm.Controls.Add(pregunta);
            flowLayoutForm.Controls.Add(btn_register);   
        }
        private void AddForm()
        {
            this.Controls.Add(form);
        }
    }
}