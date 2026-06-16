using UnityEngine;

public class Enemy : MonoBehaviour{
    private int _currenthealth;
    public EnemyStats Stats;
    public Enemy_PathNode Target;
    private float _attackCooldown;
    
    
    /*TODO
     shoot
     */

    void Start(){
        _currenthealth = Stats.HP; // TODO
    }

    void Update(){
        MoveForward();
        CheckArrivale();

        _attackCooldown -= Time.deltaTime;
        var target = FirstTarget();
        if (_attackCooldown <= 0 && target){
            transform.LookAt(target.transform.position);
            //TODO Enumeral bei unity vorbeischauen um Infos darüber rein zu holen
            Shoot(target);
        }
        
    }

    private Ship FirstTarget(){
        var collidorsInRange = Physics.OverlapSphere(transform.position, Stats.Range);
        Ship targetCandidate = null;
        foreach (var collider in collidorsInRange){
            if (collider.GetComponent<Ship>() != null){
                targetCandidate = collider.GetComponent<Ship>();
                break;
            }
        }
        return targetCandidate;
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

    public void Shoot(Ship Target){
        var newProjectile = Instantiate(Stats.Projectile, transform.position, Quaternion.identity);
        var projectilePos = newProjectile.transform.position;
        projectilePos.y = Target.transform.position.y;
        newProjectile.transform.position = projectilePos;
        newProjectile.transform.LookAt(Target.transform.position);

       _attackCooldown = 1 / Mathf.Max(Stats.FireRate, 0.001f); 
    }
    
    public void Dämätsch(int Dämätsch){
        int WouldBeHealth = _currenthealth - Dämätsch;
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
