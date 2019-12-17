using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DorCeck : MonoBehaviour
{
    public enum DOOR
    { 
        Red, Blue, Green
    }
    public DOOR color;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (color)
            {
                case DOOR.Red:
                    if (other.gameObject.GetComponent<Gaze>().redKey)
                    {
                        Debug.Log("Red Key Check");
                        GetComponent<Animator>().SetTrigger("Open");
                    }
                    break;
                case DOOR.Blue:
                    if (other.gameObject.GetComponent<Gaze>().blueKey)
                    {
                        Debug.Log("Blue Key Check");
                        GetComponent<Animator>().SetTrigger("Open");
                    }
                    break;
                case DOOR.Green:
                    if (other.gameObject.GetComponent<Gaze>().greenKey)
                    {
                        Debug.Log("Green Key Check");
                        GetComponent<Animator>().SetTrigger("Open");
                    }
                    break;
            }
        }
    }
}