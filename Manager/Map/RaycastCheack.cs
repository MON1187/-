using UnityEngine;

public static class RaycastCheack
{
    /// <summary>
    /// 해당 이름의 Layer를 번호를 반환 
    /// </summary>
    /// <param name="layerName"></param>
    /// <returns></returns>
    public static int GetLayerMask(string layerName)
    {
        return LayerMask.NameToLayer(layerName);
    }

    public static RaycastHit2D PerformRaycast(Vector3 startPos, int layermask)
    {
        return Physics2D.Raycast(startPos,Vector3.zero,Mathf.Infinity,layermask);
    }
}
