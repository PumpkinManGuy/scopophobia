using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool seen = false;
    public GameObject player;

    public void Start()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public void Update()
    {
        if (seen)
        {
            var gt = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);

            transform.position = gt;
            transform.LookAt(player.transform);

            var fix = transform.rotation.eulerAngles;
            var tf = new Vector3(fix.x, fix.y, fix.z);

            tf.x = 90f;

            transform.rotation = Quaternion.Euler(tf);
        }
    }
}