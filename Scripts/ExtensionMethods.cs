using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    /// <summary>
    /// Maps a value from one number range onto another.
    /// </summary>
    /// <param name="value">Float to be mapped.</param>
    /// <param name="from1">Min of initial range.</param>
    /// <param name="to1">Max of initial range.</param>
    /// <param name="from2">Min of target range.</param>
    /// <param name="to2">Max of target range.</param>
    /// <returns>Mapped float.</returns>
    public static float RangeMap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
