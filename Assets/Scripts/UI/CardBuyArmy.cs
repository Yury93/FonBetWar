using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardBuyArmy : MonoBehaviour
{
    [SerializeField] private int priceEnery;
    [SerializeField] private CombatUnit prefabUnit;
    [SerializeField] private UnitProperties unitProperties;
    private CombatUnit unit = null;
    private EnergyGenerator energyGenerator;

    private void Start()
    {
        energyGenerator = FindObjectOfType<EnergyGenerator>();
    }
    public void InitUnit()
    {
        energyGenerator.UseEnergy(priceEnery);
        unit = prefabUnit;
        gameObject.GetComponentInChildren<Button>().interactable = false;
    }
    
    private void Update()
    {
        if(energyGenerator.Energy >= priceEnery)
        {
            gameObject.GetComponentInChildren<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponentInChildren<Button>().interactable = false;
        }
        var pos = new Vector3(Input.mousePosition.x, 
            Input.mousePosition.y,
            Camera.main.transform.position.y);

        var screenPoint = Camera.main.ScreenToWorldPoint(pos);

        if (Input.GetMouseButtonDown(0) &&
            unit &&
            screenPoint.x < -2)
        {
            screenPoint.z = 0;
           var newUnit = Instantiate(unit, screenPoint, Quaternion.identity);
            
            newUnit.GetComponent<Turret>().RadiusAttack(unitProperties.SetRadiusAttack());

            newUnit.SetProperties(unitProperties.SetHp,
                unitProperties.SetSpeed,
                unitProperties.SetDistanceStop,
                unitProperties.SetAi,
                unitProperties.SetSprite);

            unit = null;
        }
    }
}
