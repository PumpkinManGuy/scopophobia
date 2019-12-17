using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public enum ThisLevel
    {
        ONE = 0,
        TWO = 1,
        THREE = 2
    }

    public ThisLevel thisLevel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Shid");
        }
    }
}
