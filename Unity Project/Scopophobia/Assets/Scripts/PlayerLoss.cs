using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoss : MonoBehaviour
{
    public int aroundMe;

    [Range(0, 100)]
    public int lossNumber;

    public void Start()
    {
        if (lossNumber == 0)
        {
            lossNumber = 3;
        }
    }
}
