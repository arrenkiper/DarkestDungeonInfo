using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DarkestDungeonInfo
{
    public partial class MissionForm
    {
        public void LoadBossSelection()
        {
            panelStep2.Controls.Clear();
            panelStep2.Controls.Add(btnBackToStep1);

            Label lblTitle = new Label
            {
                Text = $"ВЫБОР БОССА: {SelectedLocation}",
                Location = new Point(20, 20),
                Size = new Size(400, 30),
                ForeColor = colorGold,
                Font = new Font("Georgia", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelStep2.Controls.Add(lblTitle);

            string[] bosses = GetBossesForLocation(SelectedLocation);
            int[] difficultyLevels = { 1, 3, 5 };

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    string bossName = (col < bosses.Length) ? bosses[col] : "Пусто";
                    int currentLevel = difficultyLevels[row];

                    var btn = CreateStyleButton("", new Size(190, 80));
                    btn.Location = new Point(20 + col * 210, 70 + row * 90);
                    btn.Tag = $"{bossName}|{currentLevel}";

                    string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", "Expedition", "Босс", $"Босс{currentLevel}.png");

                    if (File.Exists(iconPath))
                    {
                        var pb = new PictureBox { Image = Image.FromFile(iconPath), Size = new Size(40, 40), Location = new Point(75, 5), SizeMode = PictureBoxSizeMode.StretchImage, BackColor = Color.Transparent };
                        pb.Click += (s, e) => btn.PerformClick();
                        btn.Controls.Add(pb);
                    }

                    var lbl = new Label { Text = bossName, Location = new Point(0, 45), Size = new Size(190, 30), TextAlign = ContentAlignment.MiddleCenter, ForeColor = colorGold, Font = new Font("Georgia", 8, FontStyle.Bold), BackColor = Color.Transparent };
                    lbl.Click += (s, e) => btn.PerformClick();
                    btn.Controls.Add(lbl);

                    btn.Click += (s, e) => {
                        string[] data = btn.Tag.ToString().Split('|');
                        SelectedBoss = data[0];
                        SelectedDifficulty = data[1];
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    };
                    panelStep2.Controls.Add(btn);
                }
            }
        }

        private string[] GetBossesForLocation(string location)
        {
            switch (location)
            {
                case "РУИНЫ":
                    return new[] { "Некромант", "Пророк" };
                case "ЗАПОВЕДНИК":
                    return new[] { "Свиной принц", "Бесформенная Плоть" };
                case "ЧАЩА":
                    return new[] { "Старая Ведьма", "8-Фунтовая Пушка" };
                case "БУХТА":
                    return new[] { "Сирена", "Промокшая Команда" };
                default:
                    return new[] { "Босс А", "Босс Б" };
            }
        }
    }
}