// DrawBones.cs
using UnityEngine;

public class DrawBones : MonoBehaviour
{
    private SkinnedMeshRenderer[] m_Renderers;

    private void Awake()
    {

    }

    void Start()
    {
        m_Renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    private void Update()
    {

    }

    private void OnDrawGizmosSelected()
    {
        if (m_Renderers == null)
        {
            return;
        }
        foreach (SkinnedMeshRenderer sk in m_Renderers)
        {
            foreach (Transform b in sk.bones)
            {
                if (b == null)
                {
                    continue;
                }
                if (b.parent == null)
                {
                    continue;
                }
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(b.position, b.parent.position);

                Gizmos.color = Color.green;
                Gizmos.DrawSphere(b.position, 0.02f);
            }
        }
    }
}
