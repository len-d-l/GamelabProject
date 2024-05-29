using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerAPrefab;
    public GameObject playerBPrefab;

    void Start()
    {
        SpawnSelectedCharacter();
    }

    void SpawnSelectedCharacter()
    {
        GameObject playerToSpawn = null;

        if (CharacterSelectionManager.selectedCharacter == "PlayerA")
        {
            playerToSpawn = playerAPrefab;
        }
        else if (CharacterSelectionManager.selectedCharacter == "PlayerB")
        {
            playerToSpawn = playerBPrefab;
        }

        if (playerToSpawn != null)
        {
            Instantiate(playerToSpawn, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("No character selected or prefab not assigned.");
        }
    }
}