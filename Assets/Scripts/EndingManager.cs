using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject dataController;
    public GameObject prefebEndingText;
    public Transform parent;

    private void Awake()
    {
        dataController = GameObject.Find("DataController");

    }

    void Start()
    {
        /*
        for (int i = 0; i < dataController.GetComponent<DataController>().nameNumber - 1; i++)
        {
            GameObject child = Instantiate(prefebEndingText, parent);
            child.transform.position = parent.transform.position + new Vector3(0, -i * 50, 0);
        }
        */

    }

    void Update()
    {

    }
}
