using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookAny : MonoBehaviour
{

    private float time = 0;
    private float r, g, b;

    private void Start()
    {
        Color c = gameObject.GetComponent<Renderer>().material.color;
        r = c.r / 80f;
        g = c.g / 80f;
        b = c.b / 80f;
    }
    private void OnCollisionStay(Collision collision)
    {
        time += Time.deltaTime;
        if (collision.gameObject.tag.Equals("Grill") && time > .1)
        {
            time = 0;
            Color c = gameObject.GetComponent<Renderer>().material.color;
            if (c.r > 0)
            {
                float guy = Random.value;
                c.r -= r * guy;
                c.g -= g * guy;
                c.b -= b * guy;
            }
            gameObject.GetComponent<Renderer>().material.color = c;
        }
    }
}
