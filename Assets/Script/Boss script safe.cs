using System;
using UnityEngine;

/*public class Bossscriptsafe : Enemy{
    public EnemyStats Stats;
    public float FireCoolDown;
    private int _currentHealth;

    public void Update(){ 
        Shoot(MyTarget());
    }

    private Ship MyTarget(){
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
        FireCoolDown -= Time.deltaTime;
        if (FireCoolDown > 0){
            return;
        }
        FireCoolDown = 1 / Mathf.Max(Stats.FireRate, 0.001f);
        var newProjectile = Instantiate(Stats.Projectile, transform.position, Quaternion.identity);
        var projectilePos = newProjectile.transform.position;
        projectilePos.y = Target.transform.position.y;
        newProjectile.transform.position = projectilePos;
        newProjectile.transform.LookAt(Target.transform.position);
    }

    public void GetDämätsch(int Dämätsch){
        int WouldBeHealth = _currentHealth - Dämätsch;
        if (WouldBeHealth < 0){
            WouldBeHealth = 0;
        }
        if (WouldBeHealth == 0){
            Destroy(gameObject);
            return;
        }
        _currentHealth = WouldBeHealth;
    }
}*/
