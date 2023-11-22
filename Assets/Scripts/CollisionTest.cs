using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.layer == 6/*Water Type Enemy is layer 6*/
                && PhysicsTest.BulletType == EProjectileType.Fire)
            {
                Destroy(col.gameObject);
            }
            else if (col.gameObject.layer == 7/*Fire Type Enemy is layer 7*/
                && PhysicsTest.BulletType == EProjectileType.Water)
            {
                Destroy(col.gameObject);
            }
            else if (col.gameObject.layer == 8/*Earth Type Enemy is layer 8*/
                && PhysicsTest.BulletType == EProjectileType.Air)
            {
                Destroy(col.gameObject);
            }
            else if (col.gameObject.layer == 9/*Air Type Enemy is layer 9*/
                            && PhysicsTest.BulletType == EProjectileType.Earth)
            {
                Destroy(col.gameObject);
            }
        }                
         
        Destroy(this.gameObject);        
    }

}
