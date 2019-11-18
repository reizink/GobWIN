using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    #region Variables

    [Header("References")] //property drawers
    public NavMeshAgent agent;
    public Transform destination; //get to treasure
    public GameObject target;

    [Header("Attributes")]
    [Range(0, 50)]
    public float DamageDealt = 5;
    [Range(0, 100)]
    public float Health = 100f;
    public float Speed = 3.5f;
    public float HealOverTime = 1;

    public float DistanceFromTarget = 2f; //minimum distance
    public float distance;

    private GameObject playerObject;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerObject = findClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        HealthGen();

        if (target == null)
            agent.SetDestination(destination.position);
        else
            agent.SetDestination(target.transform.position);

        target = playerObject;

        /*if (target.health <= 0) //goblin dies, find new one to attack
        {
            target = findClosestEnemy();
        }*/
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
    }
    public void DealDamage(int damage)
    {
        Health -= damage * Time.deltaTime;
    }
    void HealthGen()
    {
        if (Health <= 0)
        {
            agent.speed = 0;
            Debug.Log("Enemy Destroyed");
            GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).GetComponent<Animator>().SetBool("IsDead", true);
        }
        else if (Health <= 80)
        {
            Health += HealOverTime * Time.deltaTime;
        }
    }

    private GameObject findClosestEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        GameObject closestEnemy = null;
        float closestDistance = 1000;
        bool first = true;

        foreach (var obj in objs)
        {
            float distance1 = Vector3.Distance(obj.transform.position, transform.position);

            if (first)
            {
                closestDistance = distance;
                first = false;
            }
            else if (distance1 < closestDistance)
            {
                closestEnemy = obj;
                closestDistance = distance1;
            }
        }

        return closestEnemy;
    }
}
