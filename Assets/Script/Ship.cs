using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour{
    // TODO endboss welcher getriggert wird sobald die 3-5min abgelaufen sind, win condition ist gleichzeitig gebunden an den Boss
    public ShipStats Stats;
    private float _fireCoolDown = 1.3f;
    private int _currenthealth;
   
    private InputAction _move;
    private InputAction _shoot;
    
    public Transform Muzzle1;
    public Transform Muzzle2;
    
    public static readonly UnityEvent Lose = new();
    
    void Start(){
        _move = InputSystem.actions.FindAction("Move");
        _shoot = InputSystem.actions.FindAction("Attack");
        
        _currenthealth = Stats.HP;
    }
    
    void Update(){
        Vector2 moveValue = _move.ReadValue<Vector2>();
        transform.Translate(moveValue.x * Stats.Speed * Time.deltaTime,0,moveValue.y * Stats.Speed * Time.deltaTime);
        _fireCoolDown -= Time.deltaTime;
        if (_shoot.IsPressed() && _fireCoolDown <= 0){
           Shoot();
           _fireCoolDown = 1/Stats.FireRate;
        }
    }
    
    public void Shoot(){
        Instantiate(Stats.Projectile, Muzzle1.position, Muzzle1.rotation);
        Instantiate(Stats.Projectile, Muzzle2.position, Muzzle2.rotation);
    }
    
    public void GetDämätsch(int Dämätsch){ // :}
        int WouldBeHealth = _currenthealth - Dämätsch;
        if (WouldBeHealth < 0){
            WouldBeHealth = 0;
        }
        if (WouldBeHealth == 0){
            Destroy(gameObject);
            Lose.Invoke();
            return;
        }
        _currenthealth = WouldBeHealth;
    }
}