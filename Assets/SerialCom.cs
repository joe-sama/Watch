using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;


public class SerialCom : MonoBehaviour
{

    public string port = "COM13";
    public int baudRate = 9600;
     //to know when th next data arrives to prevent repeating data with every update 
    
 
        public bool Activation = false;

    
    //Mit normalem String?
    //public string stringtest;

    private SerialPort serialPort;

    private bool streamingIsPossible = false;

    //Variablen für Sensordaten
    public double t;
    static public int b, bpm, dist, steps, c, o;
    public int temp;                  //Temperature
    public float ax, ay, az;            //Acceleration
    public float rx, ry, rz;            //Rotation    
    public float roll, pitch, yaw;      //Euler Angles
    public float w, x, y, z;            //Quaternions    
    public Vector3 eulerangles;
    private Quaternion quat;
    float timet = 0;
    float errorTimer = 0;



    // Start is called before the first frame update
    
    void Start()
    {
        OpenGate(); //create the port and start reading
  
    }

    

        //Update is called once per frame
    void Update()
        {
        if (streamingIsPossible && Time.time > timet)
        {
          //  t = Time.time;
            timet += 0.25f; //read data every 0.25 second
            
            string sensorData = ReadSerialPort();

            if (sensorData != null)
            {
                Activation = true; //activation indicator for the watch ui
                UpdateVariables(sensorData);
                errorTimer = 0; //reset error timer
            }
        
        else 
            {
               
                errorTimer = errorTimer + 0.25f; //restart the serial if for approx 2 sec cant access serial 
                if (errorTimer > 8* 0.25f)
                { Debug.Log("Arduino Disconnected");
                Activation = false; //activation indicator for the watch ui
                }

            }

        }


        if (errorTimer > 10)//restart the serial if approx 5 sec cant access serial 
        {

            Debug.Log("Restarting");
            OpenGate();
            timet = Time.time;


        }
    }


        //CustomFunktionen


        //Liest vorhandene Variablen aus dem Json-String und updated diese 
        public void UpdateVariables(string jsonstring)
    {
        JsonUtility.FromJsonOverwrite(jsonstring, this);
    }




    //OPEN PORT
    public void OpenGate()
    {
        streamingIsPossible = true;
        serialPort = new SerialPort(port, baudRate);
        serialPort.Open();
        serialPort.ReadTimeout = 25; //important to not get stuck trying to read empty serial
        Debug.Log("The Port is Open");
    }


    //READ PORT
    public string ReadSerialPort()
    {
        string data;
        try
        {
            data = serialPort.ReadLine();
            return data;
        }
        catch (System.Exception e)
        {
            return null;
        }
    }


    //CLOSE PORT
    public void CloseGate()
    {
        serialPort.Close();
    }



}
