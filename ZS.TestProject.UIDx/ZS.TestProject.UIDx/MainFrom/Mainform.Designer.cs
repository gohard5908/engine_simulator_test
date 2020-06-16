namespace ZS.TestProject.UIDx
{
    partial class Mainform
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popMenuCloseCurrent = new DevExpress.XtraBars.BarButtonItem();
            this.popMenuCloseAll = new DevExpress.XtraBars.BarButtonItem();
            this.popMenuCloseOther = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnTestPage = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.testPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.popupMenu1;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.popMenuCloseCurrent,
            this.popMenuCloseAll,
            this.popMenuCloseOther,
            this.btnTestPage});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl.MaxItemId = 15;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage4});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl.Size = new System.Drawing.Size(1149, 164);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            // 
            // popupMenu1
            // 
            this.popupMenu1.ItemLinks.Add(this.popMenuCloseCurrent);
            this.popupMenu1.ItemLinks.Add(this.popMenuCloseAll);
            this.popupMenu1.ItemLinks.Add(this.popMenuCloseOther);
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl;
            // 
            // popMenuCloseCurrent
            // 
            this.popMenuCloseCurrent.Caption = "关闭当前";
            this.popMenuCloseCurrent.Id = 7;
            this.popMenuCloseCurrent.Name = "popMenuCloseCurrent";
            this.popMenuCloseCurrent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.popMenuCloseCurrent_ItemClick);
            // 
            // popMenuCloseAll
            // 
            this.popMenuCloseAll.Caption = "关闭所有";
            this.popMenuCloseAll.Id = 8;
            this.popMenuCloseAll.Name = "popMenuCloseAll";
            this.popMenuCloseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.popMenuCloseAll_ItemClick);
            // 
            // popMenuCloseOther
            // 
            this.popMenuCloseOther.Caption = "关闭其他窗口";
            this.popMenuCloseOther.Id = 9;
            this.popMenuCloseOther.Name = "popMenuCloseOther";
            this.popMenuCloseOther.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.popMenuCloseOther_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "数据管理";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "稳态仿真";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.ActAsDropDown = true;
            this.barButtonItem3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem3.Caption = "动态仿真";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "退化仿真";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // btnTestPage
            // 
            this.btnTestPage.Caption = "测试页";
            this.btnTestPage.Id = 11;
            this.btnTestPage.Name = "btnTestPage";
            this.btnTestPage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTestPage_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "软件功能";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.testPage});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "ribbonPage4";
            // 
            // testPage
            // 
            this.testPage.ItemLinks.Add(this.btnTestPage);
            this.testPage.Name = "testPage";
            this.testPage.Text = "testPage";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 857);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1149, 33);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Far;
            this.xtraTabbedMdiManager1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xtraTabbedMdiManager1_MouseDown);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 890);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Mainform";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Mainform";
            this.Load += new System.EventHandler(this.Mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;

        private DevExpress.XtraBars.BarButtonItem popMenuCloseCurrent;
        private DevExpress.XtraBars.BarButtonItem popMenuCloseAll;
        private DevExpress.XtraBars.BarButtonItem popMenuCloseOther;
        private DevExpress.XtraBars.BarButtonItem btnTestPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup testPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
    }
}