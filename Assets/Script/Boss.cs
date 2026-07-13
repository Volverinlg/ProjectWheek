using System;
using UnityEngine;
using UnityEngine.Events;

public class Boss : Enemy_DMG_Handling{
// TODO Spawnconditions

    public void Update(){
        Shoot(MyTarget());
    }
}
