using UnityEngine;

public class LearningPlayer : MonoBehaviour
{
    private int _money;
    private InteractedVertex _selectedVertex;

    public void ChooseVertex(InteractedVertex vertex)
    {
        if (vertex== null || _selectedVertex == vertex) 
            return;
        
        if(_selectedVertex!=null)
            _selectedVertex.StopBeingChosen();
        _selectedVertex = vertex;
        _selectedVertex.BecomeChosen();
    }
}
