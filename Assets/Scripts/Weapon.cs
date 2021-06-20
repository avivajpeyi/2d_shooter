using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Camera cam;

    [Tooltip("GameObject that acts as the shot projectile")]
    public GameObject projectile;

    [Tooltip("Location to shoot projectile from")]
    public Transform shotPoint;

    public float timeBetweenShots = 0.5f;
    private float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeapon();
        ShotLogic();
    }

    void RotateWeapon()
    {
        Vector2 direction =
            cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion
            rotation =
                Quaternion.AngleAxis(angle - 90, Vector3.forward); // forward AKA z-axis
        transform.rotation = rotation;
    }

    void ShotLogic()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}