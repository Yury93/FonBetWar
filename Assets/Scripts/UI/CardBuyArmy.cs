using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardBuyArmy : MonoBehaviour
{
    [SerializeField] private int priceEnery;
    [SerializeField] private CombatUnit prefabUnit;
    [SerializeField] private UnitProperties assetUnit;
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
            Instantiate(unit, screenPoint, Quaternion.identity);
            unit = null;
        }
    }
}
