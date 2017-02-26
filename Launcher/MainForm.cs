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
            txtResolutionFields_TextChanged(this, null);
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
            if (txtFieldWidth.Text != String.Empty && txtFieldHeight.Text != String.Empty && txtBlockSize.Text != String.Empty)
            {
                var width = int.Parse(txtFieldWidth.Text) * (int.Parse(txtBlockSize.Text) + 2);
                var height = int.Parse(txtFieldHeight.Text) * (int.Parse(txtBlockSize.Text) + 2);
                lblResolution.Text = $"Resolution: {width}x{height}";
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            Settings.FieldWidth = int.Parse(txtFieldWidth.Text);
            Settings.FieldHeight = int.Parse(txtFieldHeight.Text);
            Settings.BlokSize = int.Parse(txtBlockSize.Text);
            Settings.TerrainDomainNumber = int.Parse(txtTerrainCount.Text);
            Settings.TerrainDomainPower = int.Parse(txtTerrainPower.Text);
            Settings.FoodCount = int.Parse(txtFoodCount.Text);
            Settings.RenderDelay = int.Parse(txtRenderDelay.Text);
            Settings.UpdateDeleay = int.Parse(txtUpdateDalay.Text);

            battlefield?.Dispose();
            battlefield = new BattlefieldForm();
            battlefield.Show();
        }
    }
}