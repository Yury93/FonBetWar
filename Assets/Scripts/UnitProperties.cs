using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Unit war", menuName ="Warriors",order = 51)]
public class UnitProperties : ScriptableObject
{
    [SerializeField] private int HP;
    [SerializeField] private float speed;
    [SerializeField] private Sprite sprite;

    [Header("Attack")]
    [SerializeField] private bool longAttack, closeAttack;
    ///TODO: ÑÄÅËÀÒÜ ÌÅÒÎÄÛ ÀÒÀÊÈ ÂÀĞÈÀÍÒ ÁËÈÆÍÅÃÎ È ÄÀËÜÍÅÃÎ ÁÎß
}
