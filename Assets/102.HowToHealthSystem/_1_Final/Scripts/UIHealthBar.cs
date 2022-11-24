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

    //자기 헬스시스템에서, 피가 깍일때 이벤트를 소환하니까 

    //등록시켜줌 
    private void UpdateHealthBar()
    {
        Debug.Log("업데잍트헬스바");
        HealthSlider.value = healthSystem.GetHealthPercent();
    }

}
