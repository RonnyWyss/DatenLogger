using System.Collections.Generic;

namespace ZBW.PEAII_Nuget_DatenLogger.Repositories
{
    public class SeverityLevelComboBoxItems
    {
        public static List<string> SeverityLevel =>
            new List<string>
            {
                "Level 0 Error",
                "Level 1 Critical",
                "Level 2 Warning",
                "Level 3 Low",
                "Level 4",
                "Level 5"
            };
    }
}