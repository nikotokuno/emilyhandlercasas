using System.Collections.Generic;

namespace emilyhandler.Domain.Static_Constants
{
    public static class KeywordList
    {
        public static Dictionary<string, string> Keywordlist = new Dictionary<string, string>()
        {
            {"Sleep", "Has_Slept"},
            {"Breakfast", "Cook"},
            {"Work", "Work"},
            {"Bathe", "Personal_Hygiene"},
            {"Cook", "Cook"},
            {"Eat", "Cook"},
            {"Relax", "Relax"},
            {"Take_Medecine", "has_taken_medecine"},
            {"Wash_Dishes", "Wash_Dishes"},
            {"Personal_Hygiene", "Personal_Hygiene"},
            {"Bed_Toilet_Transition", "Bed_Toilet_Transition"}
        };
    }
}
