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
    private int maxEnergy = 9;
    private void Start()
    {
        slider = GetComponent<Slider>();
        textEnergy.text = $"BET: {energy}";
    }
    private void FixedUpdate()
    {
        if (energy != maxEnergy)
        {
            slider.value += Time.fixedDeltaTime / 2;
            if (slider.value >= 1)
            {
                AudioManager.Instance.AudioPlay("energy");
                energy += 1;
                slider.value = 0;
                textEnergy.text = $"BET: {energy}";
            }
            if(energy == maxEnergy)
            {
                print("генерация энергии закончилась!");
                AudioManager.Instance.AudioPlay("iAmRobot");
            }
        }
    }
    public void UseEnergy(int countEnergy)
    {
        if (energy >= countEnergy) { 
            energy -= countEnergy;
            textEnergy.text = $"BET: {energy}";
            AudioManager.Instance.AudioPlay("buttonBuy");
        }
    }
    public void SetEnergy(int value)
    {
        maxEnergy = value;
    }
}
