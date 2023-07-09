using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NotificationController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        
        CallController child = GetComponentInChildren<CallController>(); 
        child.isCalled += HandleChildFunctionCalled;
    }

    private void HandleChildFunctionCalled(){
        isActive = true;
        
        TimerController timer = GetComponentInChildren<TimerController>();
        timer.isDestroy += HandleChildDestroyCalled;
        
        Debug.Log("Child function called!");
        if (button != null){
            button.interactable = true;
        }
    }

    private void HandleChildDestroyCalled(){
        isActive = false;
        Debug.Log("Child Delete!");
        if (button != null){
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button != null && !isActive)
        {
            button.OnSelect(eventData);
        }
        else 
            button.OnDeselect(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (button != null)
        {
            button.OnDeselect(eventData);
        }
    }

    
}
