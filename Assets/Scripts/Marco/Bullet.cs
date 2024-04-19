using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float damage;

    private void Start()
    {
        //Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.tag);
            Debug.Log(damage);
            other.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}