using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> gridPoints = new List<GameObject>();
    
    [Header("Items")]
    [SerializeField] private GameObject defaultBlock;
    [SerializeField] private GameObject winBlock;
    [SerializeField] private GameObject obstalceBlock;
    [SerializeField] private GameObject itemBlock;
    
    [Header("Number of items")]
    [SerializeField] private int numberOfWins = 1;
    [SerializeField] private int numberOfObstacles = 3;
    [SerializeField] private int numberOfItems = 2;

    private void Start() {
        SpecifiedInstantiate();
    }

    private void SpecifiedInstantiate() {
        int randSelect;

        for (int i = 0; i < numberOfWins; i++) {
            randSelect = Random.Range(0, gridPoints.Count);
            var point = gridPoints[randSelect];
            var obj = Instantiate(winBlock, point.transform.position, point.transform.rotation, point.transform);
        }

        for (int i = 0; i < numberOfObstacles; i++) {
            randSelect = Random.Range(0, gridPoints.Count);
            var point = gridPoints[randSelect];
            var obj = Instantiate(obstalceBlock, point.transform.position, point.transform.rotation, point.transform);
        }

        for (int i = 0; i < numberOfItems; i++) {
            randSelect = Random.Range(0, gridPoints.Count);
            var point = gridPoints[randSelect];
            var obj = Instantiate(itemBlock, point.transform.position, point.transform.rotation, point.transform);
        }
    }
}