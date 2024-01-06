using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragginKnife : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        Vector3 objPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Vector3 whereGo = (curPosition - objPosition);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, whereGo.y * 5, whereGo.z * 5);

        //rotation
        float h = Input.GetAxisRaw("Horizontal");
        transform.Rotate(new Vector3((h * (float)0.7), 0, 0));

        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }

}