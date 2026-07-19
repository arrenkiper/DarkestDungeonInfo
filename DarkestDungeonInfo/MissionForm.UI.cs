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

            panelLocationButtons = new Panel { Location = new Point(20, 20), Size = new Size(410, 250) };
            panelTypeButtons = new FlowLayoutPanel { Location = new Point(20, 280), Size = new Size(410, 100) };

            btnNextStep = new Button { Text = "ДАЛЕЕ", Location = new Point(20, 550), Size = new Size(405, 40), FlatStyle = FlatStyle.Flat, Font = new Font("Georgia", 9, FontStyle.Bold) };
            ApplyBaseStyle(btnNextStep);
            btnNextStep.Click += (s, e) => {
                bool isSpecialBoss = (SelectedLocation == "Ввульф" || SelectedLocation == "Жатва" || SelectedLocation == "Вопила");

                if (string.IsNullOrEmpty(SelectedLocation) || (string.IsNullOrEmpty(SelectedType) && !isSpecialBoss))
                {
                    MessageBox.Show("Сперва выберите локацию и тип задания!");
                    return;
                }

                panelStep1.Visible = false;
                panelStep2.Visible = true;
            };

            panelStep1.Controls.Add(panelLocationButtons);
            panelStep1.Controls.Add(panelTypeButtons);
            panelStep1.Controls.Add(btnNextStep);

            panelStep2 = new Panel { Dock = DockStyle.Fill, BackColor = colorDarkBg, Visible = false };

            btnBackToStep1 = new Button { Text = "НАЗАД", Location = new Point(20, 550), Size = new Size(195, 40), FlatStyle = FlatStyle.Flat, Font = new Font("Georgia", 9, FontStyle.Bold) };
            ApplyBaseStyle(btnBackToStep1);
            btnBackToStep1.Click += (s, e) => { panelStep2.Visible = false; panelStep1.Visible = true; };

            btnNextStep2 = new Button { Text = "ДОБАВИТЬ НЕДЕЛЮ", Location = new Point(230, 550), Size = new Size(195, 40), FlatStyle = FlatStyle.Flat, Font = new Font("Georgia", 9, FontStyle.Bold) };
            ApplyBaseStyle(btnNextStep2);
            btnNextStep2.Click += (s, e) => {
                bool isSpecialBoss = (SelectedLocation == "Ввульф" || SelectedLocation == "Жатва" || SelectedLocation == "Вопила");

                if (!isSpecialBoss && (string.IsNullOrEmpty(SelectedLength) || string.IsNullOrEmpty(SelectedDifficulty)))
                {
                    MessageBox.Show("Сперва выберите экспедицию!");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            panelStep2.Controls.Add(btnBackToStep1);
            panelStep2.Controls.Add(btnNextStep2);

            this.Controls.Add(panelStep1);
            this.Controls.Add(panelStep2);

            CreateLocationButtons();
        }
    }
}