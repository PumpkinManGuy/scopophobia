using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pLAYERdEATHtRACKER : MonoBehaviour
{
    public float checkRadius = 5f;
    public float currentNearMe = 0;
    public int nearMax = 5;
    public Canvas loss;
    public Image vignette;
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

        //Debug.Log(string.Format("Max: {0} ||| Current: {1} ||| Alpha: {2}",
        //    nearMax, currentNearMe, (currentNearMe/nearMax)));

        var gcol = vignette.color;
        gcol.a = (currentNearMe / nearMax);
        vignette.color = gcol;

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

    private void VignetteColor()
    {
        Debug.Log("Working + " + (currentNearMe/nearMax));
        var gcol = vignette.color;
        gcol.a = (currentNearMe / nearMax);
        vignette.color = gcol;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

}
