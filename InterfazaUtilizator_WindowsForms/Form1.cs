﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazaUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        static Form1 _obj;

        public static Form1 Instance
        {
            get 
            {
                if(_obj == null)
                {
                    _obj = new Form1();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return pnlContinut; }
            set { pnlContinut = value; }
        }

        public Button ButonAcasa
        {
            get { return btnAcasa; }
            set { btnAcasa = value; }
        }
        //Pentru a putea muta fereastra
        int mov;
        int movX;
        int movY;

        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region PermitereMutareFereastra
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov==1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        #endregion

        private void btnGit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Co-mi/InchirieriAuto"); //link catre pagina de git
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAcasa.Enabled = false;
            _obj = this;

            PaginaAcasa pa = new PaginaAcasa();
            pa.Dock = DockStyle.Fill;
            pnlContinut.Controls.Add(pa);
        }

        private void btnAcasa_Click(object sender, EventArgs e)
        {
            pnlContinut.Controls["PaginaAcasa"].BringToFront();
            btnAcasa.Enabled = false;
            btnClienti.Enabled = true;
        }

        private void btnClienti_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("PaginaClienti"))
            {
                PaginaClienti pc = new PaginaClienti();
                pc.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(pc);
            }
            Form1.Instance.PnlContainer.Controls["PaginaClienti"].BringToFront();
            Form1.Instance.ButonAcasa.Enabled = true;
            btnClienti.Enabled = false;
        }
    }
}