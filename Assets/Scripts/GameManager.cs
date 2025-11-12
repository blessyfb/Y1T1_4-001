using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TargetHP[] targets;
    void Awake()
    {
        targets = FindObjectsByType<TargetHP>(FindObjectsSortMode.None);

        BubbleSort();
    }


    public void BubbleSort()
    {
        
        int n = targets.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (targets[j].GetHealthPoints() < targets[j + 1].GetHealthPoints())
                {
                    TargetHP tempTarget = targets[j];
                    targets[j] = targets[j + 1];
                    targets[j + 1] = tempTarget;
                }
            }
        }

    }


    public TargetHP[] GetSortedTargets()
    {
        return targets;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
