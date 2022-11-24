using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTypeAtkBehaviour : AtkBehaviour
{



    public override void callAtkMotion(GameObject target = null, Transform posAtkStart = null)
    {


        if (target == null && posAtkStart != null)
        {
            return;
        }
        //타겟은 정해주는 거겠지 
        

        Vector3 vecProjectile = posAtkStart?.position ?? transform.position;

        if (atkEffectPrefab != null)
        {

           

            //프리팹이 없어가지고 
            GameObject objProjectile = GameObject.Instantiate<GameObject>(atkEffectPrefab, vecProjectile, Quaternion.identity);
   
            objProjectile.transform.forward = transform.forward;

            CollisionProjectileAtk projectile = objProjectile.GetComponent<CollisionProjectileAtk>();
  
            if (projectile != null)
            {
                projectile.projectileParents = this.gameObject; 
                projectile.target = target; 
                projectile.attackBehaviour = this;
            }
        }

        nowAtkCoolTime = 0.0f;
    }
}