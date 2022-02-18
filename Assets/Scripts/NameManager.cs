using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public string input;
    public Text nameText;
    public void ReadStringInput(string s)
    {
        input = s;
        nameText.text = "¿Ã∏ß : " + s;
    }
}
