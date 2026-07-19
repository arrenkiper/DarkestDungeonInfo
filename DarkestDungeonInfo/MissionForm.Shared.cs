using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DarkestDungeonInfo
{
    public partial class MissionForm
    {
        public string SelectedLocation { get; set; }
        public string SelectedType { get; set; }
        public List<string> availableHeroes;
        public Panel panelStep1;
        public FlowLayoutPanel panelLocationButtons;
        public FlowLayoutPanel panelTypeButtons;
        public Button btnNextStep;

        public readonly Color colorDarkBg = Color.FromArgb(20, 20, 20);
        public readonly Color colorBtnBg = Color.FromArgb(35, 35, 35);
        public readonly Color colorBtnBorder = Color.FromArgb(80, 70, 55);
        public readonly Color colorActiveBorder = Color.FromArgb(190, 50, 40);
        public readonly Color colorTextDark = Color.FromArgb(140, 130, 120);
        public readonly Font fontGothicButton = new Font("Georgia", 9, FontStyle.Bold);

        public Button CreateStyleButton(string text, Size size)
        {
            var btn = new Button { Text = text, Size = size, Font = fontGothicButton, FlatStyle = FlatStyle.Flat, BackColor = colorBtnBg, ForeColor = colorTextDark };
            btn.FlatAppearance.BorderColor = colorBtnBorder;
            return btn;
        }

        public void ApplyBaseStyle(Button btn) { btn.BackColor = colorBtnBg; btn.FlatAppearance.BorderColor = colorBtnBorder; }
        public void ApplySelectedStyle(Button btn, Color color) { btn.BackColor = Color.FromArgb(55, 45, 35); btn.FlatAppearance.BorderColor = color; }
    }
}