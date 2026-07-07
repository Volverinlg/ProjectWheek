using UnityEngine;

public class Enemy : Vererbung{
    public Enemy_PathNode Target;
    
    public EMovement EMovement;
    public EShoot EShoot;
    
    public float SinCenterY;
    public float WaveHeight = 0.5f;
    public float Frequenz = 1f;
    public bool invertieren;

    public System.Action onDeath;
    
    void Start(){
        SinCenterY = transform.position.y;
    }

    void Update(){
        switch (EMovement){
            case EMovement.Waypoints:
                MoveForward();
                CheckArrivale();
                break;
            case EMovement.SineWave:
                WellenReiter();
                break;
        }
        switch (EShoot){
            case EShoot.Shoot:
                Shoot(MyTarget());
                break;
            case EShoot.noShoot:
                break;
        }
    }

    public void MoveForward(){
        if (Target == null){
            return;
        }
        float step = Stats.Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);
    }
    
    public void CheckArrivale(){    
        if (Vector3.Distance(transform.position, Target.transform.position) < 0.1f){
            if (Target.IsEnd){
                onDeath?.Invoke();
                Destroy(gameObject);
            }
            else{
                Target = Target.next;
            }
        }
    }
    
    public void WellenReiter(){
        Vector3 pos = transform.position;
        pos.x -= Stats.Speed * Time.deltaTime;
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
