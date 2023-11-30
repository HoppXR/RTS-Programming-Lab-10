using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button button;
    
    public GameObject previewPrefab;
    public GameObject towerPrefab;
    private bool isPlacingTower = false;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartPlacingTower);
    }

    void Update()
    {
        if (isPlacingTower)
        {
            UpdateTowerPlacement();
        }
    }

    void StartPlacingTower()
    {
        isPlacingTower = true;

        button.interactable = false;

        previewPrefab = Instantiate(previewPrefab);
        previewPrefab.SetActive(false);
    }

    void UpdateTowerPlacement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            previewPrefab.SetActive(true);
            previewPrefab.transform.position = new Vector3(hit.point.x, 0.25f, hit.point.z);

            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower(previewPrefab.transform.position);
            }
        }
        else
        {
            previewPrefab.SetActive(false);
        }
    }

    void PlaceTower(Vector3 position)
    {
        Instantiate(towerPrefab, position, Quaternion.identity);

        isPlacingTower = false;
        previewPrefab.SetActive(false);

        button.interactable = true;
    }
}
