using UnityEngine;

public class Enemy_PathNode : MonoBehaviour{
    public Enemy_PathNode next;
    public bool IsEnd;

    public void OnDrawGizmos(){
        Gizmos.color = Color.darkRed;
        Gizmos.DrawWireSphere(transform.position,0.5f);
        if (next != null){
            Gizmos.DrawLine(transform.position, next.transform.position);
        }
    }

}
