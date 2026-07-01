using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Objects/Wave")]
public class Wave : ScriptableObject{
    public List<WaveBatches> Batches;

    public GameObject GetTopMostEnemy(){
        return Batches[0].EnemyType;
    }

    public float GetTopMostDelay(){
        return Batches[0].DelayPerEnemy;
    }
    
    public void Pop(){
        WaveBatches waveBatch = Batches[0];
        waveBatch.Amount -= 1;
        if (waveBatch.Amount <= 0){
            Batches.RemoveAt(0);
        }
        else{
            Batches[0] = waveBatch;
        }
    }
        public bool Empty(){
            return Batches.Count <= 0;
        }
    
}
