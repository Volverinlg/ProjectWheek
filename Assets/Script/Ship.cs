using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour{
    public ShipStats Stats;
    private int _currenthealth;
   
    private InputAction _move;
    private InputAction _shoot;
   
    public GameObject Bullet_Type2;
    public Transform MuzzleTransform;
    
    public float FireCoolDown;
    
    
    void Start(){
        _move = InputSystem.actions.FindAction("Move");
        _shoot = InputSystem.actions.FindAction("Attack");
        
        _currenthealth = Stats.HP;
    }
    
    void Update(){
        Vector2 moveValue = _move.ReadValue<Vector2>();
        transform.Translate(moveValue.x * Stats.Speed * Time.deltaTime,0,moveValue.y * Stats.Speed * Time.deltaTime);
        FireCoolDown -= Time.deltaTime;
        if (_shoot.IsPressed() && FireCoolDown <= 0){
           Shoot();
           FireCoolDown = 1/Stats.FireRate;
        }
    }
    
    public void Shoot(){
        Instantiate(Bullet_Type2, MuzzleTransform.position, MuzzleTransform.rotation);
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
