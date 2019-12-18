using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public void Update()
    {
        OVRInput.Update();
        var go = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);
        var move = new Vector3(go.x, 0f, go.y);
        transform.position += move;
    }
}