using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum MovementType { tup, tdown, tleft, tright, tjump}

    public MovementType movementType { get; set; }
    Vector3 p;

    Movement()
    {
        _step = 0.6f;
    }

    public float _step { get; }
    public void Move(Transform t, MovementType tm)
    {
        switch (tm)
        {
            case MovementType.tup:
                p = new Vector3(t.position.x, t.position.y + _step);
                break;
            case MovementType.tdown:
                p = new Vector3(t.position.x, t.position.y - _step);
                break;
            case MovementType.tleft:
                p = new Vector3(t.position.x - _step, t.position.y);
                break;
            case MovementType.tright:
                p = new Vector3(t.position.x + _step, t.position.y);
                break;
            case MovementType.tjump:
                p = new Vector3(t.position.x, t.position.y + _step);
                break;
        }
        t.position = p;
    }
}
