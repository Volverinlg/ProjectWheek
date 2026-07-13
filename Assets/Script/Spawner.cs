using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour{
     public GameObject Boss;
     [SerializeField] private float _spawnTimer;
     private readonly float _spawnRadius = 5f;
     public List<GameObject> Prefabs = new();
     [SerializeField] private int _maxEnemies;
     public int _currentEnemies;
     public Enemy_PathNode Target;

     public void Start(){
         InvokeRepeating(nameof(SpawnEnemy),_spawnTimer, _spawnTimer);
         SpawnBoss();
         //var foundEnemy = Object.FindObjectsByType(typeof(Enemy));
     }

     public void SpawnEnemy(){
         if (_currentEnemies >= _maxEnemies){
             return;
         }
         Vector2 randomOffset = Random.insideUnitCircle * _spawnRadius;
         Vector3 spawnPos = transform.position + new Vector3(randomOffset.x, 0,0);
         GameObject prefab = Prefabs[Random.Range(0, Prefabs.Count)];
         GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);
         _currentEnemies++;
         Enemy enemyScript = enemy.GetComponent<Enemy>();
         enemyScript.Target = Target;
         enemyScript.onDeath += () => _currentEnemies--;
         Prefabs.Clear();
         if (Prefabs.Count <= 0){
             Instantiate(Boss, transform.position, Quaternion.identity);
         }
     }

     public void SpawnBoss(){
        /* if(Time.time >= 10){ 
             Instantiate(Boss, transform.position, Quaternion.identity);
         }*/
        
     }
}

































