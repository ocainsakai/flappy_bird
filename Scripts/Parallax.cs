using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;
    private void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();
    }
    //khoi tao meshRenderer
    void Update(){
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed*Time.deltaTime,0);
    }
    //thay doi offset cua material tao hieu ung chuyen dong
}
