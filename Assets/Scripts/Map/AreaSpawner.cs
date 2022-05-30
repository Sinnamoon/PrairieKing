using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BoxCollider2D))]
public class AreaSpawner : MonoBehaviour
{
     BoxCollider2D bc;
     Vector2 cubeSize;
     Vector2 cubeCenter;
 
 
     private void Awake()
     {
        bc = GetComponent<BoxCollider2D>();

        Transform cubeTrans = bc.GetComponent<Transform>();
        cubeCenter = cubeTrans.position;
 
        // Multiply by scale because it does affect the size of the collider
        cubeSize.x = cubeTrans.localScale.x * bc.size.x;
        cubeSize.y = cubeTrans.localScale.y * bc.size.y;
     }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255f, 255f, 0, 0.9f);
        Gizmos.DrawCube(transform.position, cubeSize * 2);
    }



    public Vector2 GetRandomPosition()
     {
         // You can also take off half the bounds of the thing you want in the box, so it doesn't extend outside.
         // Right now, the center of the prefab could be right on the extents of the box
         Vector2 randomPosition = new Vector2(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), Random.Range(-cubeSize.y / 2, cubeSize.y / 2));
 
         return cubeCenter + randomPosition;
     }
}