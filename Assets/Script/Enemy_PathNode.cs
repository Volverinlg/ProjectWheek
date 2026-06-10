using UnityEngine;

public class Enemy_PathNode : MonoBehaviour{
    public Enemy_PathNode next;
    //TODO IsEnd wird später verwendet um den Enemy außerhalb der Kamera zu zerstören
    public bool IsEnd;

    public void OnDrawGizmos(){
        Gizmos.color = Color.darkRed;
        Gizmos.DrawWireSphere(transform.position,0.5f);
        if (next != null){
            Gizmos.DrawLine(transform.position, next.transform.position);
        }
    }

}
