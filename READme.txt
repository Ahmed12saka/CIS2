Parallel Processing Tool Selection
This C# program demonstrates parallel processing to select barcodes for specific types from a large collection of items. The main goal is to find and display barcodes for:

30 items of type 1
15 items of type 7
8 items of type 10 

Adjust Parameters:

Modify the numberOfTasks variable to control the number of parallel tasks.
Adjust the counts in the DisplaySelectedBarcodes method for each type as needed.
Run the Program:
Execute the program to see the selected barcodes for the specified types.

Project Structure
Program.cs: Contains the main logic for generating random items, dividing them into chunks, and processing them in parallel.
Item.cs: Defines the Item class with properties Barcode and Type.
README.md: Documentation file providing instructions on how to use the program

The problem of processing a collection of items is generally parallelizable. Different tasks can work independently on distinct portions of the data.

The problem is partitioned by dividing the dataset into chunks. Each task processes a specific chunk independently.

Communication between tasks is generally minimal, as each task operates on its designated chunk without requiring extensive data exchange.

Synchronization may be required if there are shared resources or critical sections that multiple tasks access concurrently. Otherwise, tasks can operate independently.

Data dependencies are considered low, as tasks typically work on isolated portions of the dataset. However, dependencies could arise if there are shared resources or critical sections.