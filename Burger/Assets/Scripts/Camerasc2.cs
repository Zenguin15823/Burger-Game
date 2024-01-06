using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerasc2 : MonoBehaviour
{
    public GameObject leader;

    void Update()
    {
        Vector3 whereGo = (leader.transform.position - transform.position);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, whereGo.y * 2, whereGo.z * 2);
    }
}
