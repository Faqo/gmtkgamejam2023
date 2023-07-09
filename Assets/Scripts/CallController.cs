using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallController : MonoBehaviour
{
    private bool isCalling = false;
    public float callCooldown;

    [SerializeField] GameObject callPromp;
    // Start is called before the first frame update

    private void Start()
    {
        // Start the coroutine to trigger the action randomly
        StartCoroutine(TriggerRandomAction());
    }

    private IEnumerator TriggerRandomAction()
    {
        while (true)
        {
            // Generate a random time interval
            float randomTime = Random.Range(1.0f, TimesManager.RoundTime/2);
            yield return new WaitForSeconds(randomTime);

            // Check if the action is active
            if (!isCalling)
            {
                // Perform the action
                PerformAction();
                yield return new WaitForSeconds(callCooldown);
            }
        }
    }

    private void PerformAction()
    {
        // Replace this with the actual action you want to perform
        Debug.Log("Action performed!");
        Instantiate(callPromp, transform);
    }

    // Method to activate or deactivate the action
    public void SetActionActive(bool isActive)
    {
        isCalling = isActive;
    }
}
