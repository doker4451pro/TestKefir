using TMPro;
using UnityEngine;

[RequireComponent(typeof(InteractedVertex))]
public class VisualizationVertex : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private MaterialsInfo _materialsInfo;
    
    private InteractedVertex _vertexInteract;
    private Vertex _vertex;
    private SpriteRenderer _renderer;
    private Material _currentMaterial;

    private void Awake()
    {
        _vertexInteract = GetComponent<InteractedVertex>();
        _vertex = GetComponent<Vertex>();
        _renderer = GetComponent<SpriteRenderer>();
        _currentMaterial = _materialsInfo.NotStudied;
    }

    private void Start()
    {
        _textMesh.text = _vertex.Price.ToString();
        _renderer.material = _currentMaterial;
    }

    private void OnEnable()
    {
        _vertexInteract.OnBecomeChosenAction+=BecomeChosenAction;
        _vertexInteract.OnStopBeingChosenAction+=StopBeingChosenAction;
        _vertex.OnChangeVertexState += ChangeVertexColor;
    }
    
    private void OnDisable()
    {
        _vertexInteract.OnBecomeChosenAction-=BecomeChosenAction;
        _vertexInteract.OnStopBeingChosenAction-=StopBeingChosenAction;
        _vertex.OnChangeVertexState -= ChangeVertexColor;
    }
    
    private void ChangeVertexColor(VertexState newState)
    {
        _currentMaterial = newState == VertexState.Studied ? _materialsInfo.Studied : _materialsInfo.NotStudied;
        _renderer.material = _currentMaterial;
    }
    
    private void StopBeingChosenAction()
    {
        _renderer.material = _currentMaterial;
    }

    private void BecomeChosenAction()
    {
        _renderer.material = _materialsInfo.Highlight;
    }
}
