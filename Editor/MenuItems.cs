using UnityEditor;

namespace MyLabyrinth
{
    public class MenuItems
    {
        [MenuItem("GeekBrains/Create Bonus")]
        private static void CreateBonus()
        {
            EditorWindow.GetWindow<CreateBonusWindow>(false, "Bonuses");
            
        }

        [MenuItem("GeekBrains/GeekBrains Example")]
        private static void GeekBrainsExample()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "GeekBrains");
        }
    }
}
