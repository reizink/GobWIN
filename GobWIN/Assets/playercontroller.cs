//Created By Andrew Johnson
//Purpose: to handle all the movement systems for the player
//and to handle the attacking of the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class playercontroller : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    bool amSelected;
    public SpriteRenderer mySprite;
    public Color selectedColor;
    public Color notSelectedColor;
    public Vector3 destination;
    AnimationController animationController;
    public Transform Target;
    public ReasourceManager reasourceManager;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animationController = GetComponent<AnimationController>();
    }
    // Update is called once per frame
    void Update()
    {
        print(destination);
        print(amSelected);
        if (amSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                print("mouse were clicked");
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    destination = hit.point;
                    print(hit.point);
                    if(hit.transform.tag == "Enemy")
                    {
                        destination = hit.transform.position;
                        Target = hit.transform;
                    }
                    else
                    {
                        Target = null;
                    }
                }
            }

        }
        if(Input.GetMouseButtonDown(1))
        {
            Target = null;
        }
        if (Target != null)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) <= 1)
            {
                animationController.AttackingAnimation(Target.transform.position - transform.position);
                Target.GetComponent<EnemyHealth>().DealDamage(20);
            }
        }
        if(Target == null)
        {
            animationController.CancelAttack();
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
        navMeshAgent.SetDestination(destination);
    }
    public void SetSelected()
    {
        if (amSelected == true)
        {
            amSelected = false;
            mySprite.color = notSelectedColor;
        }
        else
        {
            amSelected = true;
            mySprite.color = selectedColor;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            if(other.name == "Goblin Coin(Clone)")
            {
                reasourceManager.steelAmount++;
            }
            if(other.name == "Goblin Gem(Clone)")
            {
                reasourceManager.TnTAmount++;
            }
            if(other.name == "Shelf(Clone)")
            {
                reasourceManager.woodAmount++;
            }
            Destroy(other.gameObject);
        }
    }
}
