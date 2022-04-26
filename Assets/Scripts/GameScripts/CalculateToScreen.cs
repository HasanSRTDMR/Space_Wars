using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalculateScreen
{
    /// <summary>
    /// Returns the coordinates of the left edge of the screen
    /// </summary>
    private static float screenLeft;
    public static float ScreenLeft
    {
        get { return screenLeft; }
    }
    /// <summary>
    /// Returns the coordinates of the right edge of the screen
    /// </summary>
    private static float screenRight;
    public static float ScreenRight
    {
        get { return screenRight; }
    }
    /// <summary>
    /// Returns the coordinates of the top edge of the screen
    /// </summary>
    private static float screenUp;
    public static float ScreenUp
    {
        get { return screenUp; }
    }
    /// <summary>
    /// Returns the coordinates of the bottom edge of the screen
    /// </summary>
    private static float screenDown;
    public static float ScreenDown
    {
        get { return screenDown; }
    }
    /// <summary>
    /// Initiates coordinate calculations of the screen
    /// </summary>
    public static void Init()
    {
        float axisZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCorner = new Vector3(0, 0, axisZ);
        Vector3 upperRightCorner = new Vector3(Screen.width, Screen.height, axisZ);

        Vector3 lowerLeftCornerRealWorld = Camera.main.ScreenToWorldPoint(lowerLeftCorner);
        Vector3 upperRightCornerRealWorld = Camera.main.ScreenToWorldPoint(upperRightCorner);

        screenLeft = lowerLeftCornerRealWorld.x;
        screenRight = upperRightCornerRealWorld.x;
        screenDown = lowerLeftCornerRealWorld.y;
        screenUp = upperRightCornerRealWorld.y;
    }
}
