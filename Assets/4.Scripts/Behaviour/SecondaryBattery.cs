using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryBattery : MonsterFSM_Behaviour
{

    ShipEnemy shipEnemy;

    [SerializeField]
    private bool imDie = false;
    private void Awake()
    {
        hp = maxHp;
        imDie = false;
        //shipEnemy.TotalHpMax(maxHp); //이걸 시스템으로도 할수 있나? new로 해가지고 
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        shipEnemy = GetComponentInParent<ShipEnemy>();

        //Debug.Log("세컨더리 배터리");
        fsmManager = new StateMachine<MonsterFSM>(this, new stateIdleBattery());
        fsmManager.AddStateList(new stateAtkBattery());
        fsmManager.AddStateList(new stateMainBatteryDie());
        fov = GetComponent<FieldOfView>();

        OnAwakeAtkBehaviour();

        atkRange = nowAtkBehaviour?.atkRange ?? 5.0f;
   

        

        healthSystem = new HealthSystem(maxHp);
        healthBar.Setup(healthSystem);
        
    }

    public override void OnExecuteAttack(int attackIndex)
    {
        if(getFlagLive)
        {
            base.OnExecuteAttack(attackIndex);
        }
      
    }

    public override void setDmg(int dmg, GameObject atkEffectPrefab)
    {
        Debug.Log("셋데미지");
        //죽었냐 ?
        if (!getFlagLive)
        {
            //데미지 처리 안함 
            return;
        }


        hp -= dmg;
        healthSystem.Damage(dmg);


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

            //
            //맞는 소리
            //맞는 이펙트 넣기
            
            //죽은 상태면 stateDie로 상태 전환 
            fsmManager.ChangeState<stateMainBatteryDie>(); //

        }
    }


}
