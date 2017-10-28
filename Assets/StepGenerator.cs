using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepGenerator : MonoBehaviour {
   [SerializeField] private GameObject[] _leftStep;
   [SerializeField] private GameObject[] _rightStep;
    [SerializeField] private Transform _stepsPool;
    private byte _lastStepType;
    private GameObject _currentStep ;
    private List<GameObject> _possibleStepsPool = new List<GameObject>();
    // Use this for initialization
    void Start () {
        FirstStep();
       	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FirstStep()
    {
      int n =  Random.Range(0,1);
        GameObject clone;
        if (n == 1)
        {
            clone = Instantiate(_leftStep[0],_stepsPool);
            clone.transform.position = Vector3.zero;
            
        }
        else 
        {
            clone = Instantiate(_rightStep[0], _stepsPool);
            clone.transform.position = Vector3.zero;
        }
        _currentStep = clone;
        _lastStepType = (byte)n;
   


    }
    private void NextStep(GameObject  CurrentStep) {

        var distanceBetweenStep = 1.5f;
        var distanceNearStep = 1;
        var rotationAngle = 30;
        var currentAngle = CurrentStep.transform.rotation.eulerAngles.y;

        

        var nextStepPosition = CurrentStep.transform.position + new Vector3(distanceBetweenStep, 0,
            -distanceNearStep);

        // var nextStepRotation = Quaternion.AngleAxis(currentAngle + rotationAngle, Vector3.down);
        var nextStepRotation = Quaternion.Euler(0,currentAngle - rotationAngle,0);

        Debug.Log("angle S =  " + currentAngle);

        var nextStepType = (_lastStepType == 0) ? _leftStep : _rightStep;

        for (var i = 0 ; i < 3; i++)
        {
            var nextStepColor = nextStepType[Random.Range(0, nextStepType.Length)];
            var clone = Instantiate(nextStepColor,_stepsPool);
            clone.transform.position = nextStepPosition;
            clone.transform.rotation = nextStepRotation;
            nextStepPosition += new Vector3(0, 0, distanceNearStep);
            currentAngle = currentAngle + rotationAngle;
            nextStepRotation = Quaternion.Euler(0, currentAngle, 0);
            Debug.Log("angle =  " + currentAngle);
           CurrentStep.transform.rotation = nextStepRotation;
        }
        _lastStepType = (_lastStepType == 0) ? (byte)1 : (byte)0;

    }

    private void CreateStepsAround( GameObject Step)
    {
        var stepsAround = 12;
        var nextStepType = (_lastStepType == 0) ? _leftStep : _rightStep;
        Vector3 center = Step.transform.position;

        for (int i = 0; i < stepsAround; i++)
        {
            float a = 360 / stepsAround * i;
            var nextStepGameObject = nextStepType[Random.Range(0, nextStepType.Length)];
            Vector3 pos = CreateCircleOfSteps(center, 2f,a);
            var clone = Instantiate(nextStepGameObject, pos, Quaternion.identity);
            _possibleStepsPool.Add(clone);

        }
    }

    Vector3 CreateCircleOfSteps(Vector3 center, float radius, float ang)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
    private void DestroyPrevSteps()
    {
        if (_possibleStepsPool.Count > 0)
        {
            for (int i = 0; i < _possibleStepsPool.Count; i++)
            {
                _possibleStepsPool[i].gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // NextStep(other.gameObject);
        DestroyPrevSteps();
        CreateStepsAround(other.gameObject);

    }
}

