using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "Level")]


public class LevelClass : ScriptableObject // clase de todos los niveles
{
    public string levelName;
    public int levelLevel;
    public int maxPoints;
    public float percentComplete;
    public int numberOfPlate;
    
 
}
