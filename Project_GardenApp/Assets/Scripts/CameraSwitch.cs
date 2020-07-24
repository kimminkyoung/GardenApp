using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject GameCamera;
    public GameObject ArCamera;

    public void Switch()
    {
        GameCamera.SetActive(false);
        ArCamera.SetActive(true);
    }
}
