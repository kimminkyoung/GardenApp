using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGardener : MonoBehaviour
{
    public FTPDownload ins_FTPDown;
    public void SelectedName()
    {
        string gardenerName = gameObject.GetComponentInChildren<Text>().text;
        //다운로드
        //오픈씬

        ins_FTPDown.FTPFileDownload(gardenerName);
    }
}
