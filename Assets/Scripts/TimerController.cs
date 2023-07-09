using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TimerController : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private Gradient uiFillGradient;
    private float Duration;
    private float remainingDuration;
    private GameObject parentObject;
    private float target = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        parentObject = transform.parent.gameObject;
        if(parentObject.name == "TimeTracker"){
            Duration = TimesManager.RoundTime;
        }
        else Duration = TimesManager.CallTime;
        
        Begin(Duration);
    }

    private void Begin(float seconds){
        remainingDuration = seconds;
        checkTimefillGradientAmount();
        StartCoroutine(UpdateTimer());
                
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            target = remainingDuration/Duration;
            checkTimefillGradientAmount();
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void checkTimefillGradientAmount(){
        uiFill.color = uiFillGradient.Evaluate(target);
    }

    private void OnEnd()
    {
        Destroy(parentObject);
        //End Time , if want Do something
        print("End");
    }

}
