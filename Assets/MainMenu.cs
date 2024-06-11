using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("CharacterSelection");
    }

    public void OpenAccount()
    {
        SceneManager.LoadSceneAsync("AccountPage");
    }

    public void OpenSettings()
    {
        SceneManager.LoadSceneAsync("Settings");
    }

    public void OpenControls()
    {
        SceneManager.LoadSceneAsync("Controls");
    }

    public void OpenGameModes()
    {
        SceneManager.LoadSceneAsync("GameMode");
    }

    public void ChooseGameMode()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
