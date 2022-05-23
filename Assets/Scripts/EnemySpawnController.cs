using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnController : MonoBehaviour
{
    public Enemy enemyPrefab;
    public List<AreaSpawner> Areas = new List<AreaSpawner>();
    
    public void SpawnEnemy ()
    {
        Enemy newEnemy = SimpleSpawner.Spawner(Areas[ Random.Range(0, Areas.Count)].GetRandomPosition(),enemyPrefab);
        // () = skobuchski ?
        // ( = skobuchska ?
        
    }
}