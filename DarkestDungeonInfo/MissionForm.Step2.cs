using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public partial class MissionForm
    {
        public void LoadMissionButtons(string missionType)
        {
            panelStep2.Controls.Clear();
            panelStep2.Controls.Add(btnBackToStep1);
            panelStep2.Controls.Add(btnNextStep2);

            if (SelectedLocation == "ТЕМНЕЙШЕЕ" || SelectedLocation == "ДВОР")
            {
                SelectedLength = "Сюжетная";
                SelectedDifficulty = (SelectedLocation == "ТЕМНЕЙШЕЕ") ? "5" : "Эксклюзивная";

                var lblStoryInfo = new Label
                {
                    Text = $"Выбрана сюжетная экспедиция:\n\"{missionType}\"\n\nДля этой миссии нет фиксированной сетки сложности.\nНажмите кнопку \"ВЫБОР ГЕРОЕВ\" для перехода к составу команды.",
                    Font = new Font("Georgia", 11, FontStyle.Italic | FontStyle.Bold),
                    ForeColor = Color.FromArgb(218, 165, 32),
                    BackColor = Color.Transparent,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(380, 200),
                    Location = new Point(20, 150)
                };
                panelStep2.Controls.Add(lblStoryInfo);

                return;
            }

            string[] lengths = { "Короткая", "Средняя", "Длинная" };
            string[] difficulties = { "1", "3", "5" };

            string folderPath = Path.Combine(Application.StartupPath, "Icons", "Expedition", missionType);

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show($"Папка с анимациями/иконками не найдена:\n{folderPath}", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int row = 0; row < difficulties.Length; row++)
            {
                for (int col = 0; col < lengths.Length; col++)
                {
                    string fileName = $"{lengths[col]}{missionType}{difficulties[row]}.png";
                    string fullPath = Path.Combine(folderPath, fileName);

                    var btn = new Button
                    {
                        Text = lengths[col].ToUpper(),
                        Size = new Size(125, 125),
                        Location = new Point(20 + col * 140, 20 + row * 140),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.FromArgb(40, 40, 40),
                        ForeColor = Color.FromArgb(218, 165, 32),
                        TextAlign = ContentAlignment.BottomCenter,
                        TextImageRelation = TextImageRelation.ImageAboveText
                    };
                    btn.FlatAppearance.BorderColor = Color.FromArgb(218, 165, 32);

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            btn.Image = Image.FromFile(fullPath);
                        }
                        catch
                        {
                        }
                    }

                    int r = row;
                    int c = col;
                    btn.Click += (s, e) => {
                        SelectedDifficulty = difficulties[r];
                        SelectedLength = lengths[c];

                        foreach (Control ctrl in panelStep2.Controls)
                        {
                            if (ctrl is Button b && b != btnBackToStep1 && b != btnNextStep2)
                            {
                                b.FlatAppearance.BorderColor = Color.FromArgb(218, 165, 32);
                            }
                        }
                        btn.FlatAppearance.BorderColor = Color.White;
                    };

                    panelStep2.Controls.Add(btn);
                }
            }
        }
    }
}