using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    public float orthoZoomSpeed = 0.5f;
    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchOne = Input.GetTouch(0);//첫번째 손가락 좌표
            Touch touchTwo = Input.GetTouch(1);//두번째 손가락 좌표

            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;//움직이기 전의 손가락 위치
            Vector2 touchTwoPrevPos = touchTwo.position - touchTwo.deltaPosition;

            float preTouchDelta = (touchOnePrevPos - touchTwoPrevPos).magnitude;// 움직임의 크기
            float touchDelta = (touchOne.position - touchTwo.position).magnitude;//현재 위치 크기

            float deltaMagDiff = preTouchDelta - touchDelta;//얼마큼 확대, 축소 할지
            
            GetComponent<Camera>().orthographicSize += deltaMagDiff * orthoZoomSpeed;//줌인, 아웃
            GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);//사이즈가 0아래로 안떨어지도록함
            
        }
    }
}
