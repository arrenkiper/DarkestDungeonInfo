using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DarkestDungeonInfo
{
    public class MainForm : Form
    {
        private RunManager runManager = new RunManager();

        private ListBox listBoxWeeks;
        private Button btnAddWeek;
        private Button btnRemoveWeek;
        private DataGridView dgvHeroes;

        private Label lblGlobalScoreTitle;
        private Label lblGlobalScoreValues;

        private Label lblRunNumber;
        private TextBox txtRunNumber;

        private GroupBox grpMissionResults;
        private CheckBox chkCollector;
        private CheckBox chkShambler;
        private CheckBox chkSuccess;

        public readonly Color colorDarkBg = Color.FromArgb(40, 40, 40);
        public readonly Color colorGray = Color.FromArgb(170, 170, 170);

        private readonly List<string> allHeroClasses = new List<string>
        {
            "Весталка", "Разбойник", "Воитель", "Шут", "Прокаженный",
            "Выродок", "Чумной доктор", "Оккультист", "Дикарка",
            "Крестоносец", "Наемник", "Дрессировщик", "Арбалетчица",
            "Могильная воровка", "Антикварка", "Флагеллант",
            "Щитоломка", "Мушкетер"
        };

        public MainForm()
        {
            this.Text = "Darkest Dungeon - Менеджер Экспедиций";

            // ПРИНУДИТЕЛЬНАЯ УСТАНОВКА ИКОНКИ
            try { this.Icon = new Icon("Stress.ico"); } catch { }

            this.Width = 625;
            this.Height = 735;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeInterfaceControls();
            SetupTableColumns();
            ApplyMainStyle();

            runManager.ChangeRun(txtRunNumber.Text);
            RefreshInterface();
        }

        private void ApplyMainStyle()
        {
            this.BackColor = colorDarkBg;
            this.ForeColor = colorGray;

            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = colorDarkBg;
                    btn.ForeColor = colorGray;
                    btn.FlatAppearance.BorderColor = colorGray;
                    btn.Font = new Font("Georgia", 9, FontStyle.Bold);
                }
            }

            btnRemoveWeek.ForeColor = Color.IndianRed;
            btnRemoveWeek.FlatAppearance.BorderColor = Color.IndianRed;

            grpMissionResults.ForeColor = colorGray;
            foreach (Control control in grpMissionResults.Controls)
            {
                control.ForeColor = colorGray;
            }

            listBoxWeeks.BackColor = colorDarkBg;
            listBoxWeeks.ForeColor = colorGray;

            txtRunNumber.BackColor = colorDarkBg;
            txtRunNumber.ForeColor = colorGray;
            txtRunNumber.BorderStyle = BorderStyle.FixedSingle;

            dgvHeroes.BackgroundColor = colorDarkBg;
            dgvHeroes.DefaultCellStyle.BackColor = colorDarkBg;
            dgvHeroes.DefaultCellStyle.ForeColor = colorGray;
            dgvHeroes.ColumnHeadersDefaultCellStyle.BackColor = colorDarkBg;
            dgvHeroes.ColumnHeadersDefaultCellStyle.ForeColor = colorGray;
            dgvHeroes.EnableHeadersVisualStyles = false;
        }

        private void InitializeInterfaceControls()
        {
            lblRunNumber = new Label { Text = "Номер рана:", Location = new Point(12, 15), Size = new Size(75, 20) };
            this.Controls.Add(lblRunNumber);

            txtRunNumber = new TextBox { Location = new Point(87, 12), Size = new Size(75, 20), Text = "30" };
            txtRunNumber.TextChanged += TxtRunNumber_TextChanged;
            this.Controls.Add(txtRunNumber);

            btnAddWeek = new Button { Text = "Добавить экспедицию", Location = new Point(12, 45), Size = new Size(150, 30) };
            btnAddWeek.Click += btnAddWeek_Click;
            this.Controls.Add(btnAddWeek);

            btnRemoveWeek = new Button { Text = "Удалить неделю", Location = new Point(12, 80), Size = new Size(150, 25) };
            btnRemoveWeek.Click += btnRemoveWeek_Click;
            this.Controls.Add(btnRemoveWeek);

            listBoxWeeks = new ListBox { Location = new Point(12, 115), Size = new Size(150, 340) };
            listBoxWeeks.SelectedIndexChanged += listBoxWeeks_SelectedIndexChanged;
            this.Controls.Add(listBoxWeeks);

            grpMissionResults = new GroupBox { Text = "Отчет о походе", Location = new Point(12, 465), Size = new Size(150, 125) };
            this.Controls.Add(grpMissionResults);

            chkCollector = new CheckBox { Text = "Коллекционер", Location = new Point(10, 20), Size = new Size(130, 20) };
            chkCollector.CheckedChanged += MissionResult_Changed;
            chkShambler = new CheckBox { Text = "Тьманник", Location = new Point(10, 50), Size = new Size(130, 20) };
            chkShambler.CheckedChanged += MissionResult_Changed;
            chkSuccess = new CheckBox { Text = "Миссия успешна", Location = new Point(10, 85), Size = new Size(130, 20), Font = new Font("Arial", 8, FontStyle.Bold) };
            chkSuccess.CheckedChanged += MissionResult_Changed;
            grpMissionResults.Controls.AddRange(new Control[] { chkCollector, chkShambler, chkSuccess });

            lblGlobalScoreTitle = new Label { Location = new Point(12, 600), Size = new Size(95, 80), Font = new Font("Arial", 9, FontStyle.Bold), Text = "ОБЩИЙ СЧЕТ:\nПсихозы:\nПодъемы:" };
            this.Controls.Add(lblGlobalScoreTitle);

            lblGlobalScoreValues = new Label { Location = new Point(107, 600), Size = new Size(50, 80), Font = new Font("Arial", 9, FontStyle.Bold), Text = "\n0\n0" };
            this.Controls.Add(lblGlobalScoreValues);

            dgvHeroes = new DataGridView { Location = new Point(180, 12), Size = new Size(416, 672), ScrollBars = ScrollBars.None };
            this.Controls.Add(dgvHeroes);
        }

        private void SetupTableColumns()
        {
            dgvHeroes.AutoGenerateColumns = false;
            dgvHeroes.AllowUserToAddRows = false;
            dgvHeroes.RowHeadersVisible = false;
            dgvHeroes.RowTemplate.Height = 35;

            var centerCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter };

            dgvHeroes.Columns.Add(new DataGridViewImageColumn { DataPropertyName = "Icon", HeaderText = "", ImageLayout = DataGridViewImageCellLayout.Stretch, Width = 35 });
            dgvHeroes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Класс героя", ReadOnly = true, Width = 115, DefaultCellStyle = centerCellStyle });
            dgvHeroes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Psychoses", HeaderText = "Психозы", ReadOnly = true, Width = 65, DefaultCellStyle = centerCellStyle });

            dgvHeroes.Columns.Add(new DataGridViewButtonColumn { HeaderText = "+", Text = "+", UseColumnTextForButtonValue = true, Width = 35, FlatStyle = FlatStyle.Flat });
            dgvHeroes.Columns.Add(new DataGridViewButtonColumn { HeaderText = "-", Text = "-", UseColumnTextForButtonValue = true, Width = 35, FlatStyle = FlatStyle.Flat });

            dgvHeroes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Virtues", HeaderText = "Подъемы", ReadOnly = true, Width = 65, DefaultCellStyle = centerCellStyle });
            dgvHeroes.Columns.Add(new DataGridViewButtonColumn { HeaderText = "+", Text = "+", UseColumnTextForButtonValue = true, Width = 35, FlatStyle = FlatStyle.Flat });
            dgvHeroes.Columns.Add(new DataGridViewButtonColumn { HeaderText = "-", Text = "-", UseColumnTextForButtonValue = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FlatStyle = FlatStyle.Flat });

            dgvHeroes.CellContentClick += DgvHeroes_CellContentClick;
        }

        private void RefreshInterface()
        {
            chkCollector.CheckedChanged -= MissionResult_Changed;
            chkShambler.CheckedChanged -= MissionResult_Changed;
            chkSuccess.CheckedChanged -= MissionResult_Changed;

            listBoxWeeks.DataSource = null;
            listBoxWeeks.DataSource = runManager.WeeksList;

            if (runManager.WeeksList.Count > 0 && runManager.CurrentWeek != null)
            {
                listBoxWeeks.SelectedItem = runManager.CurrentWeek;

                foreach (var hero in runManager.CurrentWeek.Heroes)
                {
                    hero.Icon = HeroAssetManager.GetIcon(hero.Name);
                }

                dgvHeroes.DataSource = null;
                dgvHeroes.AutoGenerateColumns = false;
                dgvHeroes.DataSource = runManager.CurrentWeek.Heroes;
                dgvHeroes.Refresh();

                chkCollector.Checked = runManager.CurrentWeek.HadCollector;
                chkShambler.Checked = runManager.CurrentWeek.HadShambler;
                chkSuccess.Checked = runManager.CurrentWeek.IsSuccess;
            }
            else
            {
                dgvHeroes.DataSource = null;
                chkCollector.Checked = chkShambler.Checked = chkSuccess.Checked = false;
            }

            lblGlobalScoreValues.Text = $"\n{runManager.TotalPsychoses}\n{runManager.TotalVirtues}";

            chkCollector.CheckedChanged += MissionResult_Changed;
            chkShambler.CheckedChanged += MissionResult_Changed;
            chkSuccess.CheckedChanged += MissionResult_Changed;
        }

        private void btnAddWeek_Click(object sender, EventArgs e)
        {
            using (var missionForm = new MissionForm(allHeroClasses))
            {
                if (missionForm.ShowDialog() == DialogResult.OK)
                {
                    runManager.AddNewWeek(
                        missionForm.SelectedLocation,
                        missionForm.SelectedLength,
                        missionForm.SelectedType,
                        missionForm.SelectedHeroes
                    );
                    RefreshInterface();
                }
            }
        }

        private void btnRemoveWeek_Click(object sender, EventArgs e)
        {
            if (runManager.CurrentWeek == null) return;

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить {runManager.CurrentWeek.WeekName}?",
                "Удаление экспедиции",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                runManager.RemoveCurrentWeek();
                RefreshInterface();
            }
        }

        private void listBoxWeeks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = listBoxWeeks.SelectedItem as GameWeek;
            if (selected != null)
            {
                runManager.CurrentWeek = selected;
                RefreshInterface();
            }
        }

        private void MissionResult_Changed(object sender, EventArgs e)
        {
            if (runManager.CurrentWeek == null) return;

            runManager.CurrentWeek.HadCollector = chkCollector.Checked;
            runManager.CurrentWeek.HadShambler = chkShambler.Checked;
            runManager.CurrentWeek.IsSuccess = chkSuccess.Checked;

            runManager.Save();
        }

        private void DgvHeroes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || runManager.CurrentWeek == null || dgvHeroes.Rows.Count == 0) return;

            var hero = dgvHeroes.Rows[e.RowIndex].DataBoundItem as HeroStatus;
            if (hero == null) return;

            if (e.ColumnIndex == 3) hero.Psychoses++;
            else if (e.ColumnIndex == 4 && hero.Psychoses > 0) hero.Psychoses--;
            else if (e.ColumnIndex == 6) hero.Virtues++;
            else if (e.ColumnIndex == 7 && hero.Virtues > 0) hero.Virtues--;

            dgvHeroes.InvalidateRow(e.RowIndex);
            runManager.Save();

            lblGlobalScoreValues.Text = $"\n{runManager.TotalPsychoses}\n{runManager.TotalVirtues}";
        }

        private void TxtRunNumber_TextChanged(object sender, EventArgs e)
        {
            runManager.ChangeRun(txtRunNumber.Text);
            RefreshInterface();
        }
    }
} 