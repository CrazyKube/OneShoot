using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This sample demonstrates how to use the PointCloudGestureRecognizer to recognize custom gestures from a list of templates
/// </summary>
[RequireComponent(typeof(PointCloudRegognizer))]
public class PointSample : MonoBehaviour
{
    public PointCloudGestureRenderer GestureRendererPrefab;
    public float GestureScale = 4.0f;
    public Vector2 GestureSpacing = new Vector2(1.25f, 1.0f);
    public int MaxGesturesPerRaw = 2;

    List<PointCloudGestureRenderer> gestureRenderers;

    private void Start()
    {
        RenderGestureTemplates();
    }

    // Message send by the PointCloudRecognizer when it recognized a valid gesture pattern
    void OnCustomGesture(PointCloudGesture gesture)
    {
        string scorePercentText = (gesture.MatchScore * 100).ToString("N2");

        string text = "Matched " + gesture.RecognizedTemplate.name + " (score: " + scorePercentText + "% distance:" + gesture.MatchDistance.ToString("N2") + ")";
        Debug.Log(text);

        // make the corresponding gesture visualizer blink
        PointCloudGestureRenderer gr = FindGestureRenderer(gesture.RecognizedTemplate);
        if (gr)
            gr.Blink();
    }

    void OnFingerDown(FingerDownEvent e)
    {
        
    }

    void RenderGestureTemplates()
    {
        gestureRenderers = new List<PointCloudGestureRenderer>();

        Transform gestureRoot = new GameObject("Gesture Templates").transform;
        gestureRoot.parent = this.transform;
        gestureRoot.localScale = GestureScale * Vector3.one;

        PointCloudRegognizer recognizer = GetComponent<PointCloudRegognizer>();
        Vector3 pos = Vector3.zero;
        int gesturesOnRow = 0;
        int rows = 0;
        float rowWidth = 0;

        foreach (PointCloudGestureTemplate template in recognizer.Templates)
        {
            PointCloudGestureRenderer gestureRenderer = Instantiate(GestureRendererPrefab, gestureRoot.position, gestureRoot.rotation) as PointCloudGestureRenderer;
            gestureRenderer.GestureTemplate = template;
            gestureRenderer.name = template.name;
            gestureRenderer.transform.parent = gestureRoot;
            gestureRenderer.transform.localPosition = pos;
            gestureRenderer.transform.localScale = Vector3.one;

            pos.x += GestureSpacing.x;

            rowWidth = Mathf.Max(rowWidth, pos.x);

            if (++gesturesOnRow >= MaxGesturesPerRaw)
            {
                pos.y += GestureSpacing.y;
                pos.x = 0;
                gesturesOnRow = 0;
                rows++;
            }

            gestureRenderers.Add(gestureRenderer);
        }

        // center
        Vector3 rootPos = Vector3.zero;
        rootPos.x -= GestureScale * 0.5f * (rowWidth - GestureSpacing.x);

        if (rows > 0)
            rootPos.y -= GestureScale * 0.5f * (pos.y - GestureSpacing.y);

        gestureRoot.localPosition = rootPos;
    }

    PointCloudGestureRenderer FindGestureRenderer(PointCloudGestureTemplate template)
    {
        return gestureRenderers.Find(gr => gr.GestureTemplate == template);
    }
   
}
