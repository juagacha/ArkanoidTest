using UnityEngine;

[CreateAssetMenu(fileName = "BrickScriptableObject", menuName = "Brick/Normal")]


public class Brick : ScriptableObject // clase de todos los ladrillos
{
    public BrickType brickType; // tipo de ladrillo
    public enum BrickType
    {
        basicBrick,
        glassBrick,
        brickBrick
    }
    public GameObject brickprefab;
    public int pointsToAdd;
    public int hitToDestroy;
    

    /*public void SumPoints( int marcador)
    {
        marcador += pointsToAdd;
    }*/


}