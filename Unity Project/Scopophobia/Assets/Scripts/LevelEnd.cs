using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ThisLevel
{
    ONE = 0,
    TWO = 1,
    THREE = 2
}
public class LevelEnd : MonoBehaviour
{


    public ThisLevel thisLevel;

    public Transform Start_1, Start_2, Start_3;
    public GameObject player;
    public GameObject Level_1, Level_2, Level_3;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (thisLevel)
            {
                case ThisLevel.ONE:
                    //player.transform.position = Start_2.position;
                    Level_1.SetActive(false);
                    Level_2.SetActive(true);
                    Level_3.SetActive(false);
                    player.GetComponent<Gaze>().redKey = false;
                    player.GetComponent<Gaze>().blueKey = false;
                    player.GetComponent<Gaze>().greenKey = false;
                    break;
                case ThisLevel.TWO:
                    //player.transform.position = Start_3.position;
                    Level_1.SetActive(false);
                    Level_2.SetActive(false);
                    Level_3.SetActive(true);
                    player.GetComponent<Gaze>().redKey = false;
                    player.GetComponent<Gaze>().blueKey = false;
                    player.GetComponent<Gaze>().greenKey = false;
                    break;
                case ThisLevel.THREE:
                    player.GetComponent<Gaze>().redKey = false;
                    player.GetComponent<Gaze>().blueKey = false;
                    player.GetComponent<Gaze>().greenKey = false;
                    break;
            }
        }
    }
}
