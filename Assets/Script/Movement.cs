using System;
using UnityEngine;

public class Movement : MonoBehaviour{
    public float Speed;
    //public EnemyStats Stats; WIP frage Oli wie ich EnemyStats unterschiedlich vergeben kann wenn es als Data gespeichtert ist
    public float SinCenterY;
    public float WaveHeight = 2;
    public float Frequenz = 0.5f;
    public bool invertieren;

    public void Start(){
        SinCenterY = transform.position.y;
    }

    public void FixedUpdate(){
        Vector3 pos = transform.position;
        pos.x -= Speed * Time.fixedDeltaTime;
        float sin = Mathf.Sin(pos.x * Frequenz) * WaveHeight;
        if (invertieren){
            sin *= -1;
        }
        pos.y = SinCenterY + sin;
        if (pos.x < -20){
            Destroy(gameObject);
        }
        transform.position = pos;
    }
}
