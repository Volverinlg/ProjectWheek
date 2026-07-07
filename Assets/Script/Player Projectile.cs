using System;
using UnityEngine;

public class Player_Projectile : MonoBehaviour{
   public float RemainingLifeTime;
   public float Speed;
   public int Power;


   public void FixedUpdate(){
      LifeTimeHandler();
      float distanceThisFrame = Speed * Time.deltaTime;
      bool hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit,
         distanceThisFrame + Single.Epsilon);
      if (hasHit){
         var enemyComponent = hit.collider.GetComponent<Vererbung>();
         enemyComponent?.GetDämätsch(Power); 
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
