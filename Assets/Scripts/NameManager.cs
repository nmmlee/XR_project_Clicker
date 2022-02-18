using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public string input;
    public Text nameText;

    // 이름 입력
    public void ReadStringInput(string s)
    {
        input = s;
        nameText.text = "이름 : " + s;
    }
}
