using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MpnsterTamp;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(cast, out hit))
            {
                if (hit.collider.tag == "Ground")
                {
                    GameObject temp = (GameObject)Instantiate(MpnsterTamp);
                    temp.transform.position = hit.point + new Vector3(0.0f, 1.0f, 0.0f);
                }

                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);

                Debug.Log("Hit => " + hit.collider.name);

            }
        }
    }
}
