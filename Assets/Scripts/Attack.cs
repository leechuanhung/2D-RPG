using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float AttackDamge = 5f;

    private void Update()
    {
        transform.localPosition = Vector3.zero;
    }
}