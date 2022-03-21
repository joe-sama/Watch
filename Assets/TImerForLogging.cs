using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.Events;

public class TImerForLogging : MonoBehaviour
{
    Stopwatch timer;
    bool isTimerRunning = false;

    public Text text;
    public float Threshold = 0.1f;
    public float deadzone = 0.25f;
    public UnityEvent onPressed, onReleased;
    bool isPressed;
    Vector3 StartPosition;
    ConfigurableJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        text.text = timer.ToString();

        StartPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + Threshold >= 1)
        {
            Pressed();
        }

        if (isPressed && GetValue() - Threshold <= 0)
        {
            Released();
        }
    }

    float GetValue()
    {
        var value = Vector3.Distance(StartPosition, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadzone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);

    }

    void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
    }
    void Released()
    {
        isPressed = false;
        onReleased.Invoke();
    }
    public void StartTimre()
    {
        if (isTimerRunning == false)
        {
            timer.Start();
            isTimerRunning = true;
        }
        else
        {
            timer.Stop();
            isTimerRunning = false;
        }
    }
}


    

