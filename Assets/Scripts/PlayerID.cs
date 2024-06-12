using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerID : MonoBehaviour
{

    public Text IdText;

    // Start is called before the first frame update
    void Start()
    {
        IdText.text = GameManager.Instance.UserID;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
