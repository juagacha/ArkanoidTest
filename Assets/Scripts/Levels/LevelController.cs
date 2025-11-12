using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel; //panel juego
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] public int numberMaxOfLives = 3;
    [SerializeField] private GameObject newLifePrefab;
    [SerializeField] private GameObject PointsPrefab;
    private int numberOfLives = 0;
    public int score = 0;
    private GamePanel gamePannel;
    private EndGamePanel endgamePannel;
    public int numberMaxLevel = 2;
    private bool NewGame = false;

    [SerializeField] public LevelClass levelClass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamePannel = gamePanel.GetComponent<GamePanel>();
        endgamePannel = endGamePanel.GetComponent<EndGamePanel>();
        numberOfLives = numberMaxOfLives;
        InvokeRepeating("NewlifePowerUp", 10, 30);
        InvokeRepeating("ExtraPointsPowerUp", 15, 20);

    }

    public void BrickWasDestroyed(int point) 
    {
        score += point;
        gamePannel.SetPoints(score);
    }

    public void AddExtraPoints(int point)
    {
        score += point;
        gamePannel.SetPoints(score);
    }

    public void BallWasDestroyed(int count)
    {
        numberOfLives -= count;
        gamePannel.InactiveLives(numberOfLives);
        if (numberOfLives == 0) 
        {
            GameManager.Instance.SetGameOver();
            endgamePannel.SetPoints(score);
            SetMaxPoints();
            endgamePannel.SetMaxPoints(levelClass.maxPoints);
            endGamePanel.SetActive(true);
        }
    }

    private void SetMaxPoints() // asigna el maximo puntaje obtenido
    {
        if (levelClass.maxPoints > score) 
        {
            levelClass.maxPoints = score;
        }
    }

    public int GetNumberOfLives() //funcion que devuelve numro de vidas disponibles
    {
        return numberOfLives;
    }

    public void AddLife() //metodo que adiciona una vida
    {
        numberOfLives += 1;

    }
    public string GetNameLevel() //devuelve el nombre del nivel activo
    {
        return levelClass.name;
    }

    public int GetNumberLevel() // devuelve el numero del nivel activo
    {
        return levelClass.levelLevel;
    }

    private void NewlifePowerUp() 
    {
        Instantiate(newLifePrefab, Vector3.zero, Quaternion.identity);
    }
    private void ExtraPointsPowerUp() 
    {
        
        Instantiate(PointsPrefab, Vector3.zero, Quaternion.identity);
    }

}
