using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pLAYERdEATHtRACKER : MonoBehaviour
{
    public float checkRadius = 5f;
    public int currentNearMe = 0;
    public int nearMax = 5;
    public Canvas loss;
    public void Update()
    {
        currentNearMe = 0;
        var checkResults = Physics.OverlapSphere(transform.position, checkRadius);
        foreach (var curr in checkResults)
        {
            if (curr.tag == "Enemy")
            {
                if (curr.gameObject.GetComponentInChildren<EnemyController>())
                {
                    if (curr.gameObject.GetComponentInChildren<EnemyController>().seen)
                    {
                        currentNearMe++;
                    }
                }
            }
        }
        if (currentNearMe >= nearMax)
        {
            loss.gameObject.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(0);
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

}
