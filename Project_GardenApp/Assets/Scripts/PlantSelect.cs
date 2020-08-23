using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class PlantSelect : MonoBehaviour
{
    public QRfind ins_qrFind;
    public void Select()
    {
        ins_qrFind.CheckChangableObject(gameObject.tag);
    }
}
