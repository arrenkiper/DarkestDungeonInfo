using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public static class BossSelectionHandler
    {
        public static void RenderBossButtons(Panel targetPanel, string location, EventHandler onBossSelected)
        {
            targetPanel.Controls.Clear();
            var bossDatabase = BossData.GetBosses();

            if (!bossDatabase.ContainsKey(location)) return;

            var bosses = bossDatabase[location];

            int startX = 10;
            int startY = 10;
            int spacingX = 130;
            int spacingY = 90;

            for (int i = 0; i < bosses.Count; i++)
            {
                Button btn = new Button
                {
                    Size = new Size(120, 80),
                    Location = new Point(startX + (i % 2) * spacingX, startY + (i / 2) * spacingY),
                    Text = bosses[i].Name,
                    Tag = bosses[i]
                };

                btn.Click += onBossSelected;
                targetPanel.Controls.Add(btn);
            }
        }
    }
}