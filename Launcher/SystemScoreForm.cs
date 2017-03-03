using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeBattle;
using System.Threading;
using System.Collections;

namespace Launcher
{
    public partial class SystemScoreForm : Form
    {
        public SystemScoreForm(World world)
        {
            InitializeComponent();

            new Thread(() =>
            {
                try
                {
                    while (!IsDisposed)
                    {
                        var heads = world.Controller.GetObjects(typeof(Head)).ToList();
                        var dict = new Dictionary<Point, ArrayList>();

                        foreach (Head head in heads)
                        {
                            dict.Add(head.Position, new ArrayList()
                            {
                                head.Name,
                                head.Score
                            });
                        }

                        var sorted = dict.OrderBy(obj => obj.Value[1]).Reverse().ToList();

                        if (lblInfo.InvokeRequired)
                        {
                            lblInfo.Invoke(new Action(delegate
                            {
                                lblInfo.Text = "";

                                foreach (var d in sorted)
                                {
                                    lblInfo.Text += $"{d.Value[0]} + {Math.Round((double)d.Value[1], 3)}\n";
                                }
                                
                            }));
                        }

                        Thread.Sleep(100);
                    }
                }
                catch
                {
                }
            })
            { IsBackground = true }.Start();
        }
    }
}
