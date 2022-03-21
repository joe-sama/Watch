using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class CheckBoxPress : MonoBehaviour
{
    Material material;
    float lastentry;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {   // Deadzone for the Collision
        if (lastentry - Time.time >= 0.25)
        {


            if (gameObject.name == "Toggle_BPM")
            {
                if (LogCheckBoxes.CheckBoxBpm == true)
                {

                    LogCheckBoxes.CheckBoxBpm = false;
                    //material.SetColor("_Color", Color.white);
                    Debug.Log("OFF");

                }
                else LogCheckBoxes.CheckBoxBpm = true;
                // material.SetColor("_Color", Color.green);
                Debug.Log("ON");

            }

            lastentry = Time.time;
        }
    }
}
