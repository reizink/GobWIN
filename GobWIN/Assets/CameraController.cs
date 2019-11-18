using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollWidth;
    public float scrollHeight;
    public float oneTenthHeight;
    public float oneTenthWidth;
    public int scrollspeed;
    // Start is called before the first frame update
    void Start()
    {
        oneTenthHeight = (Screen.height / 10);
        oneTenthWidth = (Screen.width / 10);
        scrollHeight = Screen.height - (Screen.height / 10);
        scrollWidth = Screen.width - (Screen.width/ 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > -2.57f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2.57f);
        }
        if(transform.position.z < -11.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -11.5f);

        }
        if (transform.position.x > 2.3f)
        {
            transform.position = new Vector3(2.3f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -1.5f)
        {
            transform.position = new Vector3(-1.5f, transform.position.y, transform.position.z);
        }
        if (Input.mousePosition.y > scrollHeight)
        {
            transform.Translate(Vector3.up * scrollspeed*Time.deltaTime);
        }
        if (Input.mousePosition.y < oneTenthHeight)
        {
            transform.Translate(Vector3.down * scrollspeed * Time.deltaTime);

        }
        if (Input.mousePosition.x > scrollWidth)
        {
            transform.Translate(Vector3.right * scrollspeed*Time.deltaTime);
        }
        if (Input.mousePosition.x < oneTenthWidth)
        {
            transform.Translate(Vector3.left * scrollspeed * Time.deltaTime);
        }
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if(hit.transform.tag == "Player")
                {
                    hit.transform.GetComponent<playercontroller>().SetSelected();
                }
            }
        }
    }
}
