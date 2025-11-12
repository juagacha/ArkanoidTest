using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject StartPannel; //panel comienzo

    [Header("Controller")]
    [SerializeField] public bool isGameActive = false;
    [SerializeField] public bool isGamePaused = false;
    [SerializeField] public bool isGameOver = false;
    [SerializeField] public bool isNewLife = false;

    public bool newGame = true;
       

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (newGame)
        {
            StartPannel.SetActive(true);
        }
    }

    public bool GetGameActive() 
    {
        return isGameActive;
    }

    public void SetGameActive() 
    {
        isGameActive = true;
        isGamePaused = false;
        isGameOver = false;
        Time.timeScale = 1.0f;
    }

    public bool GetGamePaused()
    {
        return isGamePaused;
    }

    public void SetGamePaused()
    {
        isGameActive = false;
        isGamePaused = true;
        isGameOver = false;
        Time.timeScale = 0.0f;
    }

    public bool GetGameOver()
    {
        return isGameOver;
    }

    public void SetGameOver()
    {
        isGameActive = false;
        isGamePaused = false;
        isGameOver = true;
        Time.timeScale = 0.0f;
    }

    public bool GetNewLife()
    {
        return isNewLife;
    }

    public void SetNewLife( bool newLife)
    {
        isNewLife = newLife;
        Debug.Log("cambiado a " + newLife);
    }



}
