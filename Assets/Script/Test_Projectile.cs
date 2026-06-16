using System;
using UnityEngine;

public class Test_Projectile : MonoBehaviour{
  /*public Vector2 Direction = new Vector2(1,0);
   public float Speed = 5;
   public Vector2 Velocity;

   public void Start(){
      Destroy(gameObject, 3);
   }

   public void Update(){
      Velocity = Direction * Speed;
   }

   public void FixedUpdate(){
      Vector2 pos = transform.position;
      pos += Velocity * Time.fixedDeltaTime;
      transform.position = pos;
   } 
  public Vector2 Direction;
  public float Speed = 5f;

  void Start()
  {
     Destroy(gameObject, 3f);
  }

  void FixedUpdate()
  {
     transform.position += (Vector3)(Direction * Speed * Time.fixedDeltaTime);
  }*/
  
  public Rigidbody rb;
  public float Speed = 10f;

  void Start()
  {
     rb = GetComponent<Rigidbody>();
     Destroy(gameObject, 3f);
  }

  void FixedUpdate()
  {
     rb.linearVelocity = Vector3.right * Speed;
  }
}
