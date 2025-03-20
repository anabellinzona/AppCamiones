using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AppCamiones
{
    public partial class Form1 : Home
    {

        //TravelsTable
        private Panel table_travel = new Panel();

        private Label travel_title = new Label();
        private Label travel_title2 = new Label();

        private FlowLayoutPanel layoutTableTravelToday = new FlowLayoutPanel();
        private FlowLayoutPanel layoutTableTravelNext = new FlowLayoutPanel();
        private FlowLayoutPanel layoutTravelNext = new FlowLayoutPanel();
        private FlowLayoutPanel layoutTravelToday = new FlowLayoutPanel();

        //PayTable
        private FlowLayoutPanel layoutTablePay = new FlowLayoutPanel();
        private FlowLayoutPanel layoutPay = new FlowLayoutPanel();

        private Panel table_pay = new Panel();
        private Label pay_title = new Label();

       


        //Constructor
        public Form1()
        {
            InitializeUI();
            this.WindowState = FormWindowState.Maximized;

            ResaltarBoton(homeMenu);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        //Initializations
        private void InitializeUI()
        { 
            InitializePanel();
        }
        private void InitializePanel()
        {
            TableTravel();
            TablePay();
            AddTablesToControls();
        }
        private void TableTravel()
        {
            TableTravelProperties();
            LayoutTableTravelTodayProperties();
            LayoutTableTravelNextProperties();
            LayoutTravelNextProperties();
            LayoutTravelTodayProperties();
            TableTravelTitleProperties();
            AddTitleToTableTravel();
            AddTravelToday();
            AddTravel();
        }




        //Adds
        private void AddTravelToday()
        {
            for (int i = 0; i < 8; i++)
            {
                Label travel = new Label();
                if (i >= 4)
                {
                    travel.Margin = new Padding(0, 10, 0, 0);
                }
                else
                {
                    travel.Margin = new Padding(60, 10, 0, 0);
                }
                TravelProperties(travel);
                layoutTravelToday.Controls.Add(travel);
                travel.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            }
        }
        private void AddTravel()
        {
            for (int i = 0; i < 8; i++)
            {
                Label travel = new Label();
                if (i >= 4)
                {
                    travel.Margin = new Padding(0, 10, 0, 0);
                }
                else
                {
                    travel.Margin = new Padding(60, 10, 0, 0);
                }
                TravelProperties(travel);
                layoutTravelNext.Controls.Add(travel);
                travel.ForeColor = System.Drawing.Color.FromArgb(141, 138, 138);
            }
        }
        private void AddTitleToTableTravel()
        {
            table_travel.Controls.Add(layoutTableTravelToday);
            table_travel.Controls.Add(layoutTableTravelNext);
            layoutTableTravelToday.Controls.Add(travel_title);
            layoutTableTravelNext.Controls.Add(travel_title2);
            layoutTableTravelNext.Controls.Add(layoutTravelNext);
            layoutTableTravelToday.Controls.Add(layoutTravelToday);

        }
        private void AddPendingPayments()
        {
            CheckedListBox pay = new CheckedListBox();
            for (int i = 0; i < 8; i++)
            {
                pay.Items.Add("Apellido, nombre");
                PayProperties(pay);
                layoutPay.Controls.Add(pay);
            }
        }


        //TravelTableProperties
        private void TableTravelProperties()
        {
            table_travel.Padding = new Padding(0);
            table_travel.Margin = new Padding(0);
            table_travel.Size = new Size(740, int.MaxValue);
            table_travel.Location = new Point(150, 180);
            table_travel.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
            table_travel.BorderStyle = BorderStyle.FixedSingle;
            table_travel.AutoSize = true;
        }
        private void LayoutTableTravelTodayProperties()
        {
            layoutTableTravelToday.Padding = new Padding(0);
            layoutTableTravelToday.Margin = new Padding(0);


            table_travel.Resize += (s, e) =>
            {
                layoutTableTravelToday.Location = new Point((table_travel.Width - layoutTableTravelToday.Width) / 2, 20);
            };

            layoutTableTravelToday.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTableTravelToday.BackColor = Color.Transparent;
            layoutTableTravelToday.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTableTravelToday.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTableTravelToday.WrapContents = false; // Evita que los elementos pasen a otra línea
            layoutTableTravelToday.Width = table_travel.Width;
            layoutTableTravelToday.Size = new Size(table_travel.Width, 200);
        }
        private void LayoutTableTravelNextProperties()
        {
            layoutTableTravelNext.Padding = new Padding(0);
            layoutTableTravelNext.Margin = new Padding(0);

            table_travel.Resize += (s, e) =>
            {
                layoutTableTravelNext.Location = new Point((table_travel.Width - layoutTableTravelNext.Width) / 2, 240);
            };
            layoutTableTravelNext.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTableTravelNext.Size = new Size(table_travel.Width, 200);
            layoutTableTravelNext.BackColor = Color.Transparent;
            layoutTableTravelNext.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTableTravelNext.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTableTravelNext.WrapContents = true;//Evita que los elementos pasen a otra línea
        }
        private void LayoutTravelNextProperties()
        {
            layoutTravelNext.Padding = new Padding(0);
            layoutTravelNext.Margin = new Padding(0);

            table_travel.Resize += (s, e) =>
            {
                layoutTableTravelNext.Location = new Point((layoutTableTravelNext.Width - layoutTravelNext.Width) / 2, 240);
            };
            layoutTravelNext.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTravelNext.Size = new Size(layoutTableTravelNext.Width, 160);
            layoutTravelNext.AutoScroll = true;
            layoutTravelNext.BackColor = Color.Transparent;
            layoutTravelNext.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTravelNext.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTravelNext.WrapContents = true;//Evita que los elementos pasen a otra línea
        }
        private void LayoutTravelTodayProperties()
        {
            layoutTravelToday.Padding = new Padding(0);
            layoutTravelToday.Margin = new Padding(0);

            table_travel.Resize += (s, e) =>
            {
                layoutTableTravelToday.Location = new Point((layoutTableTravelToday.Width - layoutTravelToday.Width) / 2, 20);
            };
            layoutTravelToday.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTravelToday.Size = new Size(layoutTableTravelToday.Width, 180);
            layoutTravelToday.AutoScroll = true;
            layoutTravelToday.BackColor = Color.Transparent;
            layoutTravelToday.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTravelToday.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTravelToday.WrapContents = true;//Permite que los elementos pasen a otra línea
        }
        private void TableTravelTitleProperties()
        {
            travel_title.Text = "viajes programados para hoy:";
            travel_title.Font = new Font("Arial", 14, FontStyle.Regular);
            travel_title.Text = travel_title.Text.ToUpper();
            travel_title.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            travel_title.BackColor = Color.Transparent;
            travel_title.TextAlign = ContentAlignment.TopCenter;
            travel_title.AutoSize = false;
            travel_title.Width = layoutTableTravelToday.Width;
            
            travel_title2.Text = "viajes próximos:";
            travel_title2.Font = new Font("Arial", 14, FontStyle.Regular);
            travel_title2.Text = travel_title2.Text.ToUpper();
            travel_title2.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            travel_title2.BackColor = Color.Transparent;
            travel_title2.TextAlign = ContentAlignment.TopCenter;
            travel_title2.AutoSize = false;
            travel_title2.Width = layoutTableTravelNext.Width;
        }
        private void TravelProperties(Label travel)
        {
            travel.Text = "- Dolores - 10:00hs";
            travel.Font = new Font("Arial", 14, FontStyle.Regular);
            travel.Size = new Size(200, 30);
            //travel.Margin = new Padding(0, 10, 0, 0);
        }


        //PayTableTravel
        private void TablePay()
        {
            TablePayProperties();
            LayoutTablePayProperties();
            TravelPayTitleProperties();
            AddTitleToTablePay();
            AddPendingPayments();
            LayoutPayProperties();
        }
        private void TablePayProperties()
        {
            table_pay.Size = new Size(320, 440);
            int x = this.Width + table_travel.Width;
            table_pay.Location = new Point(x, 180);
            table_pay.BackColor = System.Drawing.Color.FromArgb(200, Color.Black);
            table_pay.BorderStyle = BorderStyle.FixedSingle;
        }
        private void LayoutTablePayProperties()
        {
            layoutTablePay.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutTablePay.AutoSize = true;
            layoutTablePay.AutoScroll = true;
            layoutTablePay.BackColor = Color.Transparent;
            layoutTablePay.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutTablePay.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutTablePay.WrapContents = true; // Evita que los elementos pasen a otra línea
        }
        private void LayoutPayProperties()
        {
            layoutPay.Padding = new Padding(0);
            layoutPay.Margin = new Padding(0);

            table_pay.Resize += (s, e) =>
            {
                layoutTablePay.Location = new Point((layoutTablePay.Width - layoutPay.Width) / 2, 10);
            };
            layoutPay.Anchor = AnchorStyles.None; // Evita que se expanda con el contenedor
            layoutPay.Size = new Size(layoutTablePay.Width, 420);
            layoutPay.AutoScroll = true;
            layoutPay.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutPay.BackColor = Color.Transparent;
            layoutPay.FlowDirection = FlowDirection.TopDown; // Crece hacia abajo
            layoutPay.WrapContents = true;//Evita que los elementos pasen a otra línea
        }
        private void TravelPayTitleProperties()
        {
            pay_title.Text = "pagos pendientes:";
            pay_title.Font = new Font("Arial", 14, FontStyle.Regular);
            pay_title.Text = pay_title.Text.ToUpper();
            pay_title.ForeColor = System.Drawing.Color.FromArgb(218, 218, 28);
            pay_title.BackColor = Color.Transparent;
            pay_title.AutoSize = false;
            pay_title.TextAlign = ContentAlignment.TopCenter;
            pay_title.Width = table_pay.Width;  // Ocupa todo el ancho del contenedor
            pay_title.Margin = new Padding(0, 20, 0, 0);
        }
        private void PayProperties(CheckedListBox pay)
        {
            pay.Font = new Font("Arial", 14, FontStyle.Regular);
            pay.AutoSize = true;
            pay.Margin = new Padding(60, 10, 0, 0);
            pay.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            pay.BackColor = Color.Black;
            pay.BorderStyle = BorderStyle.None;
        }

        private void AddTitleToTablePay()
        {
            table_pay.Controls.Add(layoutTablePay);
            layoutTablePay.Controls.Add(pay_title);
            layoutTablePay.Controls.Add(layoutPay);

        }
        private void AddTablesToControls()
        {
            this.Controls.Add(table_travel);
            this.Controls.Add(table_pay);
        }

    }
}
