namespace TaskWinForm
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgView = new System.Windows.Forms.DataGridView();
            this.txtGoto = new System.Windows.Forms.TextBox();
            this.BtnGoto = new System.Windows.Forms.Button();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.Label();
            this.LBTotalResults = new System.Windows.Forms.Label();
            this.LBCurrentPage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBTotalPages = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBWait = new System.Windows.Forms.Label();
            this.PanelGridTools = new System.Windows.Forms.Panel();
            this.BtnFillDBFromApi = new System.Windows.Forms.Button();
            this.BtnClearDB = new System.Windows.Forms.Button();
            this.BtnFillGDApi = new System.Windows.Forms.Button();
            this.BtnFillDGDB = new System.Windows.Forms.Button();
            this.BtnAddToDatabse = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.BtnAddToServer = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.PanelGridTools.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AllowUserToResizeColumns = false;
            this.dgView.AllowUserToResizeRows = false;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(12, 112);
            this.dgView.Name = "dgView";
            this.dgView.Size = new System.Drawing.Size(622, 317);
            this.dgView.TabIndex = 1;
            // 
            // txtGoto
            // 
            this.txtGoto.Location = new System.Drawing.Point(570, 12);
            this.txtGoto.Name = "txtGoto";
            this.txtGoto.Size = new System.Drawing.Size(56, 20);
            this.txtGoto.TabIndex = 3;
            // 
            // BtnGoto
            // 
            this.BtnGoto.Location = new System.Drawing.Point(489, 10);
            this.BtnGoto.Name = "BtnGoto";
            this.BtnGoto.Size = new System.Drawing.Size(75, 23);
            this.BtnGoto.TabIndex = 4;
            this.BtnGoto.Text = "Go to page";
            this.BtnGoto.UseVisualStyleBackColor = true;
            // 
            // BtnPrev
            // 
            this.BtnPrev.Location = new System.Drawing.Point(4, 12);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(75, 23);
            this.BtnPrev.TabIndex = 5;
            this.BtnPrev.Text = "Prev";
            this.BtnPrev.UseVisualStyleBackColor = true;
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(85, 12);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(75, 23);
            this.BtnNext.TabIndex = 6;
            this.BtnNext.Text = "Next";
            this.BtnNext.UseVisualStyleBackColor = true;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(308, 18);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(75, 13);
            this.lb.TabIndex = 7;
            this.lb.Text = "Total Results :";
            // 
            // LBTotalResults
            // 
            this.LBTotalResults.AutoSize = true;
            this.LBTotalResults.Location = new System.Drawing.Point(383, 18);
            this.LBTotalResults.Name = "LBTotalResults";
            this.LBTotalResults.Size = new System.Drawing.Size(13, 13);
            this.LBTotalResults.TabIndex = 8;
            this.LBTotalResults.Text = "0";
            // 
            // LBCurrentPage
            // 
            this.LBCurrentPage.AutoSize = true;
            this.LBCurrentPage.Location = new System.Drawing.Point(241, 18);
            this.LBCurrentPage.Name = "LBCurrentPage";
            this.LBCurrentPage.Size = new System.Drawing.Size(13, 13);
            this.LBCurrentPage.TabIndex = 10;
            this.LBCurrentPage.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Current Page :";
            // 
            // LBTotalPages
            // 
            this.LBTotalPages.AutoSize = true;
            this.LBTotalPages.Location = new System.Drawing.Point(241, 44);
            this.LBTotalPages.Name = "LBTotalPages";
            this.LBTotalPages.Size = new System.Drawing.Size(13, 13);
            this.LBTotalPages.TabIndex = 12;
            this.LBTotalPages.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Total Pages :";
            // 
            // LBWait
            // 
            this.LBWait.AutoSize = true;
            this.LBWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.LBWait.Location = new System.Drawing.Point(12, 85);
            this.LBWait.Name = "LBWait";
            this.LBWait.Size = new System.Drawing.Size(0, 24);
            this.LBWait.TabIndex = 13;
            // 
            // PanelGridTools
            // 
            this.PanelGridTools.Controls.Add(this.BtnPrev);
            this.PanelGridTools.Controls.Add(this.txtGoto);
            this.PanelGridTools.Controls.Add(this.LBTotalPages);
            this.PanelGridTools.Controls.Add(this.BtnGoto);
            this.PanelGridTools.Controls.Add(this.label4);
            this.PanelGridTools.Controls.Add(this.BtnNext);
            this.PanelGridTools.Controls.Add(this.LBCurrentPage);
            this.PanelGridTools.Controls.Add(this.lb);
            this.PanelGridTools.Controls.Add(this.label2);
            this.PanelGridTools.Controls.Add(this.LBTotalResults);
            this.PanelGridTools.Location = new System.Drawing.Point(12, 435);
            this.PanelGridTools.Name = "PanelGridTools";
            this.PanelGridTools.Size = new System.Drawing.Size(635, 88);
            this.PanelGridTools.TabIndex = 14;
            // 
            // BtnFillDBFromApi
            // 
            this.BtnFillDBFromApi.Location = new System.Drawing.Point(640, 112);
            this.BtnFillDBFromApi.Name = "BtnFillDBFromApi";
            this.BtnFillDBFromApi.Size = new System.Drawing.Size(195, 23);
            this.BtnFillDBFromApi.TabIndex = 15;
            this.BtnFillDBFromApi.Text = "Fill database from api";
            this.BtnFillDBFromApi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFillDBFromApi.UseVisualStyleBackColor = true;
            // 
            // BtnClearDB
            // 
            this.BtnClearDB.Location = new System.Drawing.Point(640, 141);
            this.BtnClearDB.Name = "BtnClearDB";
            this.BtnClearDB.Size = new System.Drawing.Size(195, 23);
            this.BtnClearDB.TabIndex = 16;
            this.BtnClearDB.Text = "Clear database";
            this.BtnClearDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClearDB.UseVisualStyleBackColor = true;
            // 
            // BtnFillGDApi
            // 
            this.BtnFillGDApi.Location = new System.Drawing.Point(640, 170);
            this.BtnFillGDApi.Name = "BtnFillGDApi";
            this.BtnFillGDApi.Size = new System.Drawing.Size(195, 23);
            this.BtnFillGDApi.TabIndex = 17;
            this.BtnFillGDApi.Text = "Fill gridview from api";
            this.BtnFillGDApi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFillGDApi.UseVisualStyleBackColor = true;
            // 
            // BtnFillDGDB
            // 
            this.BtnFillDGDB.Location = new System.Drawing.Point(640, 199);
            this.BtnFillDGDB.Name = "BtnFillDGDB";
            this.BtnFillDGDB.Size = new System.Drawing.Size(195, 23);
            this.BtnFillDGDB.TabIndex = 18;
            this.BtnFillDGDB.Text = "Fill gridview from database";
            this.BtnFillDGDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFillDGDB.UseVisualStyleBackColor = true;
            // 
            // BtnAddToDatabse
            // 
            this.BtnAddToDatabse.Location = new System.Drawing.Point(721, 361);
            this.BtnAddToDatabse.Name = "BtnAddToDatabse";
            this.BtnAddToDatabse.Size = new System.Drawing.Size(123, 23);
            this.BtnAddToDatabse.TabIndex = 19;
            this.BtnAddToDatabse.Text = "Add to local databse";
            this.BtnAddToDatabse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddToDatabse.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(721, 280);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(123, 20);
            this.txtName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(640, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Comment :";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(721, 306);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(123, 49);
            this.txtComment.TabIndex = 22;
            // 
            // BtnAddToServer
            // 
            this.BtnAddToServer.Location = new System.Drawing.Point(721, 390);
            this.BtnAddToServer.Name = "BtnAddToServer";
            this.BtnAddToServer.Size = new System.Drawing.Size(123, 23);
            this.BtnAddToServer.TabIndex = 24;
            this.BtnAddToServer.Text = "Add to server databse";
            this.BtnAddToServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddToServer.UseVisualStyleBackColor = true;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.LightGray;
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.label7);
            this.panelSearch.Controls.Add(this.BtnSearch);
            this.panelSearch.Location = new System.Drawing.Point(16, 12);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(618, 68);
            this.panelSearch.TabIndex = 25;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(94, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(156, 20);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Search word";
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.SkyBlue;
            this.BtnSearch.Location = new System.Drawing.Point(256, 15);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(68, 23);
            this.BtnSearch.TabIndex = 20;
            this.BtnSearch.Text = "Filter data";
            this.BtnSearch.UseVisualStyleBackColor = false;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 552);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.BtnAddToServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.BtnAddToDatabse);
            this.Controls.Add(this.BtnFillDGDB);
            this.Controls.Add(this.BtnFillGDApi);
            this.Controls.Add(this.BtnClearDB);
            this.Controls.Add(this.BtnFillDBFromApi);
            this.Controls.Add(this.PanelGridTools);
            this.Controls.Add(this.LBWait);
            this.Controls.Add(this.dgView);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainFrm";
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.PanelGridTools.ResumeLayout(false);
            this.PanelGridTools.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtGoto;
        private System.Windows.Forms.Button BtnGoto;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Label LBTotalResults;
        private System.Windows.Forms.Label LBCurrentPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBTotalPages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LBWait;
        public System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Panel PanelGridTools;
        private System.Windows.Forms.Button BtnFillDBFromApi;
        private System.Windows.Forms.Button BtnClearDB;
        private System.Windows.Forms.Button BtnFillGDApi;
        private System.Windows.Forms.Button BtnFillDGDB;
        private System.Windows.Forms.Button BtnAddToDatabse;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button BtnAddToServer;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label7;
    }
}

