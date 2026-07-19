using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace DarkestDungeonInfo
{
    public class RunManager
    {
        public BindingList<GameWeek> WeeksList { get; private set; } = new BindingList<GameWeek>();
        public GameWeek CurrentWeek { get; set; } = null;
        public string CurrentRunNumber { get; private set; } = "30";

        public int TotalPsychoses => WeeksList.Sum(w => w.Heroes.Sum(h => h.Psychoses));
        public int TotalVirtues => WeeksList.Sum(w => w.Heroes.Sum(h => h.Virtues));

        public void ChangeRun(string runNumber)
        {
            CurrentRunNumber = runNumber.Trim();
            WeeksList.Clear();

            if (SaveManager.LoadData(WeeksList, CurrentRunNumber))
            {
                if (WeeksList.Count > 0) CurrentWeek = WeeksList[0];
            }
        }

        public void AddNewWeek(string location, string length, string type, List<string> selectedHeroes)
        {
            int weekNumber = WeeksList.Count + 1;
            GameWeek newWeek = new GameWeek($"Неделя {weekNumber}")
            {
                Location = location,
                Length = length,
                MissionType = type
            };

            foreach (var heroName in selectedHeroes)
            {
                var hero = new HeroStatus(heroName);
                newWeek.Heroes.Add(hero);
            }

            WeeksList.Add(newWeek);
            CurrentWeek = newWeek;
            Save();
        }

        public void RemoveCurrentWeek()
        {
            if (CurrentWeek != null && WeeksList.Contains(CurrentWeek))
            {
                int index = WeeksList.IndexOf(CurrentWeek);
                WeeksList.Remove(CurrentWeek);

                for (int i = 0; i < WeeksList.Count; i++)
                {
                    WeeksList[i].WeekName = $"Неделя {i + 1}";
                }

                if (WeeksList.Count > 0)
                {
                    int nextIndex = Math.Min(index, WeeksList.Count - 1);
                    CurrentWeek = WeeksList[nextIndex];
                }
                else
                {
                    CurrentWeek = null;
                }

                Save();
            }
        }

        public void Save()
        {
            SaveManager.SaveData(WeeksList, CurrentRunNumber);
        }
    }
}