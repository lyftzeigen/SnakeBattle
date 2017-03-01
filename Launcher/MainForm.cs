using System;
using System.Windows.Forms;

namespace Launcher
{
    public partial class MainForm : Form
    {
        private BattlefieldForm battlefield;

        public MainForm()
        {
            InitializeComponent();
            txtResolutionFields_TextChanged(null, null);
        }

        private void txtFields_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtResolutionFields_TextChanged(object sender, EventArgs e)
        {
            if (sender != null && (sender as TextBox).Text.Length == 0)
            {
                (sender as TextBox).Text = "0";
            }

            if (sender != null && (sender as TextBox).Text.Length > 4)
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, 4);
            }

            Settings.FieldWidth = int.Parse(txtFieldWidth.Text);
            Settings.FieldHeight = int.Parse(txtFieldHeight.Text);
            Settings.BlokSize = int.Parse(txtBlockSize.Text);
            Settings.TerrainDomainNumber = int.Parse(txtTerrainDomainNumber.Text);
            Settings.TerrainDomainPower = int.Parse(txtTerrainPower.Text);
            Settings.FoodCount = int.Parse(txtFoodCount.Text);
            Settings.RenderDelay = int.Parse(txtRenderDelay.Text);
            Settings.UpdateDeleay = int.Parse(txtUpdateDalay.Text);

            txtFieldWidth.Text = Settings.FieldWidth.ToString();
            txtFieldHeight.Text = Settings.FieldHeight.ToString();
            txtBlockSize.Text = Settings.BlokSize.ToString();
            txtTerrainDomainNumber.Text = Settings.TerrainDomainNumber.ToString();
            txtTerrainPower.Text = Settings.TerrainDomainPower.ToString();
            txtFoodCount.Text = Settings.FoodCount.ToString();
            txtRenderDelay.Text = Settings.RenderDelay.ToString();
            txtUpdateDalay.Text = Settings.UpdateDeleay.ToString();

            if (sender != null)
            {
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }

            var width = int.Parse(txtFieldWidth.Text) * (int.Parse(txtBlockSize.Text) + 2);
            var height = int.Parse(txtFieldHeight.Text) * (int.Parse(txtBlockSize.Text) + 2);
            lblResolution.Text = $"Resolution: {width}x{height}";
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