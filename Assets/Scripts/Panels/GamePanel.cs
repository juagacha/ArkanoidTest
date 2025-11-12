using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GamePanel : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; //panel pausa
    [SerializeField] private GameObject helpPanel; //panel ayuda
    [SerializeField] private TextMeshProUGUI textNameLevel;
    [SerializeField] private TextMeshProUGUI textPoints;

    [SerializeField] List<GameObject> livesActives = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < livesActives.Count; i++)
        {
            livesActives[i].SetActive(true);
        }

    }

    public void InactiveLives(int live) 
    {
        livesActives[live].SetActive(false);   
    }


    public void SetLevelName(string name) 
    {
        textNameLevel.text = name;
    }

    public void SetPoints(int points)
    {
        Debug.Log(points);
        textPoints.text = "Puntos: " + points;
    }

    public void GoHelpPanel()
    {
        helpPanel.SetActive(true);
        GameManager.Instance.SetGamePaused();
    }

    public void GoPausePanel()
    {
        pausePanel.SetActive(true);
        GameManager.Instance.SetGamePaused();
    }
}
