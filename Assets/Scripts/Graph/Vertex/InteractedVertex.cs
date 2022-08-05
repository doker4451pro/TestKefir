using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(Vertex))]
public class InteractedVertex : MonoBehaviour, IPointerClickHandler
{
    public Action OnBecomeChosenAction;
    public Action OnStopBeingChosenAction;

    [Inject] private UIInteract _uiInteract;
    [Inject] private LearningPlayer _player;

    private Vertex _vertex;

    public Vertex Vertex
    {
        get { return _vertex; }
    }

    private void Awake()
    {
        _vertex = GetComponent<Vertex>();
    }

    public void LearnSkill()
    {
        _vertex.BuySkillTo(_player);
    }

    public void ForgetSkill()
    {
        _vertex.SellSkillTo(_player);
    }
    

    #region UI Part
    public void BecomeChosen()
    {
        OnBecomeChosenAction?.Invoke();
    }

    public void StopBeingChosen()
    {
        OnStopBeingChosenAction?.Invoke();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _uiInteract.ChooseVertex(this);
    }
    #endregion
}
