using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskWinForm.Controller;
using TaskWinForm.Model;

namespace TaskWinForm
{
    public partial class MainFrm : Form
    {
        public MainCtr mainCtr;
        public int _current_page_grid = 0;
        public int _page_size_grid = 10;
        public int _page_size_total_grid = 0;


        #region Init
        public MainFrm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            mainCtr = new MainCtr();

            FillGrid();

            #region events
            BtnSearch.Click += BtnSearch_Click;
            BtnNext.Click += BtnNext_Click;
            BtnPrev.Click += BtnPrev_Click;
            BtnGoto.Click += BtnGoto_Click;
            
            BtnAddToDatabse.Click += BtnAddToDatabse_Click;
            BtnAddToServer.Click += BtnAddToServer_Click;
            BtnClearDB.Click += BtnClearDB_Click;
            BtnFillDBFromApi.Click += BtnFillDBFromApi_Click;
            BtnFillGDApi.Click += BtnFillGDApi_Click;
            BtnFillDGDB.Click += BtnFillDGDB_Click;
            #endregion
        }

        #endregion

        public void FillGrid(string search="",string dateFrom="",string dateTo="")
        {
            PanelGridTools.Visible = true;
            panelSearch.Visible = true;
            bool wait= mainCtr.SelectData(_current_page_grid, _page_size_grid, search, dateFrom, dateTo);

            if(wait==false)
            {
                MessageBox.Show("Waiting for import data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mainCtr._CommandState)
            {
                dgView.DataSource = null;
                dgView.DataSource = mainCtr._CommandData;
                dgView.Update();
                dgView.Refresh();

                _page_size_total_grid = mainCtr._TotalDataPage;
                LBTotalPages.Text = _page_size_total_grid.ToString();
                LBTotalResults.Text = mainCtr._TotalData.ToString();
                LBCurrentPage.Text = (_current_page_grid + 1).ToString();
            }
        }

        public void FillGridFrmApi(List<Comments> list)
        {
            PanelGridTools.Visible = false;
            panelSearch.Visible = false;
            dgView.DataSource = null;
                dgView.DataSource = list;
                dgView.Update();
                dgView.Refresh();
        }

        #region View Events

        #region Click

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
         
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if(_current_page_grid>0)
            {
                _current_page_grid--;
                FillGrid();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if ((_current_page_grid+1) < _page_size_total_grid)
            {
                _current_page_grid++;
                FillGrid();
            }          
        }

        private void BtnGoto_Click(object sender, EventArgs e)
        {
            int goto_page = _current_page_grid;
            try
            {
                 goto_page = int.Parse(txtGoto.Text);
                goto_page--;
            }
            catch
            {
                goto_page = _current_page_grid;
                txtGoto.Text = (_current_page_grid+1).ToString();
            }

            if(goto_page<0 )
            {
                goto_page = 0;
                txtGoto.Text = "1";
            }

            if ( (goto_page + 1) > _page_size_total_grid)
            {
                goto_page = _page_size_total_grid-1;
                txtGoto.Text = _page_size_total_grid.ToString();
            }

            _current_page_grid = goto_page;

            FillGrid();

        }

        private void BtnFillDGDB_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void BtnFillGDApi_Click(object sender, EventArgs e)
        {
            mainCtr.GetAsync(LBWait, this);
        }

        private void BtnFillDBFromApi_Click(object sender, EventArgs e)
        {
            string message = mainCtr.ClearData();
            if (mainCtr._CommandState)
            {
                mainCtr.GetAsync(LBWait, this,false,true);
            }
        }

        private void BtnClearDB_Click(object sender, EventArgs e)
        {
            string message = mainCtr.ClearData();

            if (mainCtr._CommandState)
            {
                MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            FillGrid();
        }

        private void BtnAddToDatabse_Click(object sender, EventArgs e)
        {
            string message = mainCtr.InsertData(LBWait, this, txtName.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd"), txtComment.Text.Trim());

            if (mainCtr._CommandState)
            {
                MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            FillGrid();
        }

        private void BtnAddToServer_Click(object sender, EventArgs e)
        {
            string message = mainCtr.InsertData(LBWait, this, txtName.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd"), txtComment.Text.Trim(),true);
        }

        #endregion

        #endregion


        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                FillGrid(txtSearch.Text.Trim());
            }
        }
    }
}
