using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(this.gameObject.tag == "Cube")
        {
            Destroy(gameObject);
        }
    }
}