using System.Drawing;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public partial class MissionForm
    {
        private void InitializeUI()
        {
            this.Size = new Size(460, 650);
            this.BackColor = colorDarkBg;

            panelStep1 = new Panel { Dock = DockStyle.Fill, BackColor = colorDarkBg };
            panelLocationButtons = new FlowLayoutPanel { Location = new Point(20, 20), Size = new Size(410, 120) };
            panelTypeButtons = new FlowLayoutPanel { Location = new Point(20, 150), Size = new Size(410, 300) };

            btnNextStep = new Button { Text = "ДАЛЕЕ", Location = new Point(20, 550), Size = new Size(405, 40), Enabled = true, FlatStyle = FlatStyle.Flat };
            btnNextStep.BackColor = colorBtnBg;
            btnNextStep.FlatAppearance.BorderColor = colorBtnBorder;
            btnNextStep.ForeColor = colorTextDark;

            panelStep1.Controls.Add(panelLocationButtons);
            panelStep1.Controls.Add(panelTypeButtons);
            panelStep1.Controls.Add(btnNextStep);
            this.Controls.Add(panelStep1);

            CreateLocationButtons();
        }
    }
}