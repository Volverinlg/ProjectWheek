using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour{
    public ShipStats Stats;
    private float _attackCoolDown;
    private int _currenthealth;
    private InputAction _move;
    private InputAction _shoot;
    public bool shoot;
    public Gun[] guns;
    /*TODO
    shoot
     */
    void Start(){
        _move = InputSystem.actions.FindAction("Move");
        _shoot = InputSystem.actions.FindAction("Attack");
        Gun[] guns = GetComponentsInChildren<Gun>();
        
        _currenthealth = Stats.HP;

    }
    
    void Update(){
        Vector2 moveValue = _move.ReadValue<Vector2>();
        transform.Translate(moveValue.x * Stats.Speed * Time.deltaTime,0,moveValue.y * Stats.Speed * Time.deltaTime);
        if (_shoot.WasPressedThisFrame()){
            Debug.Log("Shoot input pressed");
            foreach (Gun gun in guns){
                gun.Shoot();
            }
        }
        
        _attackCoolDown -= Time.deltaTime;
        
    }
    
    /*public void Shoot(){

        
        _attackCoolDown = 1 / Mathf.Max(Stats.FireRate, 0.001f); 
    }*/
    
    public void Dämätsch(int Dämätsch){
        int WouldBeHealth = _currenthealth - Dämätsch;
        if (WouldBeHealth < 0){
            WouldBeHealth = 0;
        }
        if (WouldBeHealth == 0){
            Destroy(gameObject);
            //TODO AddScore kommt aber erst am ende als kleine spielerei
            return;
        }
        _currenthealth = WouldBeHealth;
    }

}
