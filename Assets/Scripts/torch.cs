using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    public GameObject OBJtorch;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OBJtorch.SetActive(!OBJtorch.activeSelf); // Toggle the torch
        }
    }
}
