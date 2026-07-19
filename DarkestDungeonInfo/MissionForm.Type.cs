using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public partial class MissionForm
    {
        private void UpdateTypeButtons(List<string> types)
        {
            panelTypeButtons.Controls.Clear();
            string iconsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", "Expedition");

            foreach (var type in types)
            {
                var btn = CreateStyleButton("", new Size(130, 120));
                string path = Path.Combine(iconsPath, type + "1.png");
                if (File.Exists(path)) btn.Image = Image.FromFile(path);

                btn.Controls.Add(new Label { Text = type, Dock = DockStyle.Bottom, TextAlign = ContentAlignment.MiddleCenter, ForeColor = colorTextDark });
                btn.Click += (s, e) => {
                    foreach (Control c in panelTypeButtons.Controls) if (c is Button b) ApplyBaseStyle(b);
                    ApplySelectedStyle(btn, colorActiveBorder);
                    SelectedType = type;
                };
                panelTypeButtons.Controls.Add(btn);
            }
        }
    }
}