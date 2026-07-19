using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public partial class MissionForm
    {
        public void CreateLocationButtons()
        {
            panelLocationButtons.Controls.Clear();
            panelLocationButtons.Padding = new Padding(10, 10, 10, 10);

            var locationMap = new Dictionary<string, List<string>>
            {
                { "РУИНЫ", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР", "АКТИВАЦИЯ", "БОСС" } },
                { "ЗАПОВЕДНИК", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР", "АКТИВАЦИЯ", "БОСС" } },
                { "ЧАЩА", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР", "АКТИВАЦИЯ", "БОСС" } },
                { "БУХТА", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР", "АКТИВАЦИЯ", "БОСС" } },
                { "ТЕМНЕЙШЕЕ", new List<string> { "МЕЛОЧИ", "ГЛАЗА", "ПРОДУКТ", "СЕРДЦЕ" } },
                { "ДВОР", new List<string> { "СборКрови 1", "СборКрови 3", "СборКрови 5-6", "Сжечь", "Барон", "Вифиня" } },
                { "Ввульф", new List<string>() },
                { "Жатва", new List<string>() },
                { "Вопила", new List<string>() }
            };

            foreach (var loc in locationMap.Keys)
            {
                var btn = CreateStyleButton(loc, new Size(130, 40));

                if (loc == "Ввульф") btn.Margin = new Padding(0, 20, 0, 0);
                else btn.Margin = new Padding(3);

                btn.Click += (s, e) => {
                    foreach (Control c in panelLocationButtons.Controls)
                        if (c is Button b) ApplyBaseStyle(b);
                    ApplySelectedStyle(btn, colorGold);

                    SelectedLocation = loc;

                    if (locationMap[loc].Count == 0)
                    {
                        SelectedBoss = loc;
                        SelectedType = null;
                        panelTypeButtons.Visible = false;
                    }
                    else
                    {
                        panelTypeButtons.Visible = true;
                        UpdateTypeButtons(locationMap[loc]);
                    }
                };
                panelLocationButtons.Controls.Add(btn);
            }
        }
    }
}