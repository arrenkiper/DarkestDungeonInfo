using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public partial class MissionForm
    {
        public void CreateLocationButtons()
        {
            var locationMap = new Dictionary<string, List<string>>
            {
                { "РУИНЫ", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР", "АКТИВАЦИЯ" } },
                { "ЗАПОВЕДНИК", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР" } },
                { "ЧАЩА", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР" } },
                { "БУХТА", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "АКТИВАЦИЯ" } }
            };

            foreach (var loc in locationMap.Keys)
            {
                var btn = CreateStyleButton(loc, new Size(130, 40));
                btn.Click += (s, e) => {
                    foreach (Control c in panelLocationButtons.Controls) if (c is Button b) ApplyBaseStyle(b);
                    ApplySelectedStyle(btn, colorActiveBorder);
                    SelectedLocation = loc;
                    UpdateTypeButtons(locationMap[loc]);
                };
                panelLocationButtons.Controls.Add(btn);
            }
        }
    }
}