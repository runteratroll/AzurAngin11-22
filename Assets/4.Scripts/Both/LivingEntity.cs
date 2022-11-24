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
        healthSystem = new HealthSystem(maxHealth); //  ���޹����� �ƴϴ�, ���ο��� �ٷλ���
        healthBar.Setup(healthSystem); //HealthSystem�� ����HP�� ���޹ޱ����� Setup�� �����ش�.  
    }


    public virtual void Die()
    {
        dead = true;
        Debug.Log("����");
    }

    public virtual void setDmg(int dmg, GameObject prefabEffect)
    {

        if (!getFlagLive)
        {
            //������ ó�� ���� 
            return;
        }

        //�� �׾��ٸ�, ���� hp���� �������� ���� ���ش� 
        currentHealth -= dmg;
        healthSystem.Damage(dmg);

        //if (atkEffectPrefab)
        //{
        //    Instantiate(atkEffectPrefab, weaponHitTransform); //������ �ً�, ����Ʈ����Ʈ�� �ֳ�
        //    //weaponHitTransform��  ������ Ŭ���� ���� �ʿ� �߰��ϰ� ���ƿ´�
        //    //Į�� �¾Ҵ� �� �� Į�� ��ġ
        //    //���� ���� 
        //}

        //������ ���� �ϰ� 0 ���ϰ� �Ǹ� ���� ���°� �ǰ���
        //�ٵ� ������ �����ص� ��� �ִ� ���¸� 
        if (getFlagLive)
        {
            
        }
        else
        {
            //���� ���¸� stateDie�� ���� ��ȯ 
            //fsmManager.ChangeState<stateDie>(); //
            Die();
        }
    }
}
