using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject GamePannel; //panel juego
    [SerializeField] private GameObject startPanel;
    [SerializeField] private AudioClip audioBGS; //audio de la escena
    [SerializeField] private List<LevelClass> levelList = new List<LevelClass>() ;
    [SerializeField] private Sprite plateCompete;
    [SerializeField] private Sprite plateCracked;
    [SerializeField] private Sprite plateBreak;
    [SerializeField] private GameObject LevelController;
    private LevelController levelcont;

    [SerializeField] private int numberMaxLevel = 2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        levelcont = LevelController.GetComponent<LevelController>();
        if (audioBGS != null)
        {
            AudioManager.Instance.PlayMusic(audioBGS);
        }
    }

    public void GoLevel( int level)
    {
        GamePannel.SetActive(true);
        this.gameObject.SetActive(false);
        AudioManager.Instance.PlayEndMusic(audioBGS);
        GameManager.Instance.SetGameActive();
        GameManager.Instance.SetNewLife(true);
        SceneManager.LoadScene(level);
        startPanel.SetActive(false);
    }

    private void FillInfoLevel() 
    {
        // para cda elemento en la lista colocar los platos segun porcentaje
    }

    private void OnDisable()
    {
        AudioManager.Instance.PlayEndMusic(audioBGS);
    }
}
