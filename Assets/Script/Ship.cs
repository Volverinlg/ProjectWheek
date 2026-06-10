using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour{
    public ShipStats Stats;
    private InputAction _moveAction;
    /*TODO
    shoot
     */
    void Start(){
        _moveAction = InputSystem.actions.FindAction("Move");
    }
    
    void Update(){
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue.x * Stats.Speed * Time.deltaTime, 0, moveValue.y * Stats.Speed * Time.deltaTime);
    }
}
