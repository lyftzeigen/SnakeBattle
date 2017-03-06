using System;
using System.Threading;
using System.Windows.Forms;
using SnakeBattle;

namespace Launcher
{
    public partial class SystemInfoForm : Form
    {
        public SystemInfoForm(World world, BlockRenderer renderer)
        {
            InitializeComponent();

            new Thread(() =>
                {
                    while (!IsDisposed)
                    {
                        try
                        {
                            if (lblInfo.InvokeRequired)
                            {
                                lblInfo.Invoke(new Action(delegate
                                {
                                    lblInfo.Text = $"World generating...\n" +
                                                   $"Borders: {world.BorderGenerationTime} ms\n" +
                                                   $"Terrain: {world.TerrainGenerationTime} ms\n" +
                                                   $"Food: {world.FoodGenerationTime} ms\n" +
                                                   $"Plugins: {world.PluginLoadingTime} ms\n" +
                                                   $"\n" +
                                                   $"Render time: {renderer.DrawTime} ms\n" +
                                                   $"Update time: {world.LogicUpdateTime} ms\n";
                                }));
                            }
                            Thread.Sleep(100);
                        }
                        catch
                        {
                        }
                    }
                })
                {IsBackground = true}.Start();
        }
    }
}