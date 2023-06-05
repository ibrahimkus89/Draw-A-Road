using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _LineRenderer;
    [SerializeField] private EdgeCollider2D _EdgeCollider;
    [SerializeField]  List<Vector2> FingerPositionList=new();

    private Camera _Camera;
    private bool LineStart;
    private bool StartPhysic;

    void Start()
    {
        _Camera =Camera.main;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !LineStart)
        {
            CreateLine();
            LineStart = true;
        }

        if (Input.GetMouseButton(0) && LineStart)
        {
            Vector2 FingerPosition = _Camera.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(FingerPosition, FingerPositionList[^1]) >.1f)
            {
                UpdateLine(FingerPosition);

            }
        }

        if (Input.GetMouseButtonUp(0) && LineStart && _EdgeCollider.points.Length!=0)
        {
            StartPhysic=true;
        }

        if (StartPhysic)
        {
            _LineRenderer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void CreateLine()
    {
        FingerPositionList.Clear();
        FingerPositionList.Add(_Camera.ScreenToWorldPoint(Input.mousePosition));
        FingerPositionList.Add(_Camera.ScreenToWorldPoint(Input.mousePosition));

        _LineRenderer.SetPosition(0, FingerPositionList[0]);
        _LineRenderer.SetPosition(1, FingerPositionList[1]);
        _EdgeCollider.points = FingerPositionList.ToArray();

    }


    void UpdateLine(Vector2 incomingFingerPosition)
    {
        FingerPositionList.Add(incomingFingerPosition);
        _LineRenderer.positionCount++;
        _LineRenderer.SetPosition(_LineRenderer.positionCount-1,incomingFingerPosition);
        _EdgeCollider.points = FingerPositionList.ToArray();

    }
}
