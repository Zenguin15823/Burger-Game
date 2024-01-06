using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   float h = Input.GetAxisRaw("Horizontal");
   float v = Input.GetAxisRaw("Vertical");
   
   gameObject.transform.rotation = new Quaternion(transform.rotation.x + (h * (float)0.01),
      transform.rotation.y + (v * (float)0.01), transform.rotation.z, transform.rotation.w);
    }
}
