using UnityEngine;

public class Gun : MonoBehaviour{
    public Test_Projectile Bullet;

    public void Shoot(){
        Debug.Log("Bullet spawned");
        Instantiate(Bullet, transform.position, Quaternion.identity);
    }
}
