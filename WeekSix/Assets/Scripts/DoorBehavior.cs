using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    //movement axis and movement distance for computing open and closed positions
    public Vector3 movementAxis;
    public float distance;

    //open and closed positions of this door
    private Vector3 openPos;
    private Vector3 closedPos;

    //the amount of frames the door open animation should take
    public float frames;

    private void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + (movementAxis * distance);

        //Assume the door starts closed. how would you fix this if you can't make this assumption?
        /*
        * Options:
        * 1.) Change "openPos" and "closePos" to "startPos" and "endPos".
        * 2.) Use physics to move doors towards or away from each other using an impulse force like on the jump pads. The collision between the doors would cause them to stop and serve to determine if the next action should be to open or close the doors.
        * would determine if open or closed.
        * 3.) Add a boolean "isClosed" that would determine whether "CloseGate()" or "OpenGate()" should run when
        * the player approaches.
        */
    }

    public void CloseGate()
    {
        //Fix door jump glitch by stopping already running coroutines and startin from current position
        StopAllCoroutines();
        StartCoroutine(DoorMove(transform.position, closedPos, 1 / frames));
    }

    public void OpenGate()
    {
        //Fix door jump glitch by stopping already running coroutines and startin from current position
        StopAllCoroutines();
        StartCoroutine(DoorMove(transform.position, openPos, 1 / frames));
    }

    IEnumerator DoorMove(Vector3 startPos, Vector3 endPos, float step)
    {
        for(float i = 0; i <= 1f; i += step)
        {
            Vector3 newPos = Vector3.Lerp(startPos, endPos, i);
            transform.position = newPos;
            yield return null;
        }
    }
}
