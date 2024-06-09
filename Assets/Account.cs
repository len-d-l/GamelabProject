using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Account : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
