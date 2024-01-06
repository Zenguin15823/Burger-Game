using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texter : MonoBehaviour
{
    public List<string> greds;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public List<string> getList()
    {
        Reset();
        return greds;
    }

    private void Reset()
    {
        greds = new List<string>();
        greds.Add("Top Bun");
        for (int x = 0; x < (int)(1 + Random.value*5); x++)
        {
            int i = (int)(Random.value*6);
            if (i == 0) greds.Add("Patty");
            else if (i == 1) greds.Add("Cheese");
            else if (i == 2) greds.Add("Lettuce");
            else if (i == 3) greds.Add("Onion");
            else if (i == 4) greds.Add("Tomato");
            else if (i == 5) greds.Add("Bottom Bun");
        }
        if (!greds.Contains("Patty")) greds.Add("Patty");
        greds.Add("Bottom Bun");
        greds.Add("Plate");

        string great = "Current Order:\n";
        for (int x = 0; x < greds.Count; x++)
        {
            great += greds[x] + "\n";
        }

        GetComponent<TMPro.TextMeshProUGUI>().text = great;
    }
}
