using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;

    public GameObject attackarea;
    public float cooldown = 0f;
    public float attackrate = 2f;
    public LayerMask playerLayerMask;
    public float radius;
    public int bossDamageOutPut = 1;


    void Update()
    {
        

        
        attack();
    }

    public void attack()
    {
        if (Time.time >= cooldown)
        {
            if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("HeavyBandit_Attack"))
            {
                //Debug.Log("Boss attacked");
                Collider2D[] p = Physics2D.OverlapCircleAll(attackarea.transform.position, radius, playerLayerMask);

                foreach (Collider2D c in p)
                {
                    c.GetComponent<Health>().damageTaken(bossDamageOutPut);

                    cooldown = Time.time + 1f / attackrate;
                }

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackarea.transform.position, radius);
    }



    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
