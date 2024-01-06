using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    private float time = 0;
    //private float burning = 0;

    private void OnCollisionExit(Collision collision)
    {
        //burning = 0;
    }
    private void OnCollisionStay(Collision collision)
    {
        time += Time.deltaTime;
        if (collision.gameObject.tag.Equals("Grill") && time > .1)
        {
            time = 0;
            Color c = gameObject.GetComponent<Renderer>().material.color;
            /*843 157 216
              357 192 055
              235 133 031
              0 0 0*/
            float guy = Random.value * 2f;
            if (c.r > .357)
            {
                c.r -= .00972f * guy;
                c.g += .0007f * guy;
                c.b -= .00322f * guy;
            }
            else if (c.r > .235)
            {
                c.r -= .0061f * guy;
                c.g -= .00295f * guy;
                c.b -= .0012f * guy;
            }
            else if (c.r > 0)
            {
                c.r -= .0047f * guy;
                c.g -= .00266f * guy;
                c.b -= .00062f * guy;
            }
            //else if (c.r <= 0) burning += .1f;
            gameObject.GetComponent<Renderer>().material.color = c;
        }
    }

}
