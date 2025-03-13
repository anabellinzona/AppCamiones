using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCamiones
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Class1 registrer = new Class1())
            {
                using (Login loginForm = new Login())
                {
                    if (registrer.ShowDialog() == DialogResult.OK)
                    {
                        if (loginForm.ShowDialog() == DialogResult.OK) // Si el usuario inicia sesión correctamente
                        {
                            Application.Run(new Form1()); // Ejecuta el formulario principal
                        }
                    } else if(loginForm.ShowDialog() == DialogResult.OK)
                    {
                        if (loginForm.ShowDialog() == DialogResult.OK)
                        {
                            Application.Run(new Form1()); // Ejecuta el formulario principal
                        }
                        Application.Run(new Viaje());
                    }
                }
            }
        }
    }
}
