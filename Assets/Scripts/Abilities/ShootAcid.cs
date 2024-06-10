using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAcid : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileForce = 20f;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    [Header("Crosshair")]
    public RectTransform crosshair;

    private Camera playerCam;

    private void Start()
    {
        playerCam = Camera.main;
    }

    private void Update()
    {
        Aim();

        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextFireTime)
        {
            Shoot();
            FindObjectOfType<AudioManager>().PlayAudio("ShootAcid");
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Aim()
    {
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPoint = hit.point;
            Vector3 direction = (targetPoint - firePoint.position).normalized;
            firePoint.forward = direction;

            if (crosshair)
            {
                crosshair.position = Input.mousePosition;
            }
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
    }
}
