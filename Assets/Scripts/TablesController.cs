using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TablesController : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public int tables;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tables; i++)
        {
            Instantiate(prefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
