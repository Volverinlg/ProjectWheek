using UnityEngine;
using UnityEngine.Events;

public class Enemy_DMG_Handling : MonoBehaviour{
    public EnemyStats Stats;
    private float _fireCoolDown = 3f;
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
    
    public void Shoot(Ship Ziel){
        _fireCoolDown -= Time.deltaTime;
        if (_fireCoolDown > 0){
            return;
        }
        
        var newProjectile = Instantiate(Stats.Projectile, transform.position, Quaternion.identity);
        var projectilePos = newProjectile.transform.position;
        projectilePos.y = Ziel.transform.position.y;
        newProjectile.transform.position = projectilePos;
        newProjectile.transform.LookAt(Ziel.transform.position);
        _fireCoolDown = 1 / Mathf.Max(Stats.FireRate, 0.001f);
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
