using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject{
    public float Speed;
    public int HP;
    public float Range;
    public float FireRate;
    public GameObject Projectile;
    
    
    
    
    
    //TODO eher ne spielerei als ein must have
    public int Score;
}
