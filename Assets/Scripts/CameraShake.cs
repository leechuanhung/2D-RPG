using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //카메라 흔들기
    public float ShakeAmount;
    float ShakeTime;
    Vector3 initialPosition;
    public void VibrateForTime(float time)
    {
        ShakeTime = time;
    }

    private void Update()
    {
        initialPosition = GameObject.FindWithTag("MainCamera").transform.position;//카메라 흔들릴 위치값
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
            transform.position = initialPosition;
        }
    }
    //public Camera mainCamera;
    //Vector3 cameraPos;

    //[SerializeField][Range(0.01f, 0.1f)] float shakeRange = 0.05f;
    //[SerializeField][Range(0.1f, 1f)] float duration = 0.5f;

    //public void Shake()
    //{
    //    cameraPos = mainCamera.transform.position;
    //    InvokeRepeating("strartShake", 0f, 0.005f);
    //    Invoke("StopShake", duration);
    //}

    //void StartShake()
    //{
    //    float cameraPosX = Random.value * shakeRange * 2 - shakeRange;
    //    float cameraPosY = Random.value * shakeRange * 2 - shakeRange;
    //    Vector3 cameraPos = mainCamera.transform.position;
    //    cameraPos.x = cameraPosX;
    //    cameraPos.y = cameraPosY;
    //    mainCamera.transform.position = cameraPos;
    //}

    //void StopShake()
    //{
    //    CancelInvoke("StartShake");
    //    mainCamera.transform.position = cameraPos;
    //}
}
