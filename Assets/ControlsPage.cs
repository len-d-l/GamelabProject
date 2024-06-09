using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsPage : MonoBehaviour
{
    public void OpenBee()
    {
        SceneManager.LoadSceneAsync("BeeInfo");
    }

    public void OpenBeetle()
    {
        SceneManager.LoadSceneAsync("BeetleInfo");
    }

    public void GoBack()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
