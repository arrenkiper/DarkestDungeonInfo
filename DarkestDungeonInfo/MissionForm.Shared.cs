using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DarkestDungeonInfo
{
    public partial class MissionForm
    {
        public string SelectedLocation { get; set; }
        public string SelectedType { get; set; }
        public string SelectedLength { get; set; }
        public string SelectedDifficulty { get; set; }
        public string SelectedBoss { get; set; }
        public List<string> SelectedHeroes { get; set; } = new List<string>();
        public List<string> availableHeroes = new List<string>();

        public Panel panelStep1;
        public Panel panelLocationButtons;
        public FlowLayoutPanel panelTypeButtons;
        public Button btnNextStep;

        public Panel panelStep2;
        public Button btnNextStep2;
        public Button btnBackToStep1;

        public readonly Color colorGold = Color.FromArgb(218, 165, 32);
        public readonly Color colorDarkBg = Color.FromArgb(40, 40, 40);

        public Button CreateStyleButton(string text, Size size)
        {
            var btn = new Button
            {
                Text = text,
                Size = size,
                Font = new Font("Georgia", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                BackColor = colorDarkBg,
                ForeColor = colorGold
            };
            btn.FlatAppearance.BorderColor = colorGold;
            return btn;
        }

        public void ApplyBaseStyle(Button btn)
        {
            btn.BackColor = colorDarkBg;
            btn.FlatAppearance.BorderColor = colorGold;
            btn.ForeColor = colorGold;
        }

        public void ApplySelectedStyle(Button btn, Color color)
        {
            btn.BackColor = Color.FromArgb(60, 60, 50);
            btn.FlatAppearance.BorderColor = colorGold;
            btn.ForeColor = colorGold;
        }
    }
}