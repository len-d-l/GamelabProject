using UnityEngine;

public class AcidBullet : MonoBehaviour
{
    public float damage;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().TakeDamage((int)damage);
            Destroy(gameObject);
        }
    }
}

