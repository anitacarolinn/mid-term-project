using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer m_renderer;

    public float animationspeed = 1f;

    private void Awake()
    {
        m_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_renderer.material.mainTextureOffset += new Vector2(Time.deltaTime * animationspeed, 0);
    }
}
