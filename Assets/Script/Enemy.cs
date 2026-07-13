using UnityEngine;

public class Enemy : Enemy_DMG_Handling{
    public Enemy_PathNode Target;
    
    public EMovement EMovement;
    public EShoot EShoot;
    
    private float _sinCenterY;
    private readonly float _waveHeight = 1f;
    private readonly float _frequenz = 1f;
    public bool invertieren;

    public System.Action onDeath;
    
    public void Start(){
        _sinCenterY = transform.position.z;
    }

    public void Update(){
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

    private void MoveForward(){
        if (Target == null){
            return;
        }
        var step = Stats.Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);
    }
    
    private void CheckArrivale(){    
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
    
    private void WellenReiter(){
        Vector3 pos = transform.position;
        pos.x -= Stats.Speed * Time.deltaTime;
        float sin = Mathf.Sin(pos.x * _frequenz) * _waveHeight;
        if (invertieren){
            sin *= -1;
        }
        pos.z = _sinCenterY + sin;
        if (pos.x < -20){
            Destroy(gameObject);
        }
        transform.position = pos;
    }
}
