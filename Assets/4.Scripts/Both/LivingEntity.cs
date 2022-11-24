using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDmgAble
{
    
    [SerializeField] protected int maxHealth;
    public HealthBar healthBar;
    
    HealthSystem healthSystem;
    protected int currentHealth;
    protected bool dead;

    public bool getFlagLive => currentHealth > 0;



    protected virtual void Start()
    {
        currentHealth = maxHealth;
        healthSystem = new HealthSystem(maxHealth); //  전달받을께 아니니, 내부에서 바로생성
        healthBar.Setup(healthSystem); //HealthSystem의 내부HP를 전달받기위해 Setup을 보내준다.  
    }


    public virtual void Die()
    {
        dead = true;
        Debug.Log("죽음");
    }

    public virtual void setDmg(int dmg, GameObject prefabEffect)
    {

        if (!getFlagLive)
        {
            //데미지 처리 안함 
            return;
        }

        //안 죽었다면, 현재 hp에서 데미지를 차감 해준다 
        currentHealth -= dmg;
        healthSystem.Damage(dmg);

        //if (atkEffectPrefab)
        //{
        //    Instantiate(atkEffectPrefab, weaponHitTransform); //데미지 줄떄, 어펙트이펙트도 주네
        //    //weaponHitTransform는  변수를 클래스 변수 쪽에 추가하고 돌아온다
        //    //칼을 맞았다 할 때 칼의 위치
        //    //힙을 설정 
        //}

        //데미지 차감 하고 0 이하가 되면 죽은 상태가 되겠지
        //근데 데미지 차감해도 살아 있는 상태면 
        if (getFlagLive)
        {
            
        }
        else
        {
            //죽은 상태면 stateDie로 상태 전환 
            //fsmManager.ChangeState<stateDie>(); //
            Die();
        }
    }
}
