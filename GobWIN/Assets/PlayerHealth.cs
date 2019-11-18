using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHealth : MonoBehaviour
{
    #region Variables

    [Header("References")]
    public NavMeshAgent agent;
    public Transform destination;
    public Transform target;

    [Header("Attributes")]
    [Range(0, 50)]
    public float DamageDealt = 10;
    [Range(0, 100)]
    public float Health = 100f;
    public float Speed = 3.5f;
    public float HealOverTime = 1;

    RaycastHit hit;
    Ray ray;

    #endregion

    // Update is called once per frame
    void Update()
    {
        HealthGen();

        if(target == null)
            agent.SetDestination(destination.position);
        else
            agent.SetDestination(target.position);

        if (Input.GetMouseButtonDown(0))    // for standalone
        { ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100)) {
                if (hit.transform.tag == "Enemy") {
                    target = hit.transform;  //if enemy clicked, change target
                }
            }
        }
    }

    void HealthGen()
    {
        if (Health <= 0)
        {
            agent.speed = 0;
            Debug.Log("You have died.");
        }
        else if(Health <= 80)
        {
            Health += HealOverTime * Time.deltaTime;
        }
    }
}
