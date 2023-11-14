using CIS2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Generate a random array of 100,000 items
        List<Item> items = GenerateRandomItems(100000);

        // Specify the number of tasks
        int numberOfTasks = 10; // Adjust as needed

        // Divide the items into chunks
        var itemChunks = Chunkify(items, numberOfTasks);

        // Define the tasks for each chunk
        var tasks = new List<Task<List<Item>>>();

        foreach (var chunk in itemChunks)
        {
            tasks.Add(Task.Run(() => SelectItemsAsync(chunk)));
        }

        // Wait for all tasks to complete
        Task.WaitAll(tasks.ToArray());

        // Combine and display the results from all tasks
        var selectedItems = tasks.SelectMany(task => task.Result).ToList();

        // Display selected barcodes for specified counts
        DisplaySelectedBarcodes(selectedItems, 1, 30);
        DisplaySelectedBarcodes(selectedItems, 7, 15);
        DisplaySelectedBarcodes(selectedItems, 10, 8);
    }

    static async Task<List<Item>> SelectItemsAsync(List<Item> items)
    {
        return await Task.Run(() => SelectItems(items));
    }

    static List<Item> SelectItems(List<Item> items)
    {
        // Select items from the given items
        return items.ToList();
    }

    static void DisplaySelectedBarcodes(List<Item> items, int type, int count)
    {
        var selectedBarcodes = items
            .Where(item => item.Type == type)
            .Take(count)
            .Select(item => item.Barcode)
            .ToList();

        Console.WriteLine($"Type {type} - Selected Barcodes:");
        foreach (var barcode in selectedBarcodes)
        {
            Console.WriteLine(barcode);
        }
    }

    static List<List<Item>> Chunkify(List<Item> source, int chunkSize)
    {
        var chunks = new List<List<Item>>();
        for (int i = 0; i < source.Count; i += chunkSize)
        {
            var chunk = source.Skip(i).Take(chunkSize).ToList();
            chunks.Add(chunk);
        }
        return chunks;
    }

    static List<Item> GenerateRandomItems(int size)
    {
        Random random = new Random();
        List<Item> items = new List<Item>();

        for (int i = 0; i < size; i++)
        {
            items.Add(new Item
            {
                Barcode = i.ToString(),
                Type = random.Next(1, 101) // Random type between 1 and 100
            });
        }

        return items;
    }
}


