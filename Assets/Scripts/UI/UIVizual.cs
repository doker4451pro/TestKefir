using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(UIInteract))]
public class UIVizual : MonoBehaviour
{
    [Inject] private LearningPlayer _player;
    [Inject] private UIInteract _uiInteract;

    [SerializeField] private GameObject _learnButton;
    [SerializeField] private GameObject _forgetButton;
    [SerializeField] private TextMeshProUGUI _textMeshSkillPoint;

    private UI _ui;

    private void Awake()
    {
        _ui = GetComponent<UI>();
    }

    private void OnEnable()
    {
        _uiInteract.OnSelectNewVertex += VisualizeButtons;
        _player.OnSkillPointChange += VisualizeTextStillPoint;
    }

    private void OnDisable()
    {
        _uiInteract.OnSelectNewVertex -= VisualizeButtons;
        _player.OnSkillPointChange -= VisualizeTextStillPoint;
    }
    
    private void VisualizeTextStillPoint(int skillPoint)
    {
        _textMeshSkillPoint.text = skillPoint.ToString();
    }
    
    private void VisualizeButtons(InteractedVertex vertex)
    {
        if (vertex == null)
        {
            _learnButton.SetActive(false);
            _forgetButton.SetActive(false);
            return;
        }
        
        _learnButton.SetActive(_ui.CanLearnSkillFrom(vertex.Vertex));
        _forgetButton.SetActive(_ui.CanForgetSkillFrom(vertex.Vertex));
    }
}
