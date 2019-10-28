using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum KEY_TYPE
    {
        BLUE = 0,
        RED = 1,
        GREEN = 2
    }
    public KEY_TYPE type;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (type)
            {
                case KEY_TYPE.BLUE:
                    other.GetComponent<Gaze>().blueKey = true;
                    break;
                case KEY_TYPE.RED:
                    other.GetComponent<Gaze>().redKey = true;
                    break;
                case KEY_TYPE.GREEN:
                    other.GetComponent<Gaze>().greenKey = true;
                    break;
            }
        }
    }
}
