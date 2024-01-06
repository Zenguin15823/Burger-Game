using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayHere : MonoBehaviour
{
    private float here;
    void Start()
    {
        here = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != here) transform.position = new Vector3(here, transform.position.y, transform.position.z);
    }
}
