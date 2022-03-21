using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class watchDate : MonoBehaviour
{
    Text dateText;
    Text timeText;
    DateTime dateTime;
    // Start is called before the first frame update
    void Start()
    {
        dateText = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DateTime dateTime = DateTime.Now;
        dateText.text = DateTime.UtcNow.ToLocalTime().ToString("dd.MM.yyyy");
       // timeText.text = dateTime.ToShortTimeString();
    }
}
