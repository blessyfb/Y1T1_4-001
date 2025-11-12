using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference to teh GameManager in the scene
    private GameManager gameManager;

    // Array that will store all the targets (sorted by HP)
    private TargetHP[] targets;

    // Keeps track of which target the player is currently facing
    // Starts at -1 so the first time Space is pressed, it goes to index 0 (the first/highest HP target)
    private int currentTargetIndex = -1;
    
    // The camera that represents the player's view
    [SerializeField] private Camera playerCamera;
    // Defines which layers are considered 'obstacles' that can block vision
    [SerializeField] private LayerMask obstacleLayer;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Finds the first GameManager object in the scene
        gameManager = FindFirstObjectByType<GameManager>();
        
        // Sorts the targets inside the GameManager by their HP (highest to lowest)
        gameManager.BubbleSort();

        // Retrieves the sorted list of targets from the GameManager
        targets = gameManager.GetSortedTargets();

        // Makes the player camera face the first visible target
        FaceNextVisibleTarget();

    }

    // Update is called once per frame
    void Update()
    {
        // When the player releases the Space Key...
        if(Input.GetKeyUp(KeyCode.Space))
        {
            // ... move on to the next visible target
            FaceNextVisibleTarget();
        }

    }

    // Makes the player camera face the next target that isn't blocked by an obstacle
    private void FaceNextVisibleTarget()
    {
        // Increase the target index and loop back to 0 if we reach the end of the list
        currentTargetIndex = (currentTargetIndex + 1) % targets.Length;

        // Get the target we should look at
        TargetHP target = targets[currentTargetIndex];

        // If the target is visible (no wall or obsatcle in between)...
        if(isTargetVisible(target))
        {
            // ...make the camera look directly at it
            playerCamera.transform.LookAt(target.transform);
            return;
        }
    }

    // Check whether the given taregt is visible to the player
    private bool isTargetVisible(TargetHP target)
    {
        // Calculate the direction from the camera to the target
        Vector3 directionToTarget = target.transform.position - playerCamera.transform.position;
        
        // Measure how far away the target is
        float distanceToTarget = Vector3.Distance(playerCamera.transform.position, target.transform.position);

        // Cast a ray(an invibile line) toward the target to check if something blocks it
        // If the ray DOES NOT hit an obstacle/wall, the target is visible
        if(!Physics.Raycast(playerCamera.transform.position, directionToTarget, distanceToTarget, obstacleLayer))
        {
            return true;
        }

        // If the ray hits an obstacle, the target is not visible 
        return false;
    }


    
}
