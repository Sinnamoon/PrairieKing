using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiteGameController : MonoBehaviour
{
    public PlayerMovementController playerPrefab;
    public EnemySpawnController enemySpawnController;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnController.Player = SimpleSpawner.Spawner<PlayerMovementController>( position: new Vector3(0, 0, 0), playerPrefab);
        enemySpawnController.SpawnEnemy(numberOfEnemies: 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
