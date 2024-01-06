using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Detector : MonoBehaviour
{
    private List<GameObject> stuff = new List<GameObject>();
    public Texter text;
    public Camera cammie, endcam;
    public GameObject leader, scoreser, timered, playbut, quitbut, objecties, prefaber;
    private int timer;
    private float timmy;
    private void Start()
    {
        timer = text.getList().Count * 10;
        timmy = 0;
        timered.GetComponent<TMPro.TextMeshProUGUI>().text = "" + timer;
    }
    private void Update()
    {
        timmy += Time.deltaTime;
        if (timmy >= 1)
        {
            timer -= 1;
            timered.GetComponent<TMPro.TextMeshProUGUI>().text = "" + timer;
            timmy = 0;
        }

        if (timer <= 0 || Input.GetKeyDown(KeyCode.O))
        {
            scoreIt();
        }
    }

    private void scoreIt()
    {
        GameObject[] sord = stuff.ToArray();
        for (int x = 0; x < sord.Length - 1; x++)
        {
            int sm = x;
            for (int y = x + 1; y < sord.Length; y++)
            {
                if (sord[y].transform.position.y < sord[sm].transform.position.y) sm = y;
            }
            GameObject temp = sord[x];
            sord[x] = sord[sm];
            sord[sm] = temp;
        }

        int score = 50;

        List<String> stuffers = new List<String>();
        for (int x = 0; x < sord.Length; x++)
            stuffers.Add(sord[x].name);
        for (int x = 0; x < text.greds.Count; x++)
        {
            if (stuffers.Contains(text.greds[x]))
                stuffers.Remove(text.greds[x]);
            else score -= (50 / text.greds.Count);
        }

        List<String> puffers = new List<string>();
        for (int x = 0; x < sord.Length; x++)
            puffers.Add(sord[x].name);
        List<String> testers = new List<string>();
        for (int x = 0; x < text.greds.Count; x++)
            testers.Add(text.greds[x]);

        for (int x = puffers.Count - 1; x >= 0; x--)
            if (puffers[x].Equals("Lettuce") || puffers[x].Equals("Tomato") || puffers[x].Equals("Onion"))
                puffers.RemoveAt(x);
        for (int x = testers.Count - 1; x >= 0; x--)
            if (testers[x].Equals("Lettuce") || testers[x].Equals("Tomato") || testers[x].Equals("Onion"))
                testers.RemoveAt(x);
        puffers.Reverse();

        /*string hey = "";
        for (int x = 0; x < puffers.Count; x++)
            hey += puffers[x] + " ";
        print("puffers: " + hey);
        hey = "";
        for (int x = 0; x < testers.Count; x++)
            hey += testers[x] + " ";
        print("testers: " + hey);
        hey = "";
        for (int x = 0; x < text.greds.Count; x++)
            hey += text.greds[x] + " ";
        print("greds: " + hey);*/

        for (int x = 0; x < puffers.Count && x < testers.Count; x++)
        {
            if (puffers[x].Equals(testers[x])) score += 50 / testers.Count;
        }

        for (int x = 0; x < stuff.Count; x++)
        {
            if (stuff[x].name.Equals("Patty") && stuff[x].GetComponent<Renderer>().material.color.r > .555 || stuff[x].GetComponent<Renderer>().material.color.r < .150) score -= 25;
            else if (!stuff[x].name.Equals("Plate") && stuff[x].GetComponent<Renderer>().material.color.r < .02) score -= 10;
        }

        if (score < 0) score = 0;

        //now change the scren

        cammie.enabled = false;
        endcam.enabled = true;
        leader.GetComponent<Camerasc>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        leader.GetComponent<Camerasc>().open.GetComponent<Image>().enabled = false;
        leader.GetComponent<Camerasc>().closed.GetComponent<Image>().enabled = false;
        timered.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        scoreser.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        scoreser.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score;
        playbut.SetActive(true);
        quitbut.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        stuff.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        stuff.Remove(other.gameObject);
    }
    public void rePlay()
    {
        if (objecties != null) Destroy(objecties);
        objecties = Instantiate(prefaber);
        timer = text.getList().Count * 10;
        timmy = 0;
        cammie.enabled = true;
        endcam.enabled = false;
        leader.GetComponent<Camerasc>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        leader.GetComponent<Camerasc>().open.GetComponent<Image>().enabled = true;
        timered.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        timered.GetComponent<TMPro.TextMeshProUGUI>().text = "" + timer;
        scoreser.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        playbut.SetActive(false);
        quitbut.SetActive(false);
        stuff.Clear();
    }
    public void QuitIt()
    {
        Application.Quit();
    }
}
