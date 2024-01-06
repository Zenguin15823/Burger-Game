using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    private float timer = 0;
    private int done = 0;
    public GameObject burger;
    public GameObject title;
    public GameObject button;
    public GameObject intro;
    public GameObject game;
    public GameObject boomer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5 && done == 0)
        {
            done = 1;
            ApplyExplosionForce();
        }
        if (timer > 5.2 && done == 1)
        {
            burger.SetActive(true);
            done = 2;
        }
        if (timer > 5.5 && done == 2)
        {
            Color c = title.GetComponent<Text>().color;
            title.GetComponent<Text>().color = new Color(c.r, c.g, c.b, c.a + 0.6f*Time.deltaTime);
            if (c.a >= 1) done = 3;
        }
        if (timer > 5.5 && done == 3)
        {
            button.SetActive(true);
            Color c = button.GetComponent<Image>().color;
            Color d = button.GetComponentInChildren<Text>().color;
            button.GetComponent<Image>().color = new Color(c.r, c.g, c.b, c.a + 0.6f*Time.deltaTime);
            button.GetComponentInChildren<Text>().color = new Color(d.r, d.g, d.b, d.a + 0.6f*Time.deltaTime);
            if (c.a >= 1) done = 4;
        }

    }
    public void ApplyExplosionForce()
    {
        float explosionForce = 200.0f;
        float affectedRadius = 50.0f;

        Collider[] colliders = Physics.OverlapSphere(transform.position, affectedRadius);

        foreach (Collider affectedObjects in colliders)
        {
            if (affectedObjects.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(explosionForce, boomer.transform.position, affectedRadius, 1.0f, ForceMode.Impulse);
        }
    }
    public void StartGame()
    {
        game.SetActive(true);
        intro.SetActive(false);
    }
}
