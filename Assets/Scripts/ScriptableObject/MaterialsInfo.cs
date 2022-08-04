using UnityEngine;

[CreateAssetMenu(fileName = "New MaterialsInfo", menuName = "Materials Info", order = 51)]
public class MaterialsInfo : ScriptableObject
{
    [SerializeField] private Material _studied;
    [SerializeField] private Material _notStudied;

    public Material Studied 
    {
        get
        {
            return _studied;
        }
    }
    
    public Material NotStudied 
    {
        get
        {
            return _notStudied;
        }
    }
}
