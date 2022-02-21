using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject StartButton;

    public void GoGameScene()
    {
        SceneManager.LoadScene(1);
    }


}
