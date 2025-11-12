using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject startPanel; //panel
    [SerializeField] private GameObject GamePannel; //panel juego
    [SerializeField] private GameObject LevelController;
    private LevelController levelcont;
    private int numberOfLevel;
    [SerializeField] private TextMeshProUGUI textPoints;
    [SerializeField] private TextMeshProUGUI textMaxPoints;

    void Start()
    {
        levelcont = LevelController.GetComponent<LevelController>();
    }

    public void StartPanel()
    {
        this.gameObject.SetActive(false);
        startPanel.SetActive(true);
        GameManager.Instance.SetGamePaused();
    }

    public void NextLevel()
    {
        if (levelcont.GetNumberLevel()+1>levelcont.numberMaxLevel)
        {
            this.gameObject.SetActive(false);
            startPanel.SetActive(true);
            GameManager.Instance.SetGamePaused();
        }
        else 
        {
            this.gameObject.SetActive(false);
            AudioManager.Instance.StopMusic();
            GameManager.Instance.SetGameActive();
            GameManager.Instance.SetNewLife(true);
            SceneManager.LoadScene(levelcont.GetNumberLevel());
            GamePannel.SetActive(true);
            startPanel.SetActive(false);
        }

    }

    public void Restart()
    {
        this.gameObject.SetActive(false);
        AudioManager.Instance.StopMusic();
        GameManager.Instance.SetGameActive();
        GameManager.Instance.SetNewLife(true);
        SceneManager.LoadScene(levelcont.GetNumberLevel()-1);
        GamePannel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void SetPoints(int points)
    {
        textPoints.text = "Puntaje: " + points;
    }

    public void SetMaxPoints(int points)
    {
        textMaxPoints.text = "Puntaje maximo: " + points;
    }

}
