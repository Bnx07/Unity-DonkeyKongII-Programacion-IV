using System;
using UnityEngine;

public class MovementAutomatic : MonoBehaviour
{
    enum TypeMovementBot { HorizontalBounce,VerticalBounce,HorizontalFromLeft, HorizontalFromRight,VerticalFromAbove, VerticalFromBelow }

    [SerializeField] TypeMovementBot typeMovementRobot;

    private Transform t;
    public bool goRight = true;
    public bool goTop = true;
    public float speed = 0.01f;
    public float limitTop = 3.5f;
    public float limitBottom = -3.5f;
    public float limitRight = 3.5f;
    public float limitLeft = -3.5f;

    private void Awake()
    {
        t = GetComponent<Transform>();
    }
    private void Update()
    {
        try
        {
            switch (typeMovementRobot)
            {
                case TypeMovementBot.HorizontalBounce:
                    HorizontalBounce();
                    break;
                case TypeMovementBot.VerticalBounce:
                    VerticalBounce();
                    break;
                case TypeMovementBot.HorizontalFromLeft:
                    HorizontalFromLeft();
                    break;
                case TypeMovementBot.HorizontalFromRight:
                    HorizontalFromRight();
                    break;
                case TypeMovementBot.VerticalFromAbove:
                    VerticalFromAbove();
                    break;
                case TypeMovementBot.VerticalFromBelow:
                    VerticalFromBelow();
                    break;
            }
        }catch(Exception e)
        {
            Debug.LogError("No se ha encontrado el componente Transform en el objeto actual");
        }
    }

    private void HorizontalBounce()
    {
        if (goRight) {
            HorizontalFromLeft();
        } else {
            HorizontalFromRight();
        }
    }

    private void VerticalBounce()
    {
        if (goTop) {
            VerticalFromBelow();
        } else {
            VerticalFromAbove();
        }
    }

    private void HorizontalFromLeft()
    {
        if (t.position.x < limitRight) {
            t.position = new Vector3(t.position.x + speed, t.position.y);
            t.rotation = Quaternion.Euler(0, 0, 270);
        } else {
            goRight = false;
        }
    }

    private void HorizontalFromRight()
    {
        if (t.position.x > limitLeft) {
            t.position = new Vector3(t.position.x - speed, t.position.y);
            t.rotation = Quaternion.Euler(0, 0, 90);
        } else {
            goRight = true;
        }
    }

    private void VerticalFromAbove()
    {
        if (t.position.y > limitBottom) {
            t.position = new Vector3(t.position.x, t.position.y - speed);
            t.rotation = Quaternion.Euler(0, 0, 180);
        } else {
            goTop = true;
        }
    }

    private void VerticalFromBelow()
    {
        if (t.position.y < limitTop) {
            t.position = new Vector3(t.position.x, t.position.y + speed);
            t.rotation = Quaternion.Euler(0, 0, 0);
        } else {
            goTop = false;
        }
    }
}
