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

        //OnAwakeAtkBehaviour(); 공격 안할거라
        GetMaxHpSBattery();
        //atkRange = nowAtkBehaviour?.atkRange ?? 5.0f;
        hp = maxHp; // maxHp에 자식들을 전부 더해야되
        //다 더할때까지 기다려야하는디
        healthSystem = new HealthSystem(maxHp);
        shipEnemyHealthBar.Setup(healthSystem);

        //자식이 달면 전체가 달게하는게...
    }
    //일단 레코일 먼저 만들자


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

 
        //헬스시스템 업데이트에서 이거 해주기

    }

    //이함수는 자식이 피가 까일때마다 실행시켜주기


    public float GetBatteryCurrentHp() //현재 이걸 받아가지고 업데이트 헬스바 하기
    {

        //Debug.Log("GetBatter가 실행되니?");

        //근데이거 왜케늦냐
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
        Debug.Log("ShipEnemy데미지");
        //죽었냐 ?
        if (!getFlagLive)
        {
            //데미지 처리 안함 
            return;
        }


        hp -= dmg;
        healthSystem.Damage(dmg); //이것도 자동으로 처리해주는건데
        //HealthSystem
        shipEnemyHealthBar.UpdateHealthBar();

        if (atkEffectPrefab)
        {
            Instantiate(atkEffectPrefab, weaponHitTransform); //데미지 줄떄, 어펙트이펙트도 주네
        }

        //데미지 차감 하고 0 이하가 되면 죽은 상태가 되겠지
        //근데 데미지 차감해도 살아 있는 상태면 
        if (getFlagLive)
        {
            //animator?.SetTrigger("hitTriggerHash"); /맞는 애니메이션
        }
        else
        {
            //죽은 상태면 stateDie로 상태 전환 
            fsmManager.ChangeState<stateDie>(); //
        }
    }
}
