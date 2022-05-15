using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPanelControls : MonoBehaviour
{
    public List<GameObject> BandaidIcons = new List<GameObject>();
    private int numHealth = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (numHealth < BandaidIcons.Count)
            {
                numHealth++;
                // TODO: start popup animation of new bandaid icon
                BandaidIcons[numHealth - 1].GetComponent<Animator>().Play("HealthIncrease");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (numHealth > 0)
            {
                BandaidIcons[numHealth - 1].GetComponent<Animator>().Play("HealthDecrease");
                numHealth--;
            }
        }

    }
}
