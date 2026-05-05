using UnityEngine;
using System.Collections.Generic;
public static class Extensions
{
    public static void KillAllChildrenOfParent(Transform parent)
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(parent.GetChild(i).gameObject);
        }
    }
}
