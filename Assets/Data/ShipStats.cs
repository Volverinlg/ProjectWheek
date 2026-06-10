using UnityEngine;

[CreateAssetMenu(fileName = "ShipStats", menuName = "Scriptable Objects/ShipStats")]
public class ShipStats : ScriptableObject{
    public float Speed;
    public int HP;
    public int Dämätsch; // :}
    public float Range;
    public float FireRate;
    public GameObject Projectile;
}
