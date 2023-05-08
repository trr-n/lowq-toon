using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
    [Obsolete]
    void Awake()
    {
        if (!FindObjectOfType<EventSystem>())
        {
            GameObject obj = new GameObject("EventSystem");
            obj.AddComponent<EventSystem>();
            obj.AddComponent<StandaloneInputModule>().forceModuleActive = true;
        }
    }
}
