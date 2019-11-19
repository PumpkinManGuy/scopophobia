using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public bool seen = false;
    public GameObject player;
    NavMeshAgent agent;

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
        if (seen)
        {
            agent.destination = player.transform.position;
        }
    }
}