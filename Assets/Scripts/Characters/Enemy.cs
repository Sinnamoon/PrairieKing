using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    [Range(0.01f, 2f)]
    private float speedOfMoveing = 1;

    [SerializeField]
    [Range(0.01f, 2f)]
    private float timeToUpdatePath = 1f;
    public void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)//player layer 6
        {
            collision.gameObject.GetComponent<PlayerController>().Die();
        }

        if (collision.gameObject.layer == 7) //bullet layer 7
        {
            Die();
        }
    }

    public IEnumerator FollowPlayer(PlayerController player)
    {
        WaitForSeconds pathTimerUpdate = new WaitForSeconds(timeToUpdatePath);

        while (this != null && gameObject != null)
        {
            if (player == null)
            {
                yield break;
            }
            //follow the player       
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            rigidbody2D.velocity = direction * speedOfMoveing;
            yield return pathTimerUpdate;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}