using System;
using UnityEngine;

[RequireComponent(typeof(UI))]
public class UIInteract : MonoBehaviour
{
    public Action<InteractedVertex> OnSelectNewVertex;
    private InteractedVertex _selectedVertex;
    private UI _ui;
    
    private void Awake()
    {
        _ui = GetComponent<UI>();
    }

    public void ChooseVertex(InteractedVertex vertex)
    {
        if (vertex== null || _selectedVertex == vertex) 
            return;
        
        if(_selectedVertex!=null)
            _selectedVertex.StopBeingChosen();
        SelectNewVertex(vertex);
        _selectedVertex.BecomeChosen();
    }
    
    public void OnClickOnGiveSkillPointButton()
    {
        _ui.ChangeSkillPoint();
    }

    public void OnClickOnSkillButton(bool isLearn)
    {
        _ui.ChangeSkillState(_selectedVertex,isLearn);
        SelectNewVertex(null);
    }
    
    public void OnClickOnForgetAllButton()
    {
        _ui.ForgetAllSkill();
    }

    private void SelectNewVertex(InteractedVertex newVertex)
    {
        _selectedVertex = newVertex;
        OnSelectNewVertex?.Invoke(_selectedVertex);
    }
}
