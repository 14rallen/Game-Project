using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private Vector2 offsetLeft;
    private Vector2 offsetRight;
    private Vector2 offsetUp;
    private Vector2 offsetDown;

    private Vector2 element1Vertical;
    private Vector2 element1Horizontal;
    private Vector2 zero;

    private Vector2[] pointsHorizontal;
    private Vector2[] pointsVertical;

    public EdgeCollider2D EdgeCollider;

    private void Start()
    {
        offsetLeft = new Vector2(-17.5f, 0.8f);
        offsetRight = new Vector2(7.5f, 0.8f);
        offsetUp = new Vector2(0f, 3f);
        offsetDown = new Vector2(0f, -10f);

        element1Horizontal = new Vector2(10f, 0f);
        element1Vertical = new Vector2(0f, 8.5f);
        zero = new Vector2(0f, 0f);

        pointsHorizontal = new Vector2[2];
        pointsVertical = new Vector2[2];
        pointsHorizontal[0] = zero;
        pointsHorizontal[1] = element1Horizontal;
        pointsVertical[0] = zero;
        pointsVertical[1] = element1Vertical;

        //up down element0 0,0 element1 0, 8.5
        // left right element1 10, 0
    }

    public void TransformCollider(DirectionType dir)
    {
        if(dir == DirectionType.Up)
        {
            EdgeCollider.offset = offsetUp;
            EdgeCollider.points = pointsVertical;
        }
        else if (dir == DirectionType.Down)
        {
            EdgeCollider.offset = offsetDown;
            EdgeCollider.points = pointsVertical;
        }
        else if (dir == DirectionType.Left)
        {
            EdgeCollider.offset = offsetLeft;
            EdgeCollider.points = pointsHorizontal;
        }
        else if(dir == DirectionType.Right)
        {
            EdgeCollider.offset = offsetRight;
            EdgeCollider.points = pointsHorizontal;
        }
    }
}
