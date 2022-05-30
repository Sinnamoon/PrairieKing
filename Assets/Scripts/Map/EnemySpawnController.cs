using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField]
    bool isActivated = true;

    public Enemy enemyPrefab;
    public List<AreaSpawner> Areas = new List<AreaSpawner>();
    public PlayerController Player { get; set; }
    
    public void SpawnEnemy ()
    {
        if (!isActivated)
            return;
       
        Enemy newEnemy = SimpleSpawner.Spawner(Areas[ Random.Range(0, Areas.Count)].GetRandomPosition(),enemyPrefab);
        // () = skobuchski ?
        // ( = skobuchska ?
        
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