using UnityEngine;
using UnityEngine.Events;

public class Vererbung : MonoBehaviour{
    public EnemyStats Stats;
    public static readonly UnityEvent Win = new();
   [SerializeField] private bool _isBoss;
    
    public Ship MyTarget(){
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
    
    public void Shoot(Ship Target){
        Stats.FireRate -= Time.deltaTime;
        if (Stats.FireRate > 0){
            return;
        }
        Stats.FireRate = 1 / Mathf.Max(Stats.FireRate, 0.001f);
        var newProjectile = Instantiate(Stats.Projectile, transform.position, Quaternion.identity);
        var projectilePos = newProjectile.transform.position;
        projectilePos.y = Target.transform.position.y;
        newProjectile.transform.position = projectilePos;
        newProjectile.transform.LookAt(Target.transform.position);
    }

    public void GetDämätsch(int Dämätsch){
        int WouldBeHealth = Stats.HP - Dämätsch;
        if (WouldBeHealth < 0){
            WouldBeHealth = 0;
        }
        if (WouldBeHealth == 0){ 
            Destroy(gameObject);
            if (_isBoss){
                Win.Invoke();
            }
        }
        Stats.HP = WouldBeHealth;
    }
}
