using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(InteractedVertex))]
public class VisualizationVertex : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private MaterialsInfo _materialsInfo;
    
    private InteractedVertex _vertex;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _vertex = GetComponent<InteractedVertex>();
        _renderer = GetComponent<SpriteRenderer>();
        _textMesh.text = _vertex.Prise.ToString();
    }
    
    private void OnEnable()
    {
        _vertex.BecomeChosenAction+=BecomeChosenAction;
        _vertex.StopBeingChosenAction+=StopBeingChosenAction;
    }

    private void OnDisable()
    {
        _vertex.BecomeChosenAction-=BecomeChosenAction;
        _vertex.StopBeingChosenAction-=StopBeingChosenAction;
    }
    
    private void StopBeingChosenAction()
    {
        _renderer.material = _materialsInfo.NotStudied;
    }

    private void BecomeChosenAction()
    {
        _renderer.material = _materialsInfo.Studied;
    }
}
