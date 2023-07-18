using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvents : MonoBehaviour
{
    public string tag;
    public GameObject[] activatedByTriggering;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            foreach (GameObject go in activatedByTriggering) { 
                go.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            foreach (GameObject go in activatedByTriggering)
            {
                go.SetActive(false);
            }
        }
    }
}
