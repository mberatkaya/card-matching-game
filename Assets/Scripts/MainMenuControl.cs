using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    
    public GameObject ExitPanel;

    private void Start()
    {
        if (Time.timeScale == 0 )
        {
            Time.timeScale = 1;
        }
        
    }
    public void ExitGame()
    {
        ExitPanel.SetActive(true);
    }

    public void Feedback(string Answer)
    {
        if (Answer == "Evet")
        {
            Application.Quit();
        }
        else
        {
            ExitPanel.SetActive(false);
        } 
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
}
