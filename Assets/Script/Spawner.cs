using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    public List<Wave> Waves;
    public float SpawnTime;
    public bool WaveRunTime;
    public Enemy_PathNode FirstNode;

    public void Start(){
        for (int i = 0; i < Waves.Count; i++){
            Waves[i] = Instantiate(Waves[i]);
        }
        StartWave();
    }

    public void StartWave(){
        WaveRunTime = true;
        SpawnTime = Time.time;
    }

    public void Update(){
        if (WaveRunTime){
            if (SpawnTime < Time.time && !Waves[0].Empty()){
                var newEnemy = Instantiate(Waves[0].GetTopMostEnemy(), transform.position, Quaternion.identity);
                SpawnTime += Waves[0].GetTopMostDelay();
                Waves[0].Pop();
                newEnemy.GetComponent<Enemy>().Target = FirstNode;
            }else  if (Waves[0].Empty()){
                var anyEnemy = FindAnyObjectByType<Enemy>();
                if (anyEnemy == null){
                    WaveRunTime = false;
                    // Potentielles Scoresystem wäre addbar
                    Waves.RemoveAt(0);
                }
            } 
        }
    }
}
