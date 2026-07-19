using System.Collections.Generic;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public partial class MissionForm : Form
    {
        public MissionForm(List<string> heroClasses)
        {
            this.availableHeroes = heroClasses;

            InitializeComponent();

            InitializeUI();
        }
    }
}