using System;
using System.Drawing;

namespace DarkestDungeonInfo
{
    [Serializable]
    public class HeroStatus
    {
        public string Name { get; set; }
        public int Psychoses { get; set; }
        public int Virtues { get; set; }

        [field: NonSerialized]
        public Image Icon { get; set; }

        public HeroStatus(string name)
        {
            Name = name;
            Psychoses = 0;
            Virtues = 0;
        }
    }
}