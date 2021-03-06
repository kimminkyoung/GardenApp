﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;
using System.IO;

public class QRfind : MonoBehaviour
{
    //static QRfind QRinstant;
    TrackableBehaviour insTrack;
    TrackableBehaviour.Status previous;

    public CameraSwitch ins_switch;

    public GameObject alarmUI;
    public GameObject targetOBJ;
    public GameObject targetOBJ2;
    public GameObject test;
    public string textureName;

    bool checkCapture = false;
    Vector2 captureOrigin;
    Vector2 captureArea;

    // Start is called before the first frame update
    void Start()
    {
        insTrack = GetComponent<TrackableBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus(previous);
        previous = insTrack.CurrentStatus;
    }

    public void CheckChangableObject(string plantName)
    {
        textureName = plantName;
    }

    public void CheckStatus(TrackableBehaviour.Status previousStatus)
    {
        if (insTrack.CurrentStatus == TrackableBehaviour.Status.TRACKED ||
            insTrack.CurrentStatus == TrackableBehaviour.Status.DETECTED)
            TrackFound();
        if (previousStatus == TrackableBehaviour.Status.TRACKED &&
            insTrack.CurrentStatus == TrackableBehaviour.Status.NO_POSE)
            TrackLost();
    }

    public void TrackFound()
    {
        print("my custom track found!");
        SizeCalculation();
        if (!checkCapture)
        {
            alarmUI.SetActive(true);
            checkCapture = true;
        }
    }
    public void TrackLost()
    {
        print("my custom track lost!");
        alarmUI.SetActive(false);
        checkCapture = false;
    }

    public void SizeCalculation()
    {
        if(!targetOBJ.GetComponent<Renderer>().enabled || !targetOBJ2.GetComponent<Renderer>().enabled)
            return;
        print("계산중");

        Vector3 pos1 = targetOBJ.GetComponent<Transform>().position;
        Vector3 pos2 = targetOBJ2.GetComponent<Transform>().position;

        test.transform.position = (pos1 + pos2) / 2;

        Vector2 screenPos1 = Camera.main.WorldToScreenPoint(pos1);
        Vector2 screenPos2 = Camera.main.WorldToScreenPoint(pos2);

        Vector2 captureSize = new Vector2(screenPos2.x - screenPos1.x, screenPos2.y - screenPos1.y);
        captureOrigin = screenPos1;
        captureArea = captureSize;
    }

    public void StartCapturing()
    {
        StartCoroutine(Capture());
    }

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();
        SizeCalculation();

        //Vector2 captureArea = new Vector2(1920, 1080);
        Texture2D captureTexture = new Texture2D((int)captureArea.x, (int)captureArea.y, TextureFormat.RGB24, false);
        captureTexture.ReadPixels(new Rect(captureOrigin.x, captureOrigin.y, captureTexture.width, captureTexture.height), 0, 0);

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            byte[] bytes = captureTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(Path.Combine(Application.persistentDataPath, textureName + ".png"), bytes);

            ins_switch.SwitchToGame(textureName, Application.persistentDataPath);
        }
        else
        {
            byte[] bytes = captureTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(Path.Combine("D:/unity2020/GardenApp/Project_GardenApp/Assets/SavePhoto", textureName + ".png"), bytes);

            ins_switch.SwitchToGame(textureName, "D:/unity2020/GardenApp/Project_GardenApp/Assets/SavePhoto");
        }

        textureName = null;
    }
}

