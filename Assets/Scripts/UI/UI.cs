using UnityEngine;
using Zenject;

public class UI : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private int _deltaSkillPoint=2; 
    [Inject] private LearningPlayer _player;

    public void ChangeSkillPoint()
    {
        _player.ChangeSkillPointsTo(_deltaSkillPoint);
    }

    public void ChangeSkillState(InteractedVertex vertex,bool isLearn)
    {
        if(isLearn)
            vertex.LearnSkill();
        else
            vertex.ForgetSkill();
    }

    public void ForgetAllSkill()
    {
        _player.ForgetAllSkill();
    }

    public bool CanLearnSkillFrom(Vertex vertex)
    {
        return _player.SkillPoints >= vertex.Price && vertex.State == VertexState.NotStudied &&
               vertex.GetComponent<VertexDFS>().IsThereStudiedVertexInConnectedVertices();
    }

    public bool CanForgetSkillFrom(Vertex vertex)
    {
        return vertex.GetComponent<VertexDFS>().CanFindWayToBase() && vertex.State == VertexState.Studied;
    }
}
