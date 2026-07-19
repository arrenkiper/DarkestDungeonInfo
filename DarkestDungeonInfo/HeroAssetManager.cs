using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DarkestDungeonInfo
{
    public static class HeroAssetManager
    {
        private static readonly Dictionary<string, string> fileMapping = new Dictionary<string, string>();
        private static readonly Dictionary<string, Image> loadedIcons = new Dictionary<string, Image>();
        private static readonly string iconsFolderPath;

        static HeroAssetManager()
        {
            iconsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons");

            fileMapping["Антикварка"] = "Антиквар.png";
            fileMapping["Арбалетчица"] = "Арбалетчица.png";
            fileMapping["Весталка"] = "Весталка.png";
            fileMapping["Воитель"] = "Воитель.png";
            fileMapping["Выродок"] = "Выродок.png";
            fileMapping["Дикарка"] = "Дикарка.png";
            fileMapping["Крестоносец"] = "Крестоносец.png";
            fileMapping["Могильная воровка"] = "Могильная Воровка.png";
            fileMapping["Мушкетер"] = "Мушкетёр.png";
            fileMapping["Наемник"] = "Наёмник.png";
            fileMapping["Оккультист"] = "Оккультист.png";
            fileMapping["Прокаженный"] = "Прокажённый.png";
            fileMapping["Дрессировщик"] = "Псарь.png";
            fileMapping["Разбойник"] = "Разбойник.png";
            fileMapping["Флагеллант"] = "Самобичеватель.png";
            fileMapping["Чумной доктор"] = "Чумной Доктор.png";
            fileMapping["Шут"] = "Шут.png";
            fileMapping["Щитоломка"] = "Щитолом.png";
        }

        public static Image GetIcon(string heroName)
        {
            if (string.IsNullOrEmpty(heroName)) return null;

            if (loadedIcons.TryGetValue(heroName, out Image cachedImg))
            {
                return cachedImg;
            }

            if (fileMapping.TryGetValue(heroName, out string fileName))
            {
                string fullPath = Path.Combine(iconsFolderPath, fileName);

                if (File.Exists(fullPath))
                {
                    try
                    {
                        Image img = Image.FromFile(fullPath);
                        loadedIcons[heroName] = img;
                        return img;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            return null;
        }
    }
}