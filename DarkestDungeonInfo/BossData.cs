using System.Collections.Generic;

namespace DarkestDungeonInfo
{
    public class BossEntry
    {
        public string Name { get; set; }
        public int Tier { get; set; }
    }

    public static class BossData
    {
        public static Dictionary<string, List<BossEntry>> GetBosses()
        {
            return new Dictionary<string, List<BossEntry>>
            {
                { "Руины", new List<BossEntry> {
                    new BossEntry { Name = "Ученик Некромант", Tier = 1 }, new BossEntry { Name = "Звучный Пророк", Tier = 1 },
                    new BossEntry { Name = "Некромант", Tier = 3 }, new BossEntry { Name = "Громогласный Пророк", Tier = 3 },
                    new BossEntry { Name = "Великий Некромант", Tier = 5 }, new BossEntry { Name = "Бормочущий Пророк", Tier = 5 }
                }},
                { "Заповедник", new List<BossEntry> {
                    new BossEntry { Name = "Старая Ведьма", Tier = 1 }, new BossEntry { Name = "8-Фунтовая Пушка", Tier = 1 },
                    new BossEntry { Name = "Ведьма", Tier = 3 }, new BossEntry { Name = "12-Фунтовая Пушка", Tier = 3 },
                    new BossEntry { Name = "Жуткая Ведьма", Tier = 5 }, new BossEntry { Name = "16-Фунтовая Пушка", Tier = 5 }
                }},
                { "Чаща", new List<BossEntry> {
                    new BossEntry { Name = "Свиной Принц", Tier = 1 }, new BossEntry { Name = "Рудиментарная Плоть", Tier = 1 },
                    new BossEntry { Name = "Свиной Король", Tier = 3 }, new BossEntry { Name = "Нестабильная Плоть", Tier = 3 },
                    new BossEntry { Name = "Свиной Бог", Tier = 5 }, new BossEntry { Name = "Бесформенная Плоть", Tier = 5 }
                }},
                { "Бухта", new List<BossEntry> {
                    new BossEntry { Name = "Сирена", Tier = 1 }, new BossEntry { Name = "Промокшая Команда", Tier = 1 },
                    new BossEntry { Name = "Обольстительная Сирена", Tier = 3 }, new BossEntry { Name = "Подводная Команда", Tier = 3 },
                    new BossEntry { Name = "Соблазнительная Сирена", Tier = 5 }, new BossEntry { Name = "Утонувшая Команда", Tier = 5 }
                }}
            };
        }
    }
}