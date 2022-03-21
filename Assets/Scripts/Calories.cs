using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calories : MonoBehaviour
{

    static public Text text;

    private bool startMessureCal = false;

    //user Gender
     public bool male = false;
     public bool female = false;

    //user parameter
    int oxygen = 0;
    public double age = 20;
    public double weight = 50f;

    //calories berechnen
    private double caloriesPur = 0.0f;
    public double caloriesAusgabe = 0f;
    public double bpm = 0;
    
    private float nextActionTime = 0;
    private float period = 10f;
    public static double CaloriesLogs=0; //used for printing logs only
    GameObject Calories_TextGameObject;
    Text CaloriesText;


    private void Start()
    {
        Calories_TextGameObject = GameObject.Find("Calories_Text");
        CaloriesText = Calories_TextGameObject  .gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    private void Update()
    {
        bpm = heart_rate.oldtrustedbeat;
        oxygen = SerialCom.o;


        if (Input.GetKeyDown("space")) //////////////////////////////////////////////////// STARTING THE CALORIES ////////////////////////////////
        {
            startMessureCal = true;
            nextActionTime = Time.time - 0.1f;
        }

    
        if (Time.time > nextActionTime && startMessureCal)
        { 
            nextActionTime += period;
            if (male == true && female == false)
            {
                caloriesAusgabe += CaloriesCalculationMale();

            }
            if (male == false && female == true)
            {
                caloriesAusgabe += CaloriesCalculationFemale();
            }


            text.text = caloriesAusgabe.ToString();
            CaloriesLogs = caloriesAusgabe;

           
        }


        CaloriesText.text = caloriesAusgabe.ToString();



    }

    private double CaloriesCalculationMale()
    {
        caloriesPur = (-95.7735 + (0.271 * age) + (0.394 * weight * 2.20462262185) + (0.404 * oxygen) + (0.634 * bpm)) / 4.184;
        return (0.166666f) * caloriesPur;

    }

    private double CaloriesCalculationFemale()
    {
        caloriesPur= (-59.3954 + (0.274 * age) + (0.103 * weight* 2.20462262185) + (0.380 * oxygen) + (0.450 * bpm)) / 4.184;
        Debug.Log(caloriesPur);
        return (0.166666f) * caloriesPur;
    }
}