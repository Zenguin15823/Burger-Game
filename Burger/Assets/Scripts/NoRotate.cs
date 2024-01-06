using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotate : MonoBehaviour
{
    protected void LateUpdate()
    {
        transform.rotation = new Quaternion(transform.rotation.x, 0, 0, transform.rotation.w);
    }
}
