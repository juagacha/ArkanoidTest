using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject GamePannel; //panel juego
    [SerializeField] private AudioClip audioBGS; //audio de la escena
    [SerializeField] private List<LevelClass> levelList = new List<LevelClass>() ;
    [SerializeField] private Sprite plateCompete;
    [SerializeField] private Sprite plateCracked;
    [SerializeField] private Sprite plateBreak;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        // SceneManager.LoadScene(level);
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
