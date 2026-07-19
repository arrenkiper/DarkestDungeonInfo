using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public partial class MissionForm
    {
        public void UpdateTypeButtons(List<string> types)
        {
            panelTypeButtons.Controls.Clear();
            int btnSize = 110;
            int margin = 8;
            int columns = 3;
            int rows = (int)Math.Ceiling((double)types.Count / columns);

            panelTypeButtons.Width = (btnSize * columns) + (margin * (columns * 2));
            panelTypeButtons.Height = (btnSize * rows) + (margin * (rows * 2));
            panelTypeButtons.Left = (this.ClientSize.Width - panelTypeButtons.Width) / 2;

            string baseIconsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", "Expedition");

            foreach (var type in types)
            {
                var btn = CreateStyleButton(type == "БОСС" ? "БОСС" : "", new Size(btnSize, btnSize));
                btn.Margin = new Padding(margin);

                if (type != "БОСС")
                {
                    string path = (SelectedLocation == "ДВОР") ? Path.Combine(baseIconsPath, "Crimson", type + ".png") :
                                 (SelectedLocation == "ТЕМНЕЙШЕЕ") ? Path.Combine(baseIconsPath, "Темнейшее.png") :
                                 Path.Combine(baseIconsPath, type + "1.png");

                    if (File.Exists(path))
                    {
                        var pb = new PictureBox { Image = Image.FromFile(path), Size = new Size(70, 70), Location = new Point((btn.Width - 70) / 2, 10), SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.Transparent };
                        pb.Click += (s, e) => btn.PerformClick();
                        btn.Controls.Add(pb);
                    }

                    var lbl = new Label { Text = type, Dock = DockStyle.Bottom, TextAlign = ContentAlignment.MiddleCenter, ForeColor = colorGold, Font = new Font("Georgia", 7, FontStyle.Bold), BackColor = Color.Transparent, Height = 25 };
                    lbl.Click += (s, e) => btn.PerformClick();
                    btn.Controls.Add(lbl);
                }

                btn.Click += (s, e) => {
                    foreach (Control c in panelTypeButtons.Controls) if (c is Button b) ApplyBaseStyle(b);
                    ApplySelectedStyle(btn, colorGold);
                    SelectedType = type;

                    if (type == "БОСС")
                        LoadBossSelection();
                    else
                        LoadMissionButtons(type);

                    panelStep1.Visible = false;
                    panelStep2.Visible = true;
                };
                panelTypeButtons.Controls.Add(btn);
            }
        }
    }
}