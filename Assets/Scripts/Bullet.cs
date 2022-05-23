using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator FlyingBullet(Vector3 dirToFly, float bulletSpeed) //timer for bullet life 
    {
        float timer = 0f;
        float timerLifeMax = 10.0f;

        while (timer < timerLifeMax)
        {
            timer += Time.deltaTime;
            rigidbody2D.velocity = (dirToFly * bulletSpeed);
            yield return null;

        }
        Debug.Log("urmom is flying");
        Destroy(gameObject);
    }

    public void Shoot(Vector3 dirToFly, float bulletSpeed)
    {
        Debug.Log("dmitri is flying"+ dirToFly);

        StartCoroutine(FlyingBullet(dirToFly, bulletSpeed));
    }


}

