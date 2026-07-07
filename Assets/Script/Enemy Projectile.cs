using System;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour{
    public float RemainingLifeTime;
    public float Speed;
    public int Power;
    
   public void FixedUpdate(){
        LifeTimeHandler();
        float distanceThisFrame = Speed * Time.deltaTime;
        bool hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit,
            distanceThisFrame + Single.Epsilon, LayerMask.GetMask("Player"));
        if (hasHit){
            var shipComponent = hit.collider.GetComponent<Ship>();
            shipComponent?.GetDämätsch(Power); 
            Destroy(gameObject);
        }
        transform.position += transform.forward * distanceThisFrame;
    }

    public void LifeTimeHandler(){
        if (RemainingLifeTime <= 0){
            Destroy(gameObject);
        }
        RemainingLifeTime -= Time.deltaTime;
    }
}
