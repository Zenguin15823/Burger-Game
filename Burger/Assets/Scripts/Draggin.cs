using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggin : MonoBehaviour
 {
 
 private Vector3 screenPoint;
 private Vector3 offset;
    private float xee;
    private Vector3 past;
    private float googie;
 
 void OnMouseDown()
 {
     screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        xee = transform.position.x;
        past = transform.position;
     offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
 
 }
 
 void OnMouseDrag()
 {
     Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
 
 Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
 transform.position = curPosition;
        transform.position = new Vector3(xee, transform.position.y, transform.position.z);

        Vector3 velc = (transform.position - past);
        googie += Time.deltaTime;
        if (googie > .25)
        {
            past = transform.position;
            googie = 0;
        }
        gameObject.GetComponent<Rigidbody>().velocity = velc;

        float h = Input.GetAxisRaw("Horizontal");

        transform.Rotate(new Vector3((h * (float)0.7), 0, 0));
        
    }
 
 }