using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public bool seen = false;
    public GameObject player;
    NavMeshAgent agent;
    bool notRun = true;

    public void Start()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        agent = transform.parent.gameObject.GetComponent<NavMeshAgent>();
    }
    public void Update()
    {
        if (seen && notRun)
        {
            agent.destination = player.transform.position;
            GetComponentInParent<Animator>().SetTrigger("Seen");
            notRun = false;
        }
        if (seen && !notRun)
        {
            agent.destination = player.transform.position;
        }
    }
}