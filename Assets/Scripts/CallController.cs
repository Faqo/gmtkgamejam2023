using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallController : MonoBehaviour
{
    private bool isCalling = false;
    public float callCooldown;

    [SerializeField] GameObject callPromp;

    public event System.Action isCalled;

    private void Start(){
        StartCoroutine(SpawnJudgeCall());
    }

    private IEnumerator SpawnJudgeCall(){
        while (true)
        {
            float randomTime = Random.Range(2.0f, TimesManager.RoundTime/2);
            yield return new WaitForSeconds(randomTime);

            if (!isCalling)
            {
                PerformAction();
                yield return new WaitForSeconds(callCooldown);
            }
        }
    }

    private void PerformAction(){
        Instantiate(callPromp, transform);
        if (isCalled != null)
        {
            isCalled.Invoke();
        }
    }

}
