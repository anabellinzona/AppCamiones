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
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppCamiones
{
    internal class Viaje : Home
    {
        //Filter
        private NewRoundPanel filter = new NewRoundPanel();
        private FlowLayoutPanel filterFL = new FlowLayoutPanel();

        private ArrayList buttonsFilter = new ArrayList();
        private ArrayList buttonsNameFilter = new ArrayList();
        private RoundButton fleteFilter = new RoundButton();
        private RoundButton camionFilter = new RoundButton();
        private RoundButton clienteFilter = new RoundButton();

        private RoundButton agregarNuevo = new RoundButton();

        private ArrayList botonesRegistro = new ArrayList();
        private ArrayList nombreBotonesRegistro = new ArrayList();

        private RoundButton btn_volver = new RoundButton();


        //Card
        private FlowLayoutPanel cardsContainer = new FlowLayoutPanel();



        //Constructor
        public Viaje()
        {
            InitializeUI();
            ResaltarBoton(viajesMenu);


            //Hovers
            fleteFilter.MouseEnter += (s, e) => HoverEffect(s, e, true);
            fleteFilter.MouseLeave += (s, e) => HoverEffect(s, e, false);

            clienteFilter.MouseEnter += (s, e) => HoverEffect(s, e, true);
            clienteFilter.MouseLeave += (s, e) => HoverEffect(s, e, false);

            camionFilter.MouseEnter += (s, e) => HoverEffect(s, e, true);
            camionFilter.MouseLeave += (s, e) => HoverEffect(s, e, false);

            //Events
            fleteFilter.Click += (s, e) => CardGenerator("Chofer", " ");
            clienteFilter.Click += (s, e) => CardGenerator("Cliente", " ");
            camionFilter.Click += (s, e) => CardGenerator("Camión", " ");
        }


        //HoverFunction
        private void HoverEffect(object sender, EventArgs e, bool isHover)
        {
            var button = sender as RoundButton;
            if (button != null)
            {
                button.Font = new Font("Nunito", isHover ? 20 : 16, FontStyle.Regular);
                button.ForeColor = isHover ? Color.FromArgb(218, 218, 28) : Color.FromArgb(224, 224, 224);
            }
        }



        //Initializations
        private void InitializeUI()
        {
            InitializeToolBar();
        }

        private void InitializeToolBar()
        {
            InitializeFilterCards();
        }

        private void InitializeFilterCards()
        {
            OptionsMenuProperties();
            LayoutOptionsMenuProperties();
            ButtonsProperties();
            CardProperties();
            AddItemsToFilter();
            AddButtonNewAdd();
            ButtonNewAddProperties();
        }

        private void AddItemsToFilter()
        {
            this.Controls.Add(filter);
            this.Controls.Add(cardsContainer);
            filter.Controls.Add(filterFL);
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
            filterFL.Width = fleteFilter.Width;
            filterFL.BackColor = Color.Transparent;
            filterFL.FlowDirection = FlowDirection.LeftToRight;
            filter.Resize += (s, e) =>
            {
                filterFL.Location = new Point((filter.Width - filterFL.Width) / 2, (filter.Height - filterFL.Height) / 2);
            };
        }

        private void AddButtonNewAdd()
        {
            cardsContainer.Controls.Add(agregarNuevo);
        }

        //InfoFunctions
        public void CardGenerator(string filtro, string info)
        {
            cardsContainer.Controls.Clear();

            List<string> datos = GetFilterInfo(filtro, info);

            foreach (string dato in datos)
            {
                Panel card = new Panel
                {
                    Size = new Size(200, 100),
                    BackColor = System.Drawing.Color.FromArgb(48, 48, 48),
                    Margin = new Padding(10),
                    Font = new Font("Nunito", 16, FontStyle.Regular),
                };

                Label label = new Label
                {
                    Text = dato,
                    ForeColor = System.Drawing.Color.FromArgb(218, 218, 28),
                    AutoSize = true,
                    TextAlign = ContentAlignment.TopCenter,
                    Location = new Point(10, 10),
                    BackColor = Color.Transparent
                };

                card.Controls.Add(label);
                cardsContainer.Controls.Add(card);

                card.Click += (s, e) =>
                {
                    ViajeFiltro form = new ViajeFiltro();
                    form.Show();
                };
            }
        }
        public List<string> GetFilterInfo(string filtro, string info)
        {
            if (filtro == "Camión")
            {
                if (info != " ")
                {
                    MessageBox.Show(info);
                    return new List<string> { info };
                }
                else
                {
                    return new List<string> { };
                }
            }
            else if (filtro == "Cliente")
            {
                return new List<string> { "Gómez", "Pérez", "Rodríguez" };
            }
            else if (filtro == "Flete")
            {
                return new List<string> { "López", "Fernández", "Martínez" };
            }
            else
            {
                return new List<string>();
            }
        }
        private void ButtonsProperties()
        {
            int j = 0;

            buttonsFilter.Add(fleteFilter);
            buttonsFilter.Add(clienteFilter);
            buttonsFilter.Add(camionFilter);

            buttonsNameFilter.Add("Flete");
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

                btn.Click += (s, e) => CardGenerator(btn.Text, " ");

                filterFL.Controls.Add(btn);
            }
        }

        //CardProperties
        private void CardProperties()
        {
            cardsContainer.Size = new Size(800, 400);
            cardsContainer.AutoScroll = true;
            cardsContainer.FlowDirection = FlowDirection.LeftToRight;
            cardsContainer.WrapContents = true;
            cardsContainer.Margin = new Padding(10, 10, 10, 10);
            cardsContainer.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);

            this.Resize += (s, e) =>
            {
                cardsContainer.Location = new Point((this.Width - cardsContainer.Width) / 2, filter.Bottom + 10);
            };
        }

        private void ButtonNewAddProperties()
        {
            agregarNuevo.Size = new Size(200, 150);
            agregarNuevo.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
            agregarNuevo.Text = "+";
            agregarNuevo.FlatStyle = FlatStyle.Flat;
            agregarNuevo.FlatAppearance.BorderSize = 0;  // Grosor del borde
            agregarNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(218, 218, 28); // Color del borde
            agregarNuevo.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            agregarNuevo.Font = new Font("Nunito", 24, FontStyle.Bold);
            //agregarNuevo.Location = new Point(400, 200);
            agregarNuevo.Margin = new Padding((cardsContainer.Width - agregarNuevo.Width) / 2, (cardsContainer.Height - agregarNuevo.Height) / 2, 0, 0);

            agregarNuevo.Click += (s, e) => FormAddNew();
        }

        private void FormAddNew()
        {
            FormRegistro ff = new FormRegistro("newSection");
            {
                StartPosition = FormStartPosition.CenterScreen;
            }
            ff.ShowDialog();
        }
    }
}
