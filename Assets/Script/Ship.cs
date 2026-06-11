using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour{
    public ShipStats Stats;
    private InputAction _moveAction;
    private InputAction _shootAction;
    /*TODO
    shoot
     */
    void Start(){
        _moveAction = InputSystem.actions.FindAction("Move");
        _shootAction = InputSystem.actions.FindAction("Attack");
    }
    
    void Update(){
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue.x * Stats.Speed * Time.deltaTime, 0, moveValue.y * Stats.Speed * Time.deltaTime);
        Vector2 shootValue = _shootAction.ReadValue<Vector2>(); // TODO
        
    }
}
