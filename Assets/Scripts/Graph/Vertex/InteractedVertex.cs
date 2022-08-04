using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(Vertex))]
public class InteractedVertex : MonoBehaviour, IPointerClickHandler
{
    public Action BecomeChosenAction;
    public Action StopBeingChosenAction;
    
    [Inject] private LearningPlayer _player;

    [SerializeField] private int _prise;
    
    public int Prise 
    {
        get
        {
            return _prise;
        }
    }


    #region Player Part
    public void BecomeChosen()
    {
        BecomeChosenAction?.Invoke();
    }

    public void StopBeingChosen()
    {
        StopBeingChosenAction?.Invoke();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _player.ChooseVertex(this);
    }
    #endregion

    #region Interface Part

    

    #endregion

}
