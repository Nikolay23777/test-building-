using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // print("----");
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
         //   print("///");
            //GetComponent<Camera> ().field0fView--;
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y+.3f, transform.position.z);
        }
        //GetComponent<Camera> ().field0fView++;

    }
}
