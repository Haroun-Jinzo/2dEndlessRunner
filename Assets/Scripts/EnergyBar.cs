using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energyBar;
    private int maxEnergy = 50;
    public float currentEnergy;
    

    public static EnergyBar instance;

        
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.maxValue = maxEnergy;
        energyBar.value = currentEnergy;
       
    }

    public void useEnergy(float amount)
    {
        if (currentEnergy - 2 >= 0)
        {
            currentEnergy -= amount * Time.deltaTime;
            energyBar.value = currentEnergy;
            StartCoroutine(RegenEnergy());
        } 

    }

    private IEnumerator RegenEnergy()
    {
        yield return new WaitForSeconds(8);

        while (currentEnergy < maxEnergy)
        {
            currentEnergy += maxEnergy / 200;
            energyBar.value = currentEnergy;
            yield return new WaitForSeconds(16f);
        }
    }
}
