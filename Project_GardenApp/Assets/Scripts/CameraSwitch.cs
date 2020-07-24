using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject GameCamera;
    public GameObject ArCamera;

    public void SwitchToAR()
    {
        GameCamera.SetActive(false);
        ArCamera.SetActive(true);
    }

    public void SwitchToGame()
    {
        GameCamera.SetActive(true);
        ArCamera.SetActive(false);
    }
}
