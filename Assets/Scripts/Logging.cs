using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Logging : MonoBehaviour
{
    public SerialCom serialCom;
    //public ScoreCount scoreCount;
    //public phaseControl phaseControl;
    //public Eyetracking eyetracking;


    string filepath;
    StreamWriter tw;
    float timePassed = 1f;
    bool isActive = false;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //C:\Users\VR\Desktop\VR TESTING - Copy\Experiment\Logs
    //    filepath = "C:/Users/VR/Desktop/SQUASH LOGS/" + DateTime.UtcNow.ToLocalTime().ToString("yyyyMMMMddHHmm") + ".csv";
    //    tw = new StreamWriter(filepath, true);
    //}

    public void StartLogging(string dashboardPlacement)
    {
        filepath = "C:/Users/VR/Desktop/SQUASH LOGS/" + DateTime.UtcNow.ToLocalTime().ToString("yyyyMMMMddHHmm") + dashboardPlacement + ".csv";
        tw = new StreamWriter(filepath, true);
        isActive = true;
    }


    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (isActive)
        {
            WriteCSV();
        }

        //if (timePassed < 1f)
        //{
        //    return;
        //}

        //timePassed = 0f;

        //if (serialCom.b_acc)
        //{
        //    WriteCSV();
        //    serialCom.b_acc = false;
        //}


    }

    public void PauseLogging(bool isPaused)
    {
        isActive = !isPaused;
    }

    public void StopLogging()
    {
        tw.Close();
        isActive = false;
    } 


    void OnApplicationQuit()
    {
        //tw.Dispose();
    }


    public void WriteCSV()
    {
        //tw.WriteLine(DateTime.UtcNow.ToLocalTime().ToString("HHmmss") + ","  + serialCom.ax.ToString() + "," + serialCom.ay.ToString() + "," + serialCom.az.ToString() 
        //    + "," + serialCom.rx.ToString() + "," + serialCom.ry.ToString() + "," + serialCom.rz.ToString()
        //     + "," + serialCom.b.ToString() + "," + serialCom.c.ToString() + "," + Calories.CaloriesLogs.ToString() + "," + scoreCount.scoreText.text + "," + phaseControl.averageIn.ToString());

        //tw.WriteLine(DateTime.UtcNow.ToLocalTime().ToString("HHmmss") + "," + SerialCom.b.ToString() + "," + SerialCom.c.ToString() + "," + Calories.CaloriesLogs.ToString() + "," + scoreCount.scoreText.text
        //     + "," + phaseControl.averageIn.ToString() + "," + eyetracking.origin.x.ToString() + "," + eyetracking.origin.y.ToString() + "," + eyetracking.origin.z.ToString() + "," + eyetracking.direction.x.ToString()
        //     + "," + eyetracking.direction.y.ToString() + "," + eyetracking.direction.z.ToString() + "," + eyetracking.dashboardHit.ToString());

        //tw.Close(); // if used , a new stream writer has to be opened
    }

}
