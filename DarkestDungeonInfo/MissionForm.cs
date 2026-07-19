using System.Collections.Generic;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public partial class MissionForm : Form
    {
        public MissionForm(List<string> heroClasses)
        {
            InitializeComponent();

            this.availableHeroes = heroClasses;
            InitializeUI();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "MissionForm";
            this.Text = "Выбор экспедиции";
            this.ResumeLayout(false);
        }
    }
}