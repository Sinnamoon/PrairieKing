using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GunController 

{
    public PlayerController playerMovementController;


    // Start is called before the first frame update
    //implement bullet speed 
    public float bulletSpeed = 10.0f;
    public float maxSpeed = 10.0f;
    public Bullet bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0f;

    

    public void Fire(Vector2 directionToShoot)
    { 
        if (Time.time > nextFire)
        {            
            var bullet = SimpleSpawner.Spawner(playerMovementController.transform.position, bulletPrefab);
            bullet.Shoot(directionToShoot, bulletSpeed);
            nextFire = Time.time + fireRate;
            // GameObject bulletClone = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            // bulletClone.GetComponent<Rigidbody2D>().velocity = bulletClone.transform.up * bulletSpeed;
        }
    }

}
