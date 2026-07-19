using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DarkestDungeonInfo
{
    public static class SaveManager
    {
        public static void SaveData(BindingList<GameWeek> weeks, string runSuffix = "")
        {
            string fileName = string.IsNullOrWhiteSpace(runSuffix) ? "save.dat" : $"save_run_{runSuffix}.dat";

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    formatter.Serialize(stream, weeks);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        public static bool LoadData(BindingList<GameWeek> weeks, string runSuffix = "")
        {
            string fileName = string.IsNullOrWhiteSpace(runSuffix) ? "save.dat" : $"save_run_{runSuffix}.dat";

            if (!File.Exists(fileName))
            {
                return false;
            }

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    var deserializedWeeks = formatter.Deserialize(stream) as BindingList<GameWeek>;

                    if (deserializedWeeks != null)
                    {
                        weeks.Clear();
                        foreach (var week in deserializedWeeks)
                        {
                            weeks.Add(week);
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ошибка при загрузке: {ex.Message}");
            }

            return false;
        }
    }
}