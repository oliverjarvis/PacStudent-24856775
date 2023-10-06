using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement {
    // making a simple state machine
    // might not be best design, but it works
    private int index = -1;
    private int count = 0;

    public Movement(int count){
        this.count = count;
    }
    
    public int GetNextGoalIndex() { // Changed to public
        index += 1;
        if (index >= count) { // Changed size() to Count
            index = 0;
        }
        
        return index;
    }
}



public class PlayerMovement : MonoBehaviour {
    public float speed = 20f;
    Vector3 goalDestination;
    Vector3 startPosition;
    Movement movementStateMachine;

    List<Vector3> goalDestinations;
    List<string> directions;
    void Start() {
        startPosition = transform.localPosition;

        goalDestinations = new List<Vector3> { // Added 'new List<Vector3>' and fixed the list initialization
            startPosition + new Vector3(5, 0, 0),
            startPosition + new Vector3(5, -4, 0),
            startPosition + new Vector3(0, -4, 0),
            startPosition + new Vector3(0, 0, 0),
        };

        directions = new List<string>{
            "FaceRight",
            "FaceDown",
            "FaceLeft",
            "FaceUp"
        };

        movementStateMachine = new Movement(goalDestinations.Count);
        int next_index = movementStateMachine.GetNextGoalIndex();
        goalDestination = goalDestinations[next_index];
    }

    void Update() {
        // use move towards to get closer to the target
        Vector3 p = Vector3.MoveTowards(transform.localPosition, goalDestination, speed * Time.deltaTime); // Changed Vector2 to Vector3
        transform.localPosition = p;
        
        if (Vector3.Distance(transform.localPosition, goalDestination) <= 0.0001f) { // Changed Vector3.distance to Vector3.Distance
            // get our next animation direction and the next goal
            int next_index = movementStateMachine.GetNextGoalIndex();
            GetComponent<Animator>().SetTrigger(directions[next_index]);
            goalDestination = goalDestinations[next_index];
        }
    }
}
