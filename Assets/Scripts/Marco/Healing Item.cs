using System.Collections;
using UnityEngine;
public class HealingItem : MonoBehaviour
{
    public float healAmount = 40f;
    public float respawnTime = 15f;

    public MeshRenderer medkitObjMesh;
    public Collider medkitObjColl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats plStats = other.GetComponent<PlayerStats>();

            if (plStats.currentHealth < plStats.maxHealth)
            {
                plStats.HealPlayer(healAmount);
                StartCoroutine(RespawnMedkit());
            }
        }
    }

    private IEnumerator RespawnMedkit()
    {
        FindObjectOfType<AudioManager>().PlayAudio("Medkit");
        medkitObjMesh.enabled = false;
        medkitObjColl.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        medkitObjMesh.enabled = true;
        medkitObjColl.enabled = true;
    }
}