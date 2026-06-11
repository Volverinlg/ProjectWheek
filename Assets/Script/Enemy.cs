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

    public void Shoot(Enemy Target){
        var newProjectile = GameObject.Instantiate(Stats.Projectile, transform.position, Quaternion.identity);
        var projectilePos = newProjectile.transform.position;
        projectilePos.y = Target.transform.position.y;
        newProjectile.transform.position = projectilePos;
        newProjectile.transform.LookAt(Target.transform.position);

       // _attackCooldown = 1 / Mathf.Max(Stats.Firerate, 0.001f); erst rein nehm wenn attaccooldown & firerate ne sache sind
    }
    
    public void DealDamgur(int incomeDMG){
        int WouldBeHealth = _currenthealth - incomeDMG;
        if (WouldBeHealth < 0){
            WouldBeHealth = 0;
        }
        if (WouldBeHealth == 0){
            Destroy(gameObject);
            //TODO AddScore kommt aber erst am ende als kleine spielerei
            return;
        }
        _currenthealth = WouldBeHealth;
    }
}
