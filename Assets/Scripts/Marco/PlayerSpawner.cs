using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerAPrefab;
    public GameObject playerBPrefab;
    public GameObject playerCPrefab;

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
        else if (CharacterSelectionManager.selectedCharacter == "PlayerC")
        {
            playerToSpawn = playerCPrefab;
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