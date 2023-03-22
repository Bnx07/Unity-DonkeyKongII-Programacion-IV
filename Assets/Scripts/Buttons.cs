using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    Transform t;
    Movement m;

    private void Awake()
    {
        t = GetComponent<Transform>();
        m = GetComponent<Movement>();
    }

    public void Up()
    {
        m.Move(t, Movement.MovementType.tup);
    }

    public void Down()
    {
        m.Move(t, Movement.MovementType.tdown);
    }

    public void Left()
    {
        m.Move(t, Movement.MovementType.tleft);
    }

    public void Right()
    {
        m.Move(t, Movement.MovementType.tright);
    }

    public void Jump()
    {
        m.Move(t, Movement.MovementType.tjump);
    }
}
