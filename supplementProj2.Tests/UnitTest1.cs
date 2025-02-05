using System.Security.Cryptography;

namespace supplementProj2.Tests;

public class supplementProj2Tester
{
    [Fact]
    public void NormalDistribution_GeneratesValuesWithinExpectedRange()
    {
       
       double mean = 10.0;
       double stdDev = 2.0;
       int sampleSize = 1000;
       double sum =0;
       double sumSquared =0;

       for (int i=0; i<sampleSize; i++){

        double value = supplementProj2.GenerateNormal(mean, stdDev);
        sum += value;
        sumSquared += value * value;
       }

       double calculatedMean = sum/sampleSize;
       double calculatedStdDev = Math.Sqrt((sumSquared/sampleSize) - (calculatedMean *calculatedMean));

       Assert.InRange(calculatedMean, mean - .5, mean + .5);
       Assert.InRange(calculatedStdDev, stdDev -.5, stdDev +.5);

    }

    [Fact]
    public void GeneratePassword_HasCorrectLength()
    {
        int length = 8;
        string password = supplementProj2.GeneratePassword(length);
        Assert.Equal(length, password.Length);
    }

    [Fact]
    public void GeneratePassword_ContainsValidCharacters()
    {
        string password = supplementProj2.GeneratePassword(10);
        Assert.All(password, ch => Assert.Contains(ch, supplementProj2.CharSet));
    }

    [Fact]
    public void GenerateRandomColor_ValuesAreWithinRange()
    {
        var (hex, rgb) = supplementProj2.GenerateRandomColor();
        Assert.InRange(rgb.Item1, 0, 255);
        Assert.InRange(rgb.Item2, 0, 255);
        Assert.InRange(rgb.Item3, 0, 255);
    }

    [Fact]
    public void GenerateRandomColor_HexMatchesRGB()
    {
        var (hex, rgb) = supplementProj2.GenerateRandomColor();
        string expectedHex = $"#{rgb.Item1:X2}{rgb.Item2:X2}{rgb.Item3:X2}";
        Assert.Equal(expectedHex, hex);
    }
}

﻿
