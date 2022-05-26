using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public void Awake(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)//player layer 6
        {
            Debug.Log("Player is dead");
            collision.gameObject.GetComponent<PlayerMovementController>().Die();
        }

        if (collision.gameObject.layer == 7) //bullet layer 7
        {
            Debug.Log("Bullet hit enemy");
            Die();
        }
    }

     public IEnumerator FollowPlayer(PlayerMovementController player)
    {
        while (gameObject !=null){
        if (player = null){
            yield break;
        }
        //follow the player       
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rigidbody2D.velocity = direction * 10;
        yield return null;
        }
    }
}