using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilAnimation : MonoBehaviour
{

    
    int what;

    // Start is called before the first frame update
    void Start()
    {
        what = 1;
        InvokeRepeating("PencilRotate", 1.3f,1.3f);
    }

    // Update is called once per frame
    void PencilRotate()
    {

        RectTransform pencilRectTransform = GetComponent<RectTransform>();
        if (what == 1 )
        {
            pencilRectTransform.rotation = Quaternion.Euler(0, 0, -5f);
            what = 0;
        }
        else if(what == 0)
        {
            pencilRectTransform.rotation = Quaternion.Euler(0, 0, 0);
            what = 1;
        }
    }
}
