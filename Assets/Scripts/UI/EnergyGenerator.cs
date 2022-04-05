using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyGenerator : MonoBehaviour
{
    [SerializeField] private int energy;
    public int Energy => energy;
    [SerializeField] private Slider slider;
    [SerializeField] private Text textEnergy;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    private void FixedUpdate()
    {
        if (energy != 9)
        {
            slider.value += Time.fixedDeltaTime / 2;
            if (slider.value >= 1)
            {
                energy += 1;
                slider.value = 0;
                textEnergy.text = $"Energy: {energy}";
            }
            if(energy == 9)
            {
                print("генерация энергии закончилась!");
            }
        }
    }
    public void UseEnergy(int countEnergy)
    {
        if (energy >= countEnergy) { 
            energy -= countEnergy;
            textEnergy.text = $"Energy: {energy}";
        }
    }
}
