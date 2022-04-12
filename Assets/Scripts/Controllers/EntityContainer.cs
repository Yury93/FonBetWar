using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityContainer : SingletonBase<EntityContainer>
{
    [SerializeField] private EnergyGenerator UIEnergyGenerator;
    public EnergyGenerator uiEnergyGenertor => UIEnergyGenerator;


}
