using System;
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
            txtResolution_Calculate();
            updateTerrainSettings();
        }

        private void txtFields_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtResolution_Calculate()
        {
            updateResolutionSettings();

            var width = int.Parse(txtFieldWidth.Text) * (int.Parse(txtBlockSize.Text) + 2);
            var height = int.Parse(txtFieldHeight.Text) * (int.Parse(txtBlockSize.Text) + 2);
            lblResolution.Text = $"Resolution: {width}x{height}";
        }

        private void txtFieldWidthOrHeight_OnChange(object sender, EventArgs e)
        {
            checkIfCorrectValueInField(sender, 25, 100);
        }

        private void txtFieldBlockSize_OnChange(object sender, EventArgs e)
        {
            checkIfCorrectValueInField(sender, 5, 12);
        }

        private void checkIfCorrectValueInField(object sender, int minValue, int maxValue)
        {
            if (sender != null)
            {
                var textBox = sender as TextBox;
                checkTxtLength(textBox);

                int value = int.Parse(textBox.Text);
                textBox.Text = value.ToString();

                if (value < minValue || value > maxValue)
                {
                    btnLaunch.Enabled = false;
                    textBox.ForeColor = Color.Red;
                }
                else
                {
                    btnLaunch.Enabled = true;
                    textBox.ForeColor = Color.Black;
                    txtResolution_Calculate();
                }
            }
        }

        private void txtResolutionFields_OnChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                var textBox = sender as TextBox;
                checkTxtLength(textBox);
                updateTerrainSettings();

                txtTerrainDomainNumber.Text = Settings.TerrainDomainNumber.ToString();
                txtTerrainPower.Text = Settings.TerrainDomainPower.ToString();
                txtFoodCount.Text = Settings.FoodCount.ToString();
                txtRenderDelay.Text = Settings.RenderDelay.ToString();
                txtUpdateDalay.Text = Settings.UpdateDeleay.ToString();
            }
        }
        private void checkTxtLength(TextBox textBox)
        {
            if (textBox.Text.Length <= 0)
            {
                textBox.Text = "0";
            }

            if (textBox.Text.Length == 1 || textBox.Text.Length == 2 || textBox.Text.Length == 3)
            {
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
            }

            if (textBox.Text.Length > 3)
            {
                textBox.Text = textBox.Text.Substring(0, 3);
            }
        }

        private void updateResolutionSettings()
        {
            Settings.FieldWidth = int.Parse(txtFieldWidth.Text);
            Settings.FieldHeight = int.Parse(txtFieldHeight.Text);
            Settings.BlokSize = int.Parse(txtBlockSize.Text);
        }

        private void updateTerrainSettings()
        {
            Settings.TerrainDomainNumber = int.Parse(txtTerrainDomainNumber.Text);
            Settings.TerrainDomainPower = int.Parse(txtTerrainPower.Text);
            Settings.FoodCount = int.Parse(txtFoodCount.Text);
            Settings.RenderDelay = int.Parse(txtRenderDelay.Text);
            Settings.UpdateDeleay = int.Parse(txtUpdateDalay.Text);
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
