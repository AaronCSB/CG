using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int maxHp = 10;
    public int currentHealth;
    public GameObject GameOverScreen;
    public GameObject GameWonScreen;
    public Slider Bosshealthbar;
    private int bosshealth;
    public GameObject boss;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHp;
        bosshealth = (int) Bosshealthbar.value;
    }

    public void damageTaken(int dmg)
    {
        currentHealth -= dmg;
        slider.value = currentHealth;

        if(currentHealth == 0)
        {
            gameOverTrigger();
        }
    }

    public void damageGiven(int dmg)
    {
        bosshealth -= dmg;
        Bosshealthbar.value = bosshealth;

        if(bosshealth == 0)
        {
            gameWonTrigger();
            boss.GetComponent<Animator>().SetBool("Died", true);
        }
    }

   

    void OnCollisionEnter(Collision col)
    {
        damageTaken(1);
    }


    public void gameOverTrigger()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void gameWonTrigger()
    {
        GameWonScreen.SetActive(true);
    }

}
