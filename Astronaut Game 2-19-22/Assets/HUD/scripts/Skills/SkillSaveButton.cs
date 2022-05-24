using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillSaveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool Saved = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Saved = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Saved = false;
    }
}
