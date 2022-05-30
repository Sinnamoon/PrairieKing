using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime = 10f;

    public float bulletSpeed = 10f;
    private Rigidbody2D rigidbody2D;

    private void OnValidate()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D() {StopAllCoroutines(); Destroy(gameObject); }

    IEnumerator FlyingBullet(Vector2 dirToFly, float bulletSpeed, float lifeTime = default)
    {
        if (lifeTime != default)
            bulletLifeTime = lifeTime;

        float timer = 0f;

        Vector2 forceBullet = dirToFly * bulletSpeed;
        
        rigidbody2D.AddForce(forceBullet, ForceMode2D.Impulse);

        while (timer < bulletLifeTime)
        {
            timer += Time.deltaTime;
            //rigidbody2D.velocity = (dirToFly * bulletSpeed);
            yield return null;

        }
        Debug.Log("bullet destroyed");
        Destroy(gameObject);        
    }

    public void Shoot(Vector2 dirToFly, float bulletSpeed = default)
    {
        if (bulletSpeed != default)
            this.bulletSpeed = bulletSpeed;

        StartCoroutine(FlyingBullet(dirToFly, this.bulletSpeed));
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }


}

