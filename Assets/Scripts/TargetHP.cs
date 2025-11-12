using UnityEngine;

public class TargetHP : MonoBehaviour
{
    
    // The target's health points
    // SerializeField makes it visible and editable in the Inspector
    
    [SerializeField] private int HP;

    
    // This public methods allows other scripts to read the target's HP value
    public int GetHealthPoints()
    {
        return HP;
    }


}
