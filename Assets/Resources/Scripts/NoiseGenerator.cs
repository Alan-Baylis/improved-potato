﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseGenerator {

	public static float[,] Perlin2D(Vector2 start, Vector2i[] offSet, int mapSize, float scale, int layers, float persistance, float lacunarity)
    {
        float[,] heights = new float[mapSize, mapSize];

        for (int x = 0; x < mapSize; x++)
            for (int z = 0; z < mapSize; z++)
            {
                float amplitude = 1f;
                float frequency = 1f;

                float height = 0;
                float maxHeight = 0;
                float minHeight = 0;

                for (int i = 0; i < layers; i++)
                {
                    float xCoord = (start.x * mapSize + (float)x) / scale * frequency + offSet[i].X;
                    float zCoord = (start.y * mapSize + (float)z) / scale * frequency + offSet[i].Z;

                    height += ((Mathf.PerlinNoise(xCoord, zCoord)) * 2 - 1) * amplitude;
                    maxHeight += amplitude;
                    minHeight -= amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                heights[x, z] = (height - minHeight) / (maxHeight - minHeight);
            }

        return heights;
    }

}
