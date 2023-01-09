using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
public class MapGenerator : MonoBehaviour
{
    // Width and height of the texture in pixels.
    public int pixWidth;
    public int pixHeight;

    // The origin of the sampled area in the plane.
    public float xOrg;
    public float yOrg;
    public float xOrgDetails;
    public float yOrgDetails;

    // The number of cycles of the basic noise pattern that are repeated
    // over the width and height of the texture.
    public float scale = 1.0F;

    private Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;

    //GameObject to place
    [SerializeField] GameObject resourceObject;
    [SerializeField] GameObject[] detail;


    //Margin for placing
    [SerializeField] float generationMargin;
    [SerializeField] float detailGenerationMargin;
    [SerializeField] float spread;
    [SerializeField] int mapSize = 1000;
    void Start()
    {

        rend = GetComponent<Renderer>();
        Generate();
        // Set up the texture and a Color array to hold pixels during processing.
        //noiseTex = new Texture2D(pixWidth, pixHeight);
        //pix = new Color[noiseTex.width * noiseTex.height];
        //rend.material.mainTexture = noiseTex;
    }

    void CalcNoise()
    {
        // For each pixel in the texture...
        float y = 0.0F;

        while (y < noiseTex.height)
        {
            float x = 0.0F;
            while (x < noiseTex.width)
            {
                float xCoord = xOrg + x / noiseTex.width * scale;
                float yCoord = yOrg + y / noiseTex.height * scale;
                //float sample = Mathf.PerlinNoise(xCoord, yCoord);
                float2 location = new float2(xCoord, yCoord);
                float sample = noise.cellular(location).x;
                pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
                x++;
            }
            y++;
        }

        // Copy the pixel data to the texture and load it into the GPU.
        noiseTex.SetPixels(pix);
        noiseTex.Apply();
    }

    void Generate()
    {
        xOrg = UnityEngine.Random.Range(0, 1000);
        yOrg = UnityEngine.Random.Range(0, 1000);
        xOrgDetails = UnityEngine.Random.Range(0, 1000);
        yOrgDetails = UnityEngine.Random.Range(0, 1000);
        for (int a = 0; a<mapSize; a++)
        {
            for(int b = 0; b < mapSize; b++)
            {
                float2 location = new float2(a*scale*100+xOrg, b*scale*100+yOrg); //extra 100 to make it more random
                float sample = noise.cellular(location).x;
                //Debug.Log(sample);
                if(sample > generationMargin)
                {
                    PlaceResource(a,b);
                }
                location = new float2(a * scale * 100 + xOrgDetails, b * scale * 100 + yOrgDetails); //extra 100 to make it more random
                sample = noise.cellular(location).x;
                //Debug.Log(sample);
                if (sample > detailGenerationMargin)
                {
                    PlaceDetail(a, b);
                }
            }
        }
    }
    void PlaceResource(int x, int y)
    {

        float randX = UnityEngine.Random.Range(-0.5f, 0.5f); //slightly random position change so it doesn't look like a grid
        float randY = UnityEngine.Random.Range(-0.5f, 0.5f);
        float centering = mapSize * spread * 0.5f;
        Instantiate(resourceObject, new Vector3(x*spread+randX-centering , y*spread+randY-centering , 0), Quaternion.identity, this.transform);
    }
    void PlaceDetail(int x, int y)
    {

        float randX = UnityEngine.Random.Range(-0.5f, 0.5f); //slightly random position change so it doesn't look like a grid
        float randY = UnityEngine.Random.Range(-0.5f, 0.5f);
        float centering = mapSize * spread * 0.5f;
        Instantiate(detail[UnityEngine.Random.Range(0,3)], new Vector3(x * spread + randX - centering, y * spread + randY - centering, 0), Quaternion.identity, this.transform);
    }
    void Update()
    {
        //CalcNoise();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject[] resourceList = GameObject.FindGameObjectsWithTag("Resource");
        //    foreach(GameObject n in resourceList)
        //    {
        //        Destroy(n);
        //    }
        //    Debug.Log("generated");
        //    Generate();
        //}
        
    }
}
