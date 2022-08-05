using System;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    public Action<VertexState> OnChangeVertexState;
    
    [SerializeField] private VertexState state;
    [SerializeField] private int _price;

    public int Price 
    {
        get
        {
            return _price;
        }
    }

    public VertexState State
    {
        get
        {
            return state;
        }
    }

    public void BuySkill()
    {
        ChangeVertexState(VertexState.Studied);
    }

    public void SellSkill()
    {
        ChangeVertexState(VertexState.NotStudied);
    }

    public void BuySkillTo(LearningPlayer player)
    {
        player.LearnSkill(this);
        ChangeVertexState(VertexState.Studied);
    }

    public void SellSkillTo(LearningPlayer player)
    {
        player.ForgetSkill(this);
        ChangeVertexState(VertexState.NotStudied);
    }
    
    private void ChangeVertexState(VertexState newState)
    {
        state = newState;
        OnChangeVertexState?.Invoke(newState);

    }
}
