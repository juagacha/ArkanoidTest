using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject startPanel; //panel inicio
    [SerializeField] private GameObject pausePanel; //panel pausa
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Continue()
    {
        pausePanel.SetActive(false);
        GameManager.Instance.SetGameActive();
    }

    public void GoStartPanel()
    {
        startPanel.SetActive(true);
        GameManager.Instance.SetGameOver();
        AudioManager.Instance.StopMusic();
    }
}
