using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLook : MonoBehaviour
{
    
    [SerializeField]
    private Transform m_Target;
    public Transform LookAtTarget { get { return m_Target; } }

    [SerializeField]
    private Transform m_Spinner;
    public Transform Spinner { get { return m_Spinner; } }

    [SerializeField]
    private Transform m_Scaler;
    public Transform Scaler { get { return m_Scaler; } }
    

    [SerializeField]
    private List<Transform> passengerTargets = new List<Transform>();

    [SerializeField]
    private Transform exitTarget;

    public float speed;
    
    private void SetTarget(Transform target = null)
    {
        m_Target = target;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);

        if (passengerTargets.Count > 0)
        {
            SetTarget(passengerTargets[0]);
        }

        if (exitTarget != null)
        {
            exitTarget.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (passengerTargets.Count == 0 && exitTarget != null)
        {
            m_Target = exitTarget;
        }
        else
        {
            m_Target = GetClosestPassenger();
        }

        if (m_Target != null)
        {
            transform.LookAt(m_Target);
        }

        if (m_Spinner)
        {
            m_Spinner.Rotate(0, 0, speed * Time.deltaTime);
        }
    }

    private Transform GetClosestPassenger()
    {
        if (passengerTargets.Count == 0)
        {
            return null;
        }

        Transform closest = null;
        float closestDist = Mathf.Infinity;

        Vector3 origin = transform.position;

        foreach (var p in passengerTargets)
        {
            if (p == null) continue;

            float dist = Vector3.Distance(origin, p.position);

            if (dist < closestDist)
            {
                closestDist = dist;
                closest = p;
            }
        }

        return closest;
    }

    public void CollectPassenger(Transform passenger)
    {
        if (passengerTargets.Contains(passenger))
        {
            passengerTargets.Remove(passenger);

            if (passengerTargets.Count == 0 && exitTarget != null)
            {
                exitTarget.gameObject.SetActive(true);
            }
        }
    }
}
