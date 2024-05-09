using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public EnemyAi2 EnemyAIPrefabs;
    public PlayerController player;
    public List<Transform> targetPoint;

    public int enemiesMaxCount = 5;
    public float ReloadSpawn = 5;
    public float increaseEniumeaCountDelay = 30;

    private List<Transform> _spawnPoints;
    private List<EnemyAi2> _enemies;

    private float _timeLastSpawned;

    private void Start()
    {
        _spawnPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<EnemyAi2>();

        Invoke("IncreaseEnemiesMaxCount", increaseEniumeaCountDelay);
    }

    private void IncreaseEnemiesMaxCount() { 
        enemiesMaxCount++;
        Invoke("IncreaseEnemiesMaxCount", increaseEniumeaCountDelay);
    }

    private void Update()
    {
        for (var i = 0; i < _enemies.Count; i++) {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }

        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < ReloadSpawn) return;

        CreateEnemy();
    }

    void CreateEnemy() { 
        var enemy = Instantiate(EnemyAIPrefabs);
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
        enemy.player = player;
        //enemy.targetPoint = targetPoint;
        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
    }
}
