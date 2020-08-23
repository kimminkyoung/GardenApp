using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject GameCamera;
    public GameObject ArCamera;
    public GameObject SelectUi;

    public QRfind ins_qrFind;
    public ChangeMaterial ins_change;

    public void CheckSelected()
    {
        if(ins_qrFind.textureName.Length <= 0 || ins_qrFind.textureName == null)
        {
            SelectUi.SetActive(true);
        }
        else
        {
            print(ins_qrFind.textureName);
            SwitchToAR();
        }
    }
    public void SwitchToAR()
    {
        GameCamera.SetActive(false);
        ArCamera.SetActive(true);
    }

    public void SwitchToGame(string name, string url)
    {
        GameCamera.SetActive(true);
        ArCamera.SetActive(false);

        ins_change.Change(name, url);
    }
}
