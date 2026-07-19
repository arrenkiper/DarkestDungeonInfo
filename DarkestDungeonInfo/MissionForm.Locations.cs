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

            var locationMap = new Dictionary<string, List<string>>
            {
                { "РУИНЫ", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР", "АКТИВАЦИЯ", "БОСС" } },
                { "ЗАПОВЕДНИК", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР", "АКТИВАЦИЯ", "БОСС" } },
                { "ЧАЩА", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР", "АКТИВАЦИЯ", "БОСС" } },
                { "БУХТА", new List<string> { "ИССЛЕДОВАНИЕ", "ЗАЧИСТКА", "СБОР", "АКТИВАЦИЯ", "БОСС" } },
                { "ТЕМНЕЙШЕЕ", new List<string> { "МЕЛОЧИ", "ГЛАЗА", "ПРОДУКТ", "СЕРДЦЕ" } },
                { "ДВОР", new List<string> { "СборКрови 1", "СборКрови 3", "СборКрови 5-6", "Сжечь", "Барон", "Вифиня" } },
                { "ВВУЛЬФ", new List<string>() },
                { "ЖАТВА", new List<string>() },
                { "ВОПИЛА", new List<string>() }
            };

            var locations = new List<string>(locationMap.Keys);
            const int columns = 3;
            const int btnWidth = 123;
            const int btnHeight = 40;
            const int spacingX = 6;
            const int spacingY = 10;
            const int startX = 12;
            const int startY = 12;

            int y = startY;
            for (int row = 0; row * columns < locations.Count; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int index = row * columns + col;
                    if (index >= locations.Count) break;

                    string loc = locations[index];
                    int x = startX + col * (btnWidth + spacingX);

                    var btn = CreateStyleButton(loc, new Size(btnWidth, btnHeight));
                    btn.Location = new Point(x, y);

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

                y += btnHeight + spacingY;
            }
        }
    }
}