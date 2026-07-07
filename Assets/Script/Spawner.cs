using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour{
    [SerializeField] private float _spawnTimer;
    [SerializeField] private float _spawnRadius = 5f;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private int _maxEnemies;
    [SerializeField] private int _currentEnemies;
    public Enemy_PathNode Target;

    public void Start(){
        InvokeRepeating(nameof(SpawnEnemy),_spawnTimer, _spawnTimer);
    }

    public void SpawnEnemy(){
        if (_currentEnemies >= _maxEnemies){
            return;
        }
        
        Vector2 randomOffset = Random.insideUnitCircle * _spawnRadius;
        Vector3 spawnPos = transform.position + new Vector3(randomOffset.x, 0,0);
        GameObject prefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];
        GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);
        _currentEnemies++;
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.Target = Target;
        enemyScript.onDeath += () => _currentEnemies--;
    }
    

   /* public void StopSpawning(){
        CancelInvoke();
    }*/
}