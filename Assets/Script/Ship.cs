using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Ship : MonoBehaviour{
    public ShipStats Stats;
    private float _fireCoolDown = 1.3f;
    private int _currenthealth;

   // public Slider hpbar; wurde deaktiviert auf grund von bugs
    
    private InputAction _move;
    private InputAction _shoot;
    
    private Rigidbody rb;
    Vector3 myVector;

    public float maxDistance = 300f;
    private readonly Vector3 _boxSizeMultiplier = Vector3.one * 0.5f;
    private Collider col;
    private RaycastHit hit;
    private bool hitDetected;
  
    public Transform Muzzle1;
    public Transform Muzzle2;
    
    public static readonly UnityEvent Lose = new();
    
    void Start(){
        _move = InputSystem.actions.FindAction("Move");
        _shoot = InputSystem.actions.FindAction("Attack");
        
        _currenthealth = Stats.HP;
       // hpbar.value = _currenthealth; wurde deaktiviert auf grund von bugs
        
        col = GetComponent<Collider>();
    }
    
    void FixedUpdate(){
        Vector2 moveValue = _move.ReadValue<Vector2>();
        myVector = new Vector3(moveValue.y,0, moveValue.x); 
        rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + myVector * Stats.Speed * Time.deltaTime);

        Vector3 halfExtends = Vector3.Scale(transform.localScale, _boxSizeMultiplier);
        Vector3 origin = col.bounds.center;
        Vector3 direction = transform.forward;
        hitDetected = Physics.BoxCast(origin, halfExtends, direction, out hit, transform.rotation, maxDistance);
        
        

        if (hitDetected){
            Debug.Log("Hit : " + hit.collider.name);
        }
        
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
        //hpbar.value = _currenthealth; wurde deaktiviert auf grund von bugs
    }
}