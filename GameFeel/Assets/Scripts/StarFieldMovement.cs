using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldMovement : MonoBehaviour
{
    public GameObject spaceShip;
    public float movementScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = -spaceShip.transform.position * movementScale;
    }
}
