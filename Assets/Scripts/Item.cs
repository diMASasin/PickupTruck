using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _outlineMaterial;


    public void SetOutlineMaterial() => _meshRenderer.material = _outlineMaterial;
    public void SetDefaultMaterial() => _meshRenderer.material = _defaultMaterial;
}
