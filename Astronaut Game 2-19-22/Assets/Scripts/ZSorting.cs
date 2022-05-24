using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSorting : MonoBehaviour
{
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spr.sortingOrder = (int)(transform.position.z * -10);
    }
}
