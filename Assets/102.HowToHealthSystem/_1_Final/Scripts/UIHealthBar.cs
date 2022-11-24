using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;
    public Slider HealthSlider;
    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        UpdateHealthBar();
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        UpdateHealthBar();
    }

    //�ڱ� �ｺ�ý��ۿ���, �ǰ� ���϶� �̺�Ʈ�� ��ȯ�ϴϱ� 

    //��Ͻ����� 
    private void UpdateHealthBar()
    {
        Debug.Log("������Ʈ�ｺ��");
        HealthSlider.value = healthSystem.GetHealthPercent();
    }

}
