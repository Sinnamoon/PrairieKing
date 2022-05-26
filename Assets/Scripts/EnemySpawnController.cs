using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnController : MonoBehaviour
{
    public Enemy enemyPrefab;
    public List<AreaSpawner> Areas = new List<AreaSpawner>();
    public PlayerMovementController Player { get; set; }
    
    public void SpawnEnemy ()
    {
       
        Enemy newEnemy = SimpleSpawner.Spawner(Areas[ Random.Range(0, Areas.Count)].GetRandomPosition(),enemyPrefab);
        // () = skobuchski ?
        // ( = skobuchska ?
        Debug.Log(Player);
         StartCoroutine(newEnemy.FollowPlayer(Player));
    }

    public void SpawnEnemy(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    
}