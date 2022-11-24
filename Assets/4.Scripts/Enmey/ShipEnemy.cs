using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemy : MonsterFSM_Behaviour
{

    public int TotalBatteryHp;
    public SecondaryBattery[] secondaryBatterys;


    public ShipEnemyHealthBar shipEnemyHealthBar;
    private void Awake()
    {
        
    }
    protected override void Start()
    {

        fsmManager = new StateMachine<MonsterFSM>(this, new stateShipIdle());
        fsmManager.AddStateList(new stateShipMove());
        fsmManager.AddStateList(new stateDie());
        fov = GetComponent<FieldOfView>();

        //OnAwakeAtkBehaviour(); ���� ���ҰŶ�
        GetMaxHpSBattery();
        //atkRange = nowAtkBehaviour?.atkRange ?? 5.0f;
        hp = maxHp; // maxHp�� �ڽĵ��� ���� ���ؾߵ�
        //�� ���Ҷ����� ��ٷ����ϴµ�
        healthSystem = new HealthSystem(maxHp);
        shipEnemyHealthBar.Setup(healthSystem);

        //�ڽ��� �޸� ��ü�� �ް��ϴ°�...
    }
    //�ϴ� ������ ���� ������


    void GetMaxHpSBattery()
    {
        maxHp = 0;
        foreach (SecondaryBattery tem in secondaryBatterys)
        {
            maxHp += tem.hp;
        }
    }
    private void LateUpdate()
    {

 
        //�ｺ�ý��� ������Ʈ���� �̰� ���ֱ�

    }

    //���Լ��� �ڽ��� �ǰ� ���϶����� ��������ֱ�


    public float GetBatteryCurrentHp() //���� �̰� �޾ư����� ������Ʈ �ｺ�� �ϱ�
    {

        Debug.Log("GetBatter�� ����Ǵ�?");

        //�ٵ��̰� ���ɴʳ�
        int batterysHp = 0;
        foreach (SecondaryBattery tem in secondaryBatterys)
        {

            batterysHp += tem.hp;
        }
        hp = batterysHp;


        

        return (float)hp / maxHp;
    }

    public override void setDmg(int dmg, GameObject atkEffectPrefab)
    {
        Debug.Log("ShipEnemy������");
        //�׾��� ?
        if (!getFlagLive)
        {
            //������ ó�� ���� 
            return;
        }


        hp -= dmg;
        healthSystem.Damage(dmg); //�̰͵� �ڵ����� ó�����ִ°ǵ�
        //HealthSystem
        shipEnemyHealthBar.UpdateHealthBar();

        if (atkEffectPrefab)
        {
            Instantiate(atkEffectPrefab, weaponHitTransform); //������ �ً�, ����Ʈ����Ʈ�� �ֳ�
        }

        //������ ���� �ϰ� 0 ���ϰ� �Ǹ� ���� ���°� �ǰ���
        //�ٵ� ������ �����ص� ��� �ִ� ���¸� 
        if (getFlagLive)
        {
            //animator?.SetTrigger("hitTriggerHash"); /�´� �ִϸ��̼�
        }
        else
        {
            //���� ���¸� stateDie�� ���� ��ȯ 
            fsmManager.ChangeState<stateDie>(); //
        }
    }
}