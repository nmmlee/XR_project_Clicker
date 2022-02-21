using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBoard : MonoBehaviour
{
    public LayerMask layerMask;
    public Camera Camera;
    Vector3 MousePosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition); // ��ǥ ��ȯ
            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 1f, layerMask);

            if (hit) // Clickboard�� ������ �� ���� ��ȭ ȹ��
            {
                int goldPerClick = DataController.GetInstance().GetGoldPerClick();
                DataController.GetInstance().AddGold(goldPerClick);
                DataController.GetInstance().AddTotalGold(goldPerClick);
            }
        }
    }
}
