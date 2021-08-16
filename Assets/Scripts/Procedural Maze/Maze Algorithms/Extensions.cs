using System.Collections;
using System.Collections.Generic;

public static class Extensions
{
    private static System.Random rng = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            // Get the random index
            int randomIndex = rng.Next(n + 1);
            T value = list[randomIndex];
            // Swap last index value into random index
            list[randomIndex] = list[n];
            // Swap random index value into last index
            list[n] = value; 
        }
    }

}
