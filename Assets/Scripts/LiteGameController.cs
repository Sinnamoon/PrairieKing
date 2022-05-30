using System.Linq;
using UnityEngine;
using Assets.Scripts.UI;
using static LiteEvents;
using System.Collections;
using System.Collections.Generic;

public class LiteGameController : MonoBehaviour
{
    public PlayerController playerPrefab;
    public EnemySpawnController enemySpawnController;
    public UIController uIController;
    public MenuScreen menuScreen;

    [Space]
    [Range(10f, 60f)]
    public float waveSecond = 10f;

    private void OnEnable()
    {
        OnPlayerDeadCallback += OnPlayerDead;
        OnButtonPressedPlay += GameRestart;
        OnButtonPressedContinue += GameContunie;
        OnEscapeButtonPressed += GamePause;
    }

    private void OnDisable()
    {
        OnPlayerDeadCallback -= OnPlayerDead;
        OnButtonPressedPlay -= GameRestart;
        OnButtonPressedContinue -= GameContunie;
        OnEscapeButtonPressed -= GamePause;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        menuScreen.Show();
    }

    private void GameRestart()
    {
        Time.timeScale = 1;
        menuScreen.Hide();

        uIController.TimerStart(waveSecond);

        //kill player if he's exsit
        var player = FindObjectOfType<PlayerController>();
        if (player != null)
            Destroy(player.gameObject);

        //kill all enemies if they're exist
        IEnumerable<Enemy> enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }

        enemySpawnController.Player = SimpleSpawner.Spawner<PlayerController>(Vector3.zero, playerPrefab);
        enemySpawnController.SpawnEnemy(10);
    }

    private void GamePause()
    {
        if(Time.timeScale != 0)
        {
            menuScreen.Show();
            Time.timeScale = 0;
        }
        else
        {
            menuScreen.Hide();
            Time.timeScale = 1;
        }
    }

    private void GameContunie()
    {
        Time.timeScale = 1;
        menuScreen.Hide();
    }

    private void OnPlayerDead()
    {
        menuScreen.Show();        
    }

}
