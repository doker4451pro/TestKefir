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

    public void OnClickOnGiveSkillPointButton()
    {
        _ui.ChangeSkillPoint();
        ChooseVertex(null);
    }

    public void OnClickOnSkillButton(bool isLearn)
    {
        _ui.ChangeSkillState(_selectedVertex,isLearn);
        ChooseVertex(null);
    }
    
    public void OnClickOnForgetAllButton()
    {
        _ui.ForgetAllSkill();
        ChooseVertex(null);
    }
    
    public void ChooseVertex(InteractedVertex vertex)
    {
        if(_selectedVertex!=null)
            _selectedVertex.StopBeingChosen();
        
        _selectedVertex = vertex;
        OnSelectNewVertex?.Invoke(_selectedVertex);
        
        if(_selectedVertex)
            _selectedVertex.BecomeChosen();
    }
    
}
