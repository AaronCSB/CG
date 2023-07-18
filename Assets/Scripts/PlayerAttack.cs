using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

    public GameObject attackarea;
    public float cooldown = 0.25f;
    //public GameObject enemy;
    public LayerMask enemyLayerMask;
    public float radius;
    public int playerOutputDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        AttackAreaTurn();
        attack();
    }

    public void attack()
    {
        if (Input.GetMouseButtonDown(0)) { 
        Collider2D[] boss = Physics2D.OverlapCircleAll(attackarea.transform.position, radius, enemyLayerMask);

        foreach (Collider2D c in boss)
        {
                this.GetComponent<Health>().damageGiven(playerOutputDamage);
        }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackarea.transform.position, radius);
    }

    private void AttackAreaTurn()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            attackarea.transform.localPosition = new Vector2(-0.87f, 0.99f);
            //Debug.Log("Links");
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            attackarea.transform.localPosition = new Vector2(0.8f, 0.99f);
            //Debug.Log("Rechts");
        }
    }
}
