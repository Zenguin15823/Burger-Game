using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camerasc : MonoBehaviour
{

    private bool locka;
    public GameObject closed, open, playagain, quit, sensi;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        locka = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (locka)
            {
                Cursor.lockState = CursorLockMode.None;
                locka = false;
                playagain.SetActive(true);
                quit.SetActive(true);
                sensi.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                locka = true;
                playagain.SetActive(false);
                quit.SetActive(false);
                sensi.SetActive(false);
            }
        }
        if (locka)
        {
            if (Input.GetAxis("Mouse X") < 0)
               transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + sensi.GetComponent<Slider>().value*300*Time.deltaTime*Input.GetAxis("Mouse X"));
            else if (Input.GetAxis("Mouse X") > 0)
               transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + sensi.GetComponent<Slider>().value * 300 * Time.deltaTime * Input.GetAxis("Mouse X"));
            if (Input.GetAxis("Mouse Y") < 0)
               transform.position = new Vector3(transform.position.x, transform.position.y + sensi.GetComponent<Slider>().value * 300 * Time.deltaTime * Input.GetAxis("Mouse Y"), transform.position.z);
            else if (Input.GetAxis("Mouse Y") > 0)
               transform.position = new Vector3(transform.position.x, transform.position.y + sensi.GetComponent<Slider>().value * 300 * Time.deltaTime * Input.GetAxis("Mouse Y"), transform.position.z);
        }
        //mouse stuff
        if (Input.GetMouseButtonDown(0))
        {
            closed.GetComponent<Image>().enabled = true;
            open.GetComponent<Image>().enabled = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            open.GetComponent<Image>().enabled = true;
            closed.GetComponent<Image>().enabled = false;
        }
    }
}
