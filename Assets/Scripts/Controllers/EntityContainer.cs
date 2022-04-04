using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityContainer : SingletonBase<EntityContainer>
{
    [SerializeField] private GameObject UIEnergyGenerator;
    public GameObject EnergyGenertor => UIEnergyGenerator;
   
}
