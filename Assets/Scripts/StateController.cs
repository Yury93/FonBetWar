using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private CombatUnit unit;
    private Turret turret;
    private void Start()
    {
        unit = GetComponent<CombatUnit>();
        turret = GetComponent<Turret>();
        unit.SetState("MoveBase");
    }
    private void Update()
    {
        if(turret.Target && turret.Target.GetComponent<Camp>() || turret.Target == null)
        {
            unit.SetState("MoveBase");
        }
        else if(turret.Target && turret.Target.GetComponent<CombatUnit>())
        {
            unit.SetState("MoveArmy");
        }
    }

}
