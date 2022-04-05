using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Unit war", menuName ="Warriors",order = 51)]
public class UnitProperties : ScriptableObject
{
    [SerializeField] private int HP;
    public int SetHp => HP;
    [SerializeField] private float speed;
    public float SetSpeed => speed;

    [SerializeField] private Sprite sprite;
    public Sprite SetSprite => sprite;

    [SerializeField] private bool ai;
    public bool SetAi => ai;

    [Header("Attack")]
    [SerializeField] private float distanceStopUnit;
    public float SetDistanceStop => distanceStopUnit;
    [SerializeField] private float radiusAttack;

    public float SetRadiusAttack()
    {
        return radiusAttack;
    }
    
}
