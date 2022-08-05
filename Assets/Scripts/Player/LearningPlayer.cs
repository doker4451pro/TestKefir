using System;
using System.Collections.Generic;
using UnityEngine;

public class LearningPlayer : MonoBehaviour
{
    public Action<int> OnSkillPointChange;

    private int _skillPoint;
    private List<Vertex> _learningVertices;

    public int SkillPoints
    {
        get
        {
            return _skillPoint;
        }
    }

    private void Start()
    {
        _learningVertices = new List<Vertex>();
    }

    public void ChangeSkillPointsTo(int skillPoints)
    {
        _skillPoint += skillPoints;
        if(_skillPoint<0)
            Debug.LogError("skill cannot be less than 0");
        OnSkillPointChange(_skillPoint);
    }

    public void LearnSkill(Vertex vertex)
    {
        ChangeSkillPointsTo(-vertex.Price);
        vertex.BuySkill();
        _learningVertices.Add(vertex);
    }

    public void ForgetSkill(Vertex vertex)
    {
        ChangeSkillPointsTo(vertex.Price);
        vertex.SellSkill();
        _learningVertices.Remove(vertex);
    }

    public void ForgetAllSkill()
    {
        for (int i = _learningVertices.Count - 1; i >= 0; i--)
        {
            ForgetSkill(_learningVertices[i]);
        }
    }
}
