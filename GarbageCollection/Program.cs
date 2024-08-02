using System;

class Program
{
    static void Main()
    {
        // Display initial memory usage
        long initialMemory = GC.GetTotalMemory(false);
        Console.WriteLine($"Initial Memory: {initialMemory} bytes");

        // Allocate memory for objects
        CreateObjects();

        // Display memory usage before GC
        long memoryBeforeGC = GC.GetTotalMemory(false);
        Console.WriteLine($"Memory before GC: {memoryBeforeGC} bytes");

        // Force garbage collection
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // Display memory usage after GC
        long memoryAfterGC = GC.GetTotalMemory(false);
        Console.WriteLine($"Memory after GC: {memoryAfterGC} bytes");

        // Calculate memory differences
        Console.WriteLine($"Memory difference (before - after): {memoryBeforeGC - memoryAfterGC} bytes");
        Console.WriteLine($"Memory difference (initial - after): {initialMemory - memoryAfterGC} bytes");
    }

    static void CreateObjects()
    {
        // Create a large number of short-lived objects
        for (int i = 0; i < 100000; i++)
        {
            var obj = new MyClass();
        }
    }
}

class MyClass
{
    private byte[] _data;

    public MyClass()
    {
        // Allocate 1 KB of memory
        _data = new byte[1024];
    }
}
