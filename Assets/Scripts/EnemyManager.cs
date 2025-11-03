using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
[System.Serializable]
public class WaveDetails
{
    public int basicEnemy;
    public int fastEnemy;
}
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveDetails currentWaves;
    public float spawnCooldown;
    public float spawnTime;
    [SerializeField] private Transform respawn;
    [SerializeField] private List<GameObject> enemyToCreate;
    [Header("Enemy Prefab")]
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject fastEnemy;
    private void Start()
    {
        enemyToCreate = NewEnemyWave();

    }
    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <=0 && enemyToCreate.Count > 0)
        {
            CreateEnemy();
            spawnTime = spawnCooldown;
        }
    }

    private void CreateEnemy()
    {
        GameObject randomEnemy = GetRandomEnemy();
        GameObject newEnemy=  Instantiate(randomEnemy, respawn.position, Quaternion.identity);
    }
    private GameObject GetRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyToCreate.Count);
        GameObject enemyChoosen = enemyToCreate[randomIndex];
        enemyToCreate.Remove(enemyChoosen);
        return enemyChoosen;
    }
    private List<GameObject> NewEnemyWave()
    {
        List<GameObject> enemies = new List<GameObject>();
        for (int i = 0; i < currentWaves.basicEnemy; i++)
        {
            enemies.Add(basicEnemy);
        }
        for (int i = 0; i < currentWaves.fastEnemy; i++)
        {
            enemies.Add(fastEnemy);
        }
        return enemies;
    }
}
