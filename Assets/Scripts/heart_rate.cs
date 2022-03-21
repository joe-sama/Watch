using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class heart_rate : MonoBehaviour
{
    public SerialCom serialCom;
    public Text displayedtext;
    private float nextActionTime = 0;
    private float period = 0f;
    static public int  oldtrustedbeat = 0;
    GameObject BPM_TextGameObject;
    Text HeartRateText;

    // Start is called before the first frame update
    void Start()
    {

        BPM_TextGameObject = GameObject.Find("BPM_Text");
        HeartRateText = BPM_TextGameObject.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (SerialCom.b !=0 && SerialCom.c >=95)
            {
                oldtrustedbeat = SerialCom.b;
            }
        }
        
        else displayedtext.text = oldtrustedbeat.ToString();
        HeartRateText.text = oldtrustedbeat.ToString();
    }
}
