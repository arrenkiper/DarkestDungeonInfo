using System;
using System.ComponentModel;

namespace DarkestDungeonInfo
{
    [Serializable]
    public class GameWeek
    {
        public string WeekName { get; set; }
        public string Location { get; set; }
        public string Length { get; set; }
        public string MissionType { get; set; }
        public bool HadCollector { get; set; }
        public bool HadShambler { get; set; }
        public bool IsSuccess { get; set; }
        public BindingList<HeroStatus> Heroes { get; set; }

        public GameWeek(string weekName)
        {
            WeekName = weekName;
            Heroes = new BindingList<HeroStatus>();
        }

        public override string ToString()
        {
            return $"{WeekName} ({Location})";
        }
    }
}