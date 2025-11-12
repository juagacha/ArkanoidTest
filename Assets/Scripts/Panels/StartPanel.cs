
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameObject LevelPannel; //panel niveles
    [SerializeField] private AudioClip audioBGS; //audio de la escena

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (audioBGS != null) 
        {
            AudioManager.Instance.PlayMusic(audioBGS);
        }
        
    }

    private void OnDisable()
    {
        AudioManager.Instance.PlayEndMusic(audioBGS);
    }

    public void GoLevelPanel()
    {
        LevelPannel.SetActive(true);
        this.gameObject.SetActive(false);
        AudioManager.Instance.PlayEndMusic(audioBGS);
    }


    /*public void QuitButton() // colocar si cambia plataforma
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }*/

}
