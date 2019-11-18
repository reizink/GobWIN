using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReasourceManager : MonoBehaviour
{
    private bool builtItem;
    public int woodAmount;
    public int steelAmount;
    public int TnTAmount;
    public Button barricadeButton;
    public Button mineButton;
    public Button spikeButton;

    public GameObject barricade;
    public GameObject TnT;
    public GameObject spike;

    private int i;

    public GameObject[] traps;
    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        builtItem = false;

        traps[0] = barricade;
        traps[1] = TnT;
        traps[2] = spike;
    }

    // Update is called once per frame
    void Update()
    {
        texts[0].text = "Coins: " + steelAmount;
        texts[1].text = "Gems: " + TnTAmount;
        texts[2].text = "Wood: " + woodAmount;
        //if (woodAmount < 3 && steelAmount < 3 && !builtItem)
        //{
        //    barricadeButton.interactable = false;
        //}
        //else
        //{
        //    barricadeButton.interactable = true;
        //}

        //if(TnTAmount < 3 && !builtItem)
        //{
        //    mineButton.interactable = false;
        //}
        //else
        //{
        //    mineButton.interactable = true;
        //}

        //if(woodAmount < 3 && !builtItem)
        //{
        //    spikeButton.interactable = false;
        //}
        //else
        //{
        //    mineButton.interactable = true;
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.tag == "Wood")
        //        {
        //            Destroy(hit.transform.gameObject);
        //            woodAmount++;
        //            Debug.Log("wood");
        //        }
        //        if (hit.transform.tag == "Steel")
        //        {
        //            Destroy(hit.transform.gameObject);
        //            steelAmount++;
        //            Debug.Log("steel");
        //        }
        //        if (hit.transform.tag == "TNT")
        //        {
        //            Destroy(hit.transform.gameObject);
        //            TnTAmount++;
        //            Debug.Log("TNT");
        //        }
        //        if (builtItem)
        //        {
        //            Instantiate(traps[i], hit.transform);
        //            builtItem = false;
        //        }
        //    }
            
        //}

    }

    public void BuildBarricade()
    {
        woodAmount = woodAmount - 2;
        steelAmount = steelAmount - 2;
        i = 0;
        builtItem = true;
    }

    public void BuildMine()
    {
        TnTAmount = TnTAmount - 2;
        i = 1;
        builtItem = true;
    }

    public void BuildSpike()
    {
        woodAmount = woodAmount - 2;
        i = 2;
        builtItem = true;
    }
}
