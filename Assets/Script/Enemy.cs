using UnityEngine;

public class Enemy : MonoBehaviour{
    private int _currenthealth;
    public EnemyStats Stats;
    public Enemy_PathNode Target;
    public float FireCoolDown;
    
    public EMovement EMovement;
    public EShoot EShoot;
    
    public float SinCenterY;
    public float WaveHeight = 0.5f;
    public float Frequenz = 1f;
    public bool invertieren;
    
    
    void Start(){
        SinCenterY = transform.position.y;
        _currenthealth = Stats.HP; 
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
                Shoot(FirstTarget());
                break;
            case EShoot.noShoot:
                break;
        }
        
        
        
    }

    public void MoveForward(){
        float step = Stats.Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);
    }
    
    public void WellenReiter(){
        Vector3 pos = transform.position;
        pos.x -= Stats.Speed * Time.fixedDeltaTime;
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
    
    private Ship FirstTarget(){
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
    
    public void CheckArrivale(){    
        if (Vector3.Distance(transform.position, Target.transform.position) < 0.1f){
            if (Target.IsEnd){
                Destroy(gameObject);
            }
            else{
                Target = Target.next;
            }
        }
    }

    public void Shoot(Ship Target){
        if (FirstTarget() == null){
            return;
        }
        FireCoolDown -= Time.deltaTime; 
        FireCoolDown = 1 / Mathf.Max(Stats.FireRate, 0.001f);
        var newProjectile = Instantiate(Stats.Projectile, transform.position, Quaternion.identity);
        var projectilePos = newProjectile.transform.position;
        projectilePos.y = Target.transform.position.y;
        newProjectile.transform.position = projectilePos;
        newProjectile.transform.LookAt(Target.transform.position);
        
    }
    
    public void GetDämätsch(int Dämätsch){
        int WouldBeHealth = _currenthealth - Dämätsch;
        if (WouldBeHealth < 0){
            WouldBeHealth = 0;
        }
        if (WouldBeHealth == 0){
            Destroy(gameObject);
            return;
        }
        _currenthealth = WouldBeHealth;
    }

}
