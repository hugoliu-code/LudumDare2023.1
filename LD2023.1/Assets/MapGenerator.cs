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

    // The number of cycles of the basic noise pattern that are repeated
    // over the width and height of the texture.
    public float scale = 1.0F;

    private Texture2D noiseTex;
    private Color[] pix;
    private Renderer rend;

    //GameObject to place
    [SerializeField] GameObject resourceObject;


    //Margin for placing
    [SerializeField] float generationMargin;
    void Start()
    {
        rend = GetComponent<Renderer>();

        // Set up the texture and a Color array to hold pixels during processing.
        noiseTex = new Texture2D(pixWidth, pixHeight);
        pix = new Color[noiseTex.width * noiseTex.height];
        rend.material.mainTexture = noiseTex;
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
        for(int a = 0; a<10000; a++)
        {
            for(int b = 0; b < 10000; b++)
            {
                float2 location = new float2(a*scale, b*scale);
                float sample = noise.cellular(location).x;
                Debug.Log(sample);
                if(sample > generationMargin)
                {
                    PlaceResource(a,b);
                }
            }
        }
    }
    void PlaceResource(int x, int y)
    {
        Instantiate(resourceObject, new Vector3(x, y, 0), Quaternion.identity);
    }
    void Update()
    {
        CalcNoise();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] resourceList = GameObject.FindGameObjectsWithTag("Resource");
            foreach(GameObject n in resourceList)
            {
                Destroy(n);
            }
            Debug.Log("generated");
            Generate();
        }
        
    }
}
