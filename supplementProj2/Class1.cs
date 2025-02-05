using System;

namespace supplementProj2;

public class supplementProj2
{
  private static Random _random = new Random();
  public const string CharSet =  "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";

/// <summary>
/// Generates a random number following a normal distribtuion.
/// </summary>
/// <param name="mean">Mean of the distribution</param>
/// <param name="stdDev">Standard deviation of the distibution</param>
/// <returns> A normally distributed random number</returns>
  public static double GenerateNormal(double mean, double stdDev){

    double u1 = 1.0 - _random.NextDouble();
    double u2 = 1.0 - _random.NextDouble();
    double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
    return mean + stdDev * randStdNormal;
  }

  /// <summary>
  /// Generates a password in the range given.
  /// </summary>
  /// <param name="length">length of the password</param>
  /// <returns> A Generated password</returns>/

  public static string GeneratePassword(int length){

    return new string(Enumerable.Range(0,length).Select(_ => CharSet[_random.Next(CharSet.Length)]).ToArray());
  }

  /// <summary>
  /// Generates a random color following the min and max
  /// </summary>
  /// <returns> Generates a random color</returns>
 public static(string, (int, int, int)) GenerateRandomColor(){

    int r = _random.Next(0,256);
    int g = _random.Next(0,256);
    int b = _random.Next(0,256);

    string hex = $"#{r:X2}{g:X2}{b:X2}";
    return (hex, (r,g,b));
 } 
}

