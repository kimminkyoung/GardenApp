using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    float totalTime = 4;
    bool checkStart = false;

    public GameObject alarmUi;
    public QRfind ins_QRfind;

    private void OnEnable()
    {
        checkStart = true;
    }
    private void OnDisable()
    {
        totalTime = 4;
        checkStart = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkStart)
        {
            totalTime -= Time.deltaTime;
            GetComponent<Text>().text = ((int)totalTime).ToString();
            if(totalTime <= 0)
            {
                checkStart = false;
                alarmUi.SetActive(false);
                ins_QRfind.StartCapturing();
                //capturing;
            }
        }
    }

}
