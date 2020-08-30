using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingName : MonoBehaviour
{
    Text myName;
    public string GetName()
    {
        return GetComponent<InputField>().text;
    }
}
