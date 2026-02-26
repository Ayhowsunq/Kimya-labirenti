using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;

    public GameObject floorPrefab;
    public GameObject wallPrefab;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        float offsetX = width / 2f;
        float offsetZ = height / 2f;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x - offsetX, 0, z - offsetZ);

                // Kenarları duvar yap
                if (x == 0 || z == 0 || x == width - 1 || z == height - 1)
                {
                    Instantiate(wallPrefab, pos, Quaternion.identity, transform);
                }
                else
                {
                    Instantiate(floorPrefab, pos, Quaternion.identity, transform);
                }
            }
        }
    }
}