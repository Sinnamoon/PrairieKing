using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController 

{
    private readonly PlayerMovementController playerMovementController;
    public GunController(PlayerMovementController playerMovementController)
    {
        this.playerMovementController = playerMovementController;
    }

    // Start is called before the first frame update
    //implement bullet speed 
    public float bulletSpeed = 1000.0f;
    public float maxSpeed = 10.0f;
    public GameObject bullet;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    
    void Start()
    {
        
    }

    void Update()
    { 
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            // bulletClone.GetComponent<Rigidbody2D>().velocity = bulletClone.transform.up * bulletSpeed;
        }

        
    }

}
