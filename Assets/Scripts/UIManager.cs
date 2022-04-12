using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBase<UIManager>
{
    [SerializeField] private Text textHPPlayer, textHPEnemy;
    [SerializeField] private Slider hpPlayer, hpEnemy;
    [SerializeField] private GameObject textClick;
    [SerializeField] private GameObject particleArea;
    //[SerializeField] private Camp playerCamp, enemyCamp;
    private void Start()
    {
        textHPPlayer.text = $"100/100";
        textHPEnemy.text = $"100/100";
        textClick.SetActive(false);
        particleArea.SetActive(false);

    }
    public void OnTextClick(bool active)
    {
        textClick.gameObject.SetActive(active);
        particleArea.SetActive(active);
    }
    public void Damage(Camp camp)
    {
        if (!camp.AI)
        {
            hpPlayer.value -= (float)camp.GetDamage/100;
            textHPPlayer.text = $"{camp.HP}/100";
        }
        else if(camp.AI)
        {
            hpEnemy.value -= (float)camp.GetDamage / 100;
            textHPEnemy.text = $"{camp.HP}/100";
        }
    }
}
