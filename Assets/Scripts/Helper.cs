using UnityEngine;
using System;

public static class Helper
{
    public static float ClampAngle(float angle, float min, float max)
    {
        Console.WriteLine("Starting Helper Loop");

        do
        {
            if (angle < -360)
            { angle += 360; }
            if (angle > 360)
            { angle -= 360; }
        }
        while (angle < -360 || angle > 360);

        Console.WriteLine("Finished Helper Loop");

        return Mathf.Clamp(angle, min, max);
    }
}