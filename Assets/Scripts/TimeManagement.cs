using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagement : MonoBehaviour
{

    public float roundTime;
    public float callTime;

    // Start is called before the first frame update
    private void Start()
    {
        // Access the global variables from TimesManager
        TimesManager.RoundTime = roundTime;
        TimesManager.CallTime = callTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
