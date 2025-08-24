using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll4 : MonoBehaviour
{

    Material material;
    Vector2 offset;

    public int xVelocity,yVelocity;

    private void Awake()
    {
        material = GetComponent<Renderer>().material; // Gets access to renderer component and then able to access the material attatched to the game object
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xVelocity,yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime; // mainTextureOffset Gives access to offset of the texture
    }
}
