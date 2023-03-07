using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DistanceJoint2D _Dj;

    public Rigidbody2D _rd;

    public List<GameObject> JointPoints = new List<GameObject>();
    public string jointsTad;

    public LineRenderer _line;

    public GameObject objOfMinDistJoint;

    public bool jointSetted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == jointsTad)
        {
            JointPoints.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == jointsTad)
        {
            JointPoints.Remove(collision.gameObject);
            objOfMinDistJoint = null;
        }
    }

    public void Start()
    {
        _Dj = GetComponent<DistanceJoint2D>();
        _rd = GetComponent<Rigidbody2D>();
        _Dj.enabled = false;
    }

    private void Update()
    {
        float minDistJoint = 100;

        for (int i = 0; i < JointPoints.Count; i++)
        {
            if (Vector2.Distance(transform.position, JointPoints[i].transform.position) <= minDistJoint)
            {
                minDistJoint = Vector2.Distance(transform.position, JointPoints[i].transform.position);
                objOfMinDistJoint = JointPoints[i];
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (_Dj.connectedBody != null) BrekeLine();
                else if(objOfMinDistJoint != null) ChooseJoint();
            }
        }

        if(_line.enabled == true) DrawLine();
    }

    private void FixedUpdate()
    {
        _rd.velocity = new Vector2(_rd.velocity.x + 0.02f, _rd.velocity.y);
    }

    void ChooseJoint()
    {
        _Dj.enabled = true;

        _Dj.connectedBody = objOfMinDistJoint.GetComponent<Rigidbody2D>();

        _line.enabled = true;
    }

    void BrekeLine()
    {
        _Dj.connectedBody = null;

        _Dj.enabled = false;

        _line.enabled = false;
    }

    void DrawLine()
    {
        _line.SetPosition(0, transform.position);

        _line.SetPosition(1, _Dj.connectedBody ? _Dj.connectedBody.transform.position : transform.position);
    }
}
