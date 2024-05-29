using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public HealthBar healthBar;
    public GameObject player;
    public Renderer rend;

    private float currentHealth;
    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }
    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            StartCoroutine(Dead());
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }
    public void HealPlayer(float amount)
    {
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);
    }
    private void Die()
    {   
    }
    IEnumerator Dead()
    {
        Debug.Log("dead");
        //player.SetActive(false);
        yield return new WaitForSeconds(1);
        Debug.Log("respawn");
        player.transform.position = new Vector3(129.08f, 6.31f, 59.2f);
        currentHealth = maxHealth;
        healthBar.SetSlider(maxHealth);
        //player.SetActive(true);
    }
}