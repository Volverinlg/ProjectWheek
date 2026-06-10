using UnityEngine;

public class Enemy : MonoBehaviour{
    private int _currenthealth;
    public EnemyStats Stats;
    public Enemy_PathNode Target;
    
    /*TODO
     shoot
     */

    void Start(){
        _currenthealth = Stats.HP; // TODO
    }

    void Update(){
        MoveForward();
        CheckArrivale();
    }

    public void MoveForward(){
        float step = Stats.Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);
    }

    public void CheckArrivale(){
        if (Vector3.Distance(transform.position, Target.transform.position) < 0.1f){
            if (Target.IsEnd){
                Destroy(gameObject);
            }
            else{
                Target = Target.next;
            }
        }
    }
}
