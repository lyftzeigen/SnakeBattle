using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SnakeBattle;

namespace Launcher
{
    public partial class BattlefieldForm : Form
    {
        private World world;
        private SystemInfoForm systemInfo;
        private SystemScoreForm systemScore;
        private BlockRenderer renderer;

        private Thread updateThread;
        private Thread renderThread;
        private Thread syncThread;

        public BattlefieldForm()
        {
            InitializeComponent();

            world = new World(
                Settings.BlokSize,
                Settings.FieldWidth,
                Settings.FieldHeight,
                Settings.TerrainDomainNumber,
                Settings.TerrainDomainPower,
                Settings.FoodCount);

            renderer = new BlockRenderer(world);

            ClientSize = world.SizeInPixels;

            updateThread = new Thread(DoUpdate) {IsBackground = true};
            renderThread = new Thread(DoRender) {IsBackground = true};
            syncThread = new Thread(DoSync) {IsBackground = true};

            updateThread.Start();
            renderThread.Start();
            syncThread.Start();

            systemInfo?.Dispose();
            systemInfo = new SystemInfoForm(world, renderer);
            systemInfo.Show(this);

            systemScore?.Dispose();
            systemScore = new SystemScoreForm(world);
            systemScore.Show(this);
        }

        private void DoSync()
        {
            while (true)
            {
                if (!updateThread.IsAlive && !renderThread.IsAlive)
                {
                    break;
                }

                Thread.Sleep(50);
            }

            world.Dispose();
            systemInfo.Dispose();
            renderer.Dispose();
        }

        private void DoRender()
        {
            while (!IsDisposed)
            {
                Invalidate();
                Thread.Sleep(Settings.RenderDelay);
            }
        }

        private void DoUpdate()
        {
            world.Startup();

            while (!IsDisposed)
            {
                world.Update();
                Thread.Sleep(Settings.UpdateDeleay);
            }
        }

        private void BattlefieldForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.LightGray);
            renderer.Draw(e.Graphics);
        }
    }
}