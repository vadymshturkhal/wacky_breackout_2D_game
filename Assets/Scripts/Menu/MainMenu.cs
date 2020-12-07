using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Listens for the OnClick events for the main menu buttons
public class MainMenu : MonoBehaviour
{
    public void HandlePlayButtonOnClickEvent()
    {
        // Handles the on click event from the play button
        SceneManager.LoadScene("Gameplay");
    }

    // Handles the on click event from the quit button
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
}
