using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeEvent();
            print("Buggy Esc without event");
        }
    }

    // Unpause game and destroy menu
    public void ResumeEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }


    // Unpause, destroy and go to "MainMenu"
    public void QuitEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
