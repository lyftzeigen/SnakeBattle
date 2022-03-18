using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Launcher
{
    public partial class MainForm : Form
    {
        private BattlefieldForm battlefield;

        public MainForm()
        {
            InitializeComponent();
            txtResilution_Calculate();
        }

        private void txtFields_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtResilution_Calculate()
        {
            Settings.FieldWidth = int.Parse(txtFieldWidth.Text);
            Settings.FieldHeight = int.Parse(txtFieldHeight.Text);
            Settings.BlokSize = int.Parse(txtBlockSize.Text);

            var width = int.Parse(txtFieldWidth.Text) * (int.Parse(txtBlockSize.Text) + 2);
            var height = int.Parse(txtFieldHeight.Text) * (int.Parse(txtBlockSize.Text) + 2);
            lblResolution.Text = $"Resolution: {width}x{height}";
        }

        private void txtFieldWidthOrHeight_OnChange(object sender, EventArgs e)
        {
            checkIfCorrectValueInField(sender, 25);
        }
        private void txtFieldBlockSize_OnChange(object sender, EventArgs e)
        {
            checkIfCorrectValueInField(sender, 5);
        }

        private void checkIfCorrectValueInField(object sender, int minValue)
        {
            if (sender != null)
            {
                var textBox = sender as TextBox;
                checkTxtLength(textBox);

                int value = int.Parse(textBox.Text);
                textBox.Text = value.ToString();

                if (value < minValue)
                {
                    btnLaunch.Enabled = false;
                    textBox.ForeColor = Color.Red;
                }
                else
                {
                    btnLaunch.Enabled = true;
                    textBox.ForeColor = Color.Black;
                    txtResilution_Calculate();
                }
            }
        }

        private void checkTxtLength(TextBox textBox)
        {
            if (textBox.Text.Length == 0)
            {
                textBox.Text = "0";
            }

            if (textBox.Text.Length == 1)
            {
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
            }

            if (textBox.Text.Length > 4)
            {
                textBox.Text = textBox.Text.Substring(0, 4);
            }
        }

        private void txtResolutionFields_TextChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                var textBox = sender as TextBox;
                checkTxtLength(textBox);

                Settings.TerrainDomainNumber = int.Parse(txtTerrainDomainNumber.Text);
                Settings.TerrainDomainPower = int.Parse(txtTerrainPower.Text);
                Settings.FoodCount = int.Parse(txtFoodCount.Text);
                Settings.RenderDelay = int.Parse(txtRenderDelay.Text);
                Settings.UpdateDeleay = int.Parse(txtUpdateDalay.Text);

                txtTerrainDomainNumber.Text = Settings.TerrainDomainNumber.ToString();
                txtTerrainPower.Text = Settings.TerrainDomainPower.ToString();
                txtFoodCount.Text = Settings.FoodCount.ToString();
                txtRenderDelay.Text = Settings.RenderDelay.ToString();
                txtUpdateDalay.Text = Settings.UpdateDeleay.ToString();
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            battlefield?.Dispose();
            battlefield = new BattlefieldForm();
            battlefield.Show();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Updater.CheckUpdates();
        }
    }
}