using System;
using UnityEngine;

public class Projectile : MonoBehaviour{
    private float Remaininglifetime;
    public float Speed;
    public int Power;
    /*TODO
     dmg
     */

    void Update(){
        LifeTimeHandler();
        float distanceThisFrame = Speed * Time.deltaTime;
        bool hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit,
            distanceThisFrame + Single.Epsilon, LayerMask.GetMask("Low Enemie"));
        if (hasHit){
            var enemyComponent = hit.collider.GetComponent<Enemy>();
            enemyComponent?.DealDamgur(Power); // TODO dd
            Destroy(gameObject);
        }
    }

    public void LifeTimeHandler(){
        if (Remaininglifetime <= 0){
            Destroy(gameObject);
        }
        Remaininglifetime -= Time.deltaTime;
    }
}
