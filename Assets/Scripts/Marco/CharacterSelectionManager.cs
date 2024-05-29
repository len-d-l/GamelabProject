using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    // This variable will store the selected character
    public static string selectedCharacter;

    // Function to be called when PlayerA button is clicked
    public void SelectPlayerA()
    {
        selectedCharacter = "PlayerA";
        LoadLevelScene();
    }

    // Function to be called when PlayerB button is clicked
    public void SelectPlayerB()
    {
        selectedCharacter = "PlayerB";
        LoadLevelScene();
    }

    // Function to load the Level scene
    private void LoadLevelScene()
    {
        SceneManager.LoadScene("Level");
    }
}