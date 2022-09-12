using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldLayout : Layout
{
    public override Vector3 CalculatePosition(int siblingIndex, int totalSiblingsCount)
    {
        var index = siblingIndex - (totalSiblingsCount - 1) / 2f;
        return new Vector2(positionOffset.x * index, positionOffset.y);
    }

    public override Vector3 CalculateRotation(int siblingIndex, int totalSiblingsCount)
    {
        return rotationOffset;
    }
}
