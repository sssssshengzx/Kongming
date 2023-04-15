using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineCut : MonoBehaviour
{
    [SerializeField] LineRenderer dotted;
    LineRenderer cut;
    Vector3[] positions;
    bool[] visited;
    List<Vector3> selected;
    int prev = -1;
    [SerializeField] float threshold = 0.2f;
    [SerializeField] GameObject origin;
    [SerializeField] GameObject finished;
    [SerializeField] GameObject nextButton;

    private void Awake()
    {
        cut = GetComponent<LineRenderer>();
        positions = new Vector3[dotted.positionCount];
        dotted.GetPositions(positions);
        for (int i = 0; i < positions.Length; ++i)
            positions[i].z = 0;
        visited = new bool[positions.Length];
    }
    private void OnEnable()
    {
        Init();
        origin.SetActive(true);
        finished.SetActive(false);
    }
    private void Init()
    {
        for (int i = 0; i < positions.Length; ++i) visited[i] = false;
        selected = new List<Vector3>();
        cut.positionCount = 0;
    }
    private void Update()
    {
        Cut();
    }
    void Cut()
    {
        Ray ray;
#if UNITY_ANDROID
        if (Input.touchCount == 0)
            return;
        var touch = Input.GetTouch(0);
        ray = Camera.main.ScreenPointToRay(touch.position);
#else
        if (!Input.GetMouseButton(0))
            return;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
#endif
        Vector3 posOnZeroZ = ray.origin - ray.direction * ray.origin.z / ray.direction.z;
        int ind = -1;
        float minDist = float.MaxValue;
        for (int i = 0; i < positions.Length; ++i)
        {
            if (visited[i]) continue;
            if (!(prev == -1 || (prev + 1) % positions.Length == i || (i + 1) % positions.Length == prev)) continue;
            var dist = Vector3.Distance(dotted.transform.TransformPoint(positions[i]), posOnZeroZ);
            if (dist > threshold) continue;
            if (ind == -1 || dist < minDist)
            {
                ind = i;
                minDist = dist;
            }
        }
        if (ind == -1)
            return;
        visited[ind] = true;
        Vector3 temp = positions[ind];
        temp.z = -0.02f;
        selected.Add(temp);
        cut.positionCount = selected.Count;
        cut.SetPositions(selected.ToArray());
        Debug.Log(selected.Count + "|" + positions.Length);
        if (selected.Count == positions.Length)
        {
            visited[(ind + ind - prev) % positions.Length] = false;
        }
        else if(selected.Count>positions.Length)
        {
            FinishCut();
        }
        prev = ind;
    }
    void FinishCut()
    {
        origin.SetActive(false);
        finished.SetActive(true);
        nextButton.SetActive(true);
    }
}