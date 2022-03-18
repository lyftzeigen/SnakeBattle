using System.ComponentModel;
using System.Windows.Forms;

namespace Launcher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.btnLaunch = new System.Windows.Forms.Button();
            this.grBoxWorldSize = new System.Windows.Forms.GroupBox();
            this.lblBlockSize = new System.Windows.Forms.Label();
            this.lblFieldHeight = new System.Windows.Forms.Label();
            this.lblFieldWidth = new System.Windows.Forms.Label();
            this.lblResolution = new System.Windows.Forms.Label();
            this.txtBlockSize = new System.Windows.Forms.TextBox();
            this.txtFieldHeight = new System.Windows.Forms.TextBox();
            this.txtFieldWidth = new System.Windows.Forms.TextBox();
            this.grBoxTerrain = new System.Windows.Forms.GroupBox();
            this.txtTerrainPower = new System.Windows.Forms.TextBox();
            this.lblTerrainPower = new System.Windows.Forms.Label();
            this.lblTerrainCount = new System.Windows.Forms.Label();
            this.txtTerrainDomainNumber = new System.Windows.Forms.TextBox();
            this.grBoxFood = new System.Windows.Forms.GroupBox();
            this.lblFoodCount = new System.Windows.Forms.Label();
            this.txtFoodCount = new System.Windows.Forms.TextBox();
            this.grBoxRenderUpdate = new System.Windows.Forms.GroupBox();
            this.lblUpdateDelay = new System.Windows.Forms.Label();
            this.txtUpdateDalay = new System.Windows.Forms.TextBox();
            this.lblRenderDelay = new System.Windows.Forms.Label();
            this.txtRenderDelay = new System.Windows.Forms.TextBox();
            this.grBoxWorldSize.SuspendLayout();
            this.grBoxTerrain.SuspendLayout();
            this.grBoxFood.SuspendLayout();
            this.grBoxRenderUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaunch.Location = new System.Drawing.Point(12, 378);
            this.btnLaunch.Margin = new System.Windows.Forms.Padding(4);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(340, 30);
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // grBoxWorldSize
            // 
            this.grBoxWorldSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxWorldSize.Controls.Add(this.lblBlockSize);
            this.grBoxWorldSize.Controls.Add(this.lblFieldHeight);
            this.grBoxWorldSize.Controls.Add(this.lblFieldWidth);
            this.grBoxWorldSize.Controls.Add(this.lblResolution);
            this.grBoxWorldSize.Controls.Add(this.txtBlockSize);
            this.grBoxWorldSize.Controls.Add(this.txtFieldHeight);
            this.grBoxWorldSize.Controls.Add(this.txtFieldWidth);
            this.grBoxWorldSize.Location = new System.Drawing.Point(12, 12);
            this.grBoxWorldSize.Name = "grBoxWorldSize";
            this.grBoxWorldSize.Size = new System.Drawing.Size(340, 87);
            this.grBoxWorldSize.TabIndex = 1;
            this.grBoxWorldSize.TabStop = false;
            this.grBoxWorldSize.Text = "Field size";
            // 
            // lblBlockSize
            // 
            this.lblBlockSize.AutoSize = true;
            this.lblBlockSize.Location = new System.Drawing.Point(209, 55);
            this.lblBlockSize.Name = "lblBlockSize";
            this.lblBlockSize.Size = new System.Drawing.Size(72, 16);
            this.lblBlockSize.TabIndex = 9;
            this.lblBlockSize.Text = "Block size:";
            // 
            // lblFieldHeight
            // 
            this.lblFieldHeight.AutoSize = true;
            this.lblFieldHeight.Location = new System.Drawing.Point(105, 55);
            this.lblFieldHeight.Name = "lblFieldHeight";
            this.lblFieldHeight.Size = new System.Drawing.Size(50, 16);
            this.lblFieldHeight.TabIndex = 8;
            this.lblFieldHeight.Text = "Height:";
            // 
            // lblFieldWidth
            // 
            this.lblFieldWidth.AutoSize = true;
            this.lblFieldWidth.Location = new System.Drawing.Point(6, 55);
            this.lblFieldWidth.Name = "lblFieldWidth";
            this.lblFieldWidth.Size = new System.Drawing.Size(45, 16);
            this.lblFieldWidth.TabIndex = 5;
            this.lblFieldWidth.Text = "Width:";
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(95, 22);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(140, 16);
            this.lblResolution.TabIndex = 7;
            this.lblResolution.Text = "Resolution: 1920x1080";
            // 
            // txtBlockSize
            // 
            this.txtBlockSize.Location = new System.Drawing.Point(289, 52);
            this.txtBlockSize.Margin = new System.Windows.Forms.Padding(5);
            this.txtBlockSize.Name = "txtBlockSize";
            this.txtBlockSize.Size = new System.Drawing.Size(38, 22);
            this.txtBlockSize.TabIndex = 4;
            this.txtBlockSize.Text = "5";
            this.txtBlockSize.TextChanged += new System.EventHandler(this.txtFieldBlockSize_OnChange);
            this.txtBlockSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFields_KeyPress);
            // 
            // txtFieldHeight
            // 
            this.txtFieldHeight.Location = new System.Drawing.Point(163, 52);
            this.txtFieldHeight.Margin = new System.Windows.Forms.Padding(5);
            this.txtFieldHeight.Name = "txtFieldHeight";
            this.txtFieldHeight.Size = new System.Drawing.Size(38, 22);
            this.txtFieldHeight.TabIndex = 1;
            this.txtFieldHeight.Text = "100";
            this.txtFieldHeight.TextChanged += new System.EventHandler(this.txtFieldWidthOrHeight_OnChange);
            this.txtFieldHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFields_KeyPress);
            // 
            // txtFieldWidth
            // 
            this.txtFieldWidth.Location = new System.Drawing.Point(59, 52);
            this.txtFieldWidth.Margin = new System.Windows.Forms.Padding(5);
            this.txtFieldWidth.Name = "txtFieldWidth";
            this.txtFieldWidth.Size = new System.Drawing.Size(38, 22);
            this.txtFieldWidth.TabIndex = 0;
            this.txtFieldWidth.Text = "100";
            this.txtFieldWidth.TextChanged += new System.EventHandler(this.txtFieldWidthOrHeight_OnChange);
            this.txtFieldWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFields_KeyPress);
            // 
            // grBoxTerrain
            // 
            this.grBoxTerrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxTerrain.Controls.Add(this.txtTerrainPower);
            this.grBoxTerrain.Controls.Add(this.lblTerrainPower);
            this.grBoxTerrain.Controls.Add(this.lblTerrainCount);
            this.grBoxTerrain.Controls.Add(this.txtTerrainDomainNumber);
            this.grBoxTerrain.Location = new System.Drawing.Point(12, 105);
            this.grBoxTerrain.Name = "grBoxTerrain";
            this.grBoxTerrain.Size = new System.Drawing.Size(340, 88);
            this.grBoxTerrain.TabIndex = 2;
            this.grBoxTerrain.TabStop = false;
            this.grBoxTerrain.Text = "Terrain";
            // 
            // txtTerrainPower
            // 
            this.txtTerrainPower.Location = new System.Drawing.Point(120, 55);
            this.txtTerrainPower.Margin = new System.Windows.Forms.Padding(5);
            this.txtTerrainPower.Name = "txtTerrainPower";
            this.txtTerrainPower.Size = new System.Drawing.Size(38, 22);
            this.txtTerrainPower.TabIndex = 4;
            this.txtTerrainPower.Text = "35";
            this.txtTerrainPower.TextChanged += new System.EventHandler(this.txtResolutionFields_TextChanged);
            this.txtTerrainPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFields_KeyPress);
            // 
            // lblTerrainPower
            // 
            this.lblTerrainPower.AutoSize = true;
            this.lblTerrainPower.Location = new System.Drawing.Point(6, 58);
            this.lblTerrainPower.Name = "lblTerrainPower";
            this.lblTerrainPower.Size = new System.Drawing.Size(98, 16);
            this.lblTerrainPower.TabIndex = 3;
            this.lblTerrainPower.Text = "Domain power:";
            // 
            // lblTerrainCount
            // 
            this.lblTerrainCount.AutoSize = true;
            this.lblTerrainCount.Location = new System.Drawing.Point(6, 26);
            this.lblTerrainCount.Name = "lblTerrainCount";
            this.lblTerrainCount.Size = new System.Drawing.Size(106, 16);
            this.lblTerrainCount.TabIndex = 2;
            this.lblTerrainCount.Text = "Domain number:";
            // 
            // txtTerrainDomainNumber
            // 
            this.txtTerrainDomainNumber.Location = new System.Drawing.Point(120, 23);
            this.txtTerrainDomainNumber.Margin = new System.Windows.Forms.Padding(5);
            this.txtTerrainDomainNumber.Name = "txtTerrainDomainNumber";
            this.txtTerrainDomainNumber.Size = new System.Drawing.Size(38, 22);
            this.txtTerrainDomainNumber.TabIndex = 0;
            this.txtTerrainDomainNumber.Text = "30";
            this.txtTerrainDomainNumber.TextChanged += new System.EventHandler(this.txtResolutionFields_TextChanged);
            this.txtTerrainDomainNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFields_KeyPress);
            // 
            // grBoxFood
            // 
            this.grBoxFood.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxFood.Controls.Add(this.lblFoodCount);
            this.grBoxFood.Controls.Add(this.txtFoodCount);
            this.grBoxFood.Location = new System.Drawing.Point(12, 200);
            this.grBoxFood.Name = "grBoxFood";
            this.grBoxFood.Size = new System.Drawing.Size(340, 57);
            this.grBoxFood.TabIndex = 3;
            this.grBoxFood.TabStop = false;
            this.grBoxFood.Text = "Food";
            // 
            // lblFoodCount
            // 
            this.lblFoodCount.AutoSize = true;
            this.lblFoodCount.Location = new System.Drawing.Point(6, 26);
            this.lblFoodCount.Name = "lblFoodCount";
            this.lblFoodCount.Size = new System.Drawing.Size(78, 16);
            this.lblFoodCount.TabIndex = 2;
            this.lblFoodCount.Text = "Food count:";
            // 
            // txtFoodCount
            // 
            this.txtFoodCount.Location = new System.Drawing.Point(120, 23);
            this.txtFoodCount.Margin = new System.Windows.Forms.Padding(5);
            this.txtFoodCount.Name = "txtFoodCount";
            this.txtFoodCount.Size = new System.Drawing.Size(38, 22);
            this.txtFoodCount.TabIndex = 0;
            this.txtFoodCount.Text = "25";
            this.txtFoodCount.TextChanged += new System.EventHandler(this.txtResolutionFields_TextChanged);
            this.txtFoodCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFields_KeyPress);
            // 
            // grBoxRenderUpdate
            // 
            this.grBoxRenderUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxRenderUpdate.Controls.Add(this.lblUpdateDelay);
            this.grBoxRenderUpdate.Controls.Add(this.txtUpdateDalay);
            this.grBoxRenderUpdate.Controls.Add(this.lblRenderDelay);
            this.grBoxRenderUpdate.Controls.Add(this.txtRenderDelay);
            this.grBoxRenderUpdate.Location = new System.Drawing.Point(12, 263);
            this.grBoxRenderUpdate.Name = "grBoxRenderUpdate";
            this.grBoxRenderUpdate.Size = new System.Drawing.Size(340, 88);
            this.grBoxRenderUpdate.TabIndex = 4;
            this.grBoxRenderUpdate.TabStop = false;
            this.grBoxRenderUpdate.Text = "Render and Update";
            // 
            // lblUpdateDelay
            // 
            this.lblUpdateDelay.AutoSize = true;
            this.lblUpdateDelay.Location = new System.Drawing.Point(6, 58);
            this.lblUpdateDelay.Name = "lblUpdateDelay";
            this.lblUpdateDelay.Size = new System.Drawing.Size(93, 16);
            this.lblUpdateDelay.TabIndex = 5;
            this.lblUpdateDelay.Text = "Update delay:";
            // 
            // txtUpdateDalay
            // 
            this.txtUpdateDalay.Location = new System.Drawing.Point(120, 55);
            this.txtUpdateDalay.Margin = new System.Windows.Forms.Padding(5);
            this.txtUpdateDalay.Name = "txtUpdateDalay";
            this.txtUpdateDalay.Size = new System.Drawing.Size(38, 22);
            this.txtUpdateDalay.TabIndex = 4;
            this.txtUpdateDalay.Text = "100";
            this.txtUpdateDalay.TextChanged += new System.EventHandler(this.txtResolutionFields_TextChanged);
            this.txtUpdateDalay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFields_KeyPress);
            // 
            // lblRenderDelay
            // 
            this.lblRenderDelay.AutoSize = true;
            this.lblRenderDelay.Location = new System.Drawing.Point(6, 26);
            this.lblRenderDelay.Name = "lblRenderDelay";
            this.lblRenderDelay.Size = new System.Drawing.Size(93, 16);
            this.lblRenderDelay.TabIndex = 2;
            this.lblRenderDelay.Text = "Render delay:";
            // 
            // txtRenderDelay
            // 
            this.txtRenderDelay.Location = new System.Drawing.Point(120, 23);
            this.txtRenderDelay.Margin = new System.Windows.Forms.Padding(5);
            this.txtRenderDelay.Name = "txtRenderDelay";
            this.txtRenderDelay.Size = new System.Drawing.Size(38, 22);
            this.txtRenderDelay.TabIndex = 0;
            this.txtRenderDelay.Text = "33";
            this.txtRenderDelay.TextChanged += new System.EventHandler(this.txtResolutionFields_TextChanged);
            this.txtRenderDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFields_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 421);
            this.Controls.Add(this.grBoxRenderUpdate);
            this.Controls.Add(this.grBoxFood);
            this.Controls.Add(this.grBoxTerrain);
            this.Controls.Add(this.grBoxWorldSize);
            this.Controls.Add(this.btnLaunch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " SnakeBattle Launcher";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.grBoxWorldSize.ResumeLayout(false);
            this.grBoxWorldSize.PerformLayout();
            this.grBoxTerrain.ResumeLayout(false);
            this.grBoxTerrain.PerformLayout();
            this.grBoxFood.ResumeLayout(false);
            this.grBoxFood.PerformLayout();
            this.grBoxRenderUpdate.ResumeLayout(false);
            this.grBoxRenderUpdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnLaunch;
        private GroupBox grBoxWorldSize;
        private TextBox txtBlockSize;
        private TextBox txtFieldHeight;
        private TextBox txtFieldWidth;
        private GroupBox grBoxTerrain;
        private Label lblTerrainCount;
        private TextBox txtTerrainDomainNumber;
        private TextBox txtTerrainPower;
        private Label lblTerrainPower;
        private Label lblResolution;
        private Label lblFieldHeight;
        private Label lblFieldWidth;
        private Label lblBlockSize;
        private GroupBox grBoxFood;
        private Label lblFoodCount;
        private TextBox txtFoodCount;
        private GroupBox grBoxRenderUpdate;
        private Label lblRenderDelay;
        private TextBox txtRenderDelay;
        private Label lblUpdateDelay;
        private TextBox txtUpdateDalay;
    }
}

