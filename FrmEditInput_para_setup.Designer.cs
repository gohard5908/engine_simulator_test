namespace ZS.TestProject.UI
{
    partial class FrmEditInput_para_setup
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();                

            this.txtAltitude = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
             this.txtDeltaTamb = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
             this.txtMachNumb = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
             
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();

            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();            
            ((System.ComponentModel.ISupportInitialize)(this.txtAltitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txtDeltaTamb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txtMachNumb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
             
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(438, 392);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(537, 392);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(351, 392);
            // 
            // layoutControl1
            //             
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(605, 363);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";

            this.layoutControl1.Controls.Add(this.txtAltitude);
             this.layoutControl1.Controls.Add(this.txtDeltaTamb);
             this.layoutControl1.Controls.Add(this.txtMachNumb);
 
            this.txtAltitude.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAltitude.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtAltitude.Location = new System.Drawing.Point(112, 12);
            this.txtAltitude.Name = "txtAltitude";
            this.txtAltitude.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtAltitude.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtAltitude.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtAltitude.Size = new System.Drawing.Size(120, 20);
            this.txtAltitude.StyleController = this.layoutControl1;
            this.txtAltitude.TabIndex = 1;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtAltitude;
            this.layoutControlItem1.CustomizationFormText = "";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem1.Text = "";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(96, 14);  

             this.txtDeltaTamb.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDeltaTamb.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtDeltaTamb.Location = new System.Drawing.Point(112, 36);
            this.txtDeltaTamb.Name = "txtDeltaTamb";
            this.txtDeltaTamb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDeltaTamb.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDeltaTamb.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDeltaTamb.Size = new System.Drawing.Size(120, 20);
            this.txtDeltaTamb.StyleController = this.layoutControl1;
            this.txtDeltaTamb.TabIndex = 2;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDeltaTamb;
            this.layoutControlItem2.CustomizationFormText = "";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem2.Text = "";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(96, 14);  

             this.txtMachNumb.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMachNumb.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtMachNumb.Location = new System.Drawing.Point(112, 60);
            this.txtMachNumb.Name = "txtMachNumb";
            this.txtMachNumb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtMachNumb.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtMachNumb.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtMachNumb.Size = new System.Drawing.Size(120, 20);
            this.txtMachNumb.StyleController = this.layoutControl1;
            this.txtMachNumb.TabIndex = 3;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtMachNumb;
            this.layoutControlItem3.CustomizationFormText = "";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem3.Text = "";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 14);  

 
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
	        this.layoutControlItem1
	 	       ,this.layoutControlItem2
	 	       ,this.layoutControlItem3
	        });
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(605, 363);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;          

            // 
            // FrmEditInput_para_setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 427);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmEditInput_para_setup";
            this.Text = "";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.txtAltitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txtDeltaTamb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txtMachNumb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();            
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;

        private DevExpress.XtraEditors.SpinEdit txtAltitude;
          private DevExpress.XtraEditors.SpinEdit txtDeltaTamb;
          private DevExpress.XtraEditors.SpinEdit txtMachNumb;
  
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
 
    }
}