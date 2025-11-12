using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    [SerializeField] private GameObject helpPanel; //panel ayuda

    public void ExitPanel()
    {
        helpPanel.SetActive(false);
        GameManager.Instance.SetGameActive();
    }

}
