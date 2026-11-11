# A5.-Functional-Programming

# Array Elimination — C# & Haskell

## Assignment

Solve [E-Olymp Problem 1964](https://www.eolymp.com/en/problems/1964) using two programming languages with different paradigms:

- **C#** — Imperative programming
- **Haskell** — Functional programming

The goal is to solve the problem using array/list processing rather than a mathematical formula.

## Problem Description

The program starts with numbers from `1` to `n` and repeatedly removes elements until only one remains.

The removal rules repeat every three steps:

1. **Step 0:** Remove elements at even positions.
2. **Step 1:** Remove elements at odd positions.
3. **Step 2:** Remove every third element.

The program outputs the last remaining number.

## C# Implementation (Imperative)

In C#, I used `while` and `for` loops to process the array.

Instead of creating a new array after each iteration, I decided to **reuse the same array**.

I used two variables:
- `size` — tracks the number of active elements.
- `k` — tracks the position where the next remaining element should be placed.

If an element should not be deleted, I move it to position `k`. After each iteration, I update `size = k`.

This avoids creating additional arrays and makes the elimination process more efficient.

## Haskell Implementation (Functional)

In Haskell, I used **recursion, guards, and list comprehension** instead of loops.

The implementation has two main functions:

- `removeNumbers` — filters elements based on the current step.
- `arrayDevide` — recursively calls itself with the filtered list until only one element remains.

I used `zip [1..] xs` to assign positions to the elements, allowing me to filter them based on their indices.

Unlike C#, Haskell creates new filtered lists instead of modifying the original list.

## Results

| | C# | Haskell |
|---|---|---|
| Compiler | .NET 10 | GHC 8.8 |
| Score | **100/100** | **97/100** |
| Verdict | Accepted | Time Limit Exceeded |
| Execution Time | 1.595s | Exceeded 5s |
| Memory | 409.3 MB | 4.5 MB |

## Performance Comparison

**Why did C# use more memory?**

In C#, I allocated an array of size `n` at the beginning. Even after removing elements logically, the original array remains allocated in memory.

Haskell uses **lazy evaluation**, meaning it can generate and process list elements only when needed. Unused intermediate list elements can also be garbage-collected.

This helps explain why Haskell used only 4.5 MB compared to C#'s 409.3 MB.

**Why was C# faster?**

C# modifies elements directly inside an existing array, while Haskell performs recursive filtering and creates intermediate lists. These operations introduce additional processing overhead.

## Complexity

| | C# | Haskell |
|---|---|---|
| Time | O(n) | O(n) |
| Initial storage | O(n) | Lazy, as needed |
| Additional space | O(1) | Depends on evaluation |

# Bonus

# Array Elimination — Mathematical Approach (C#)

## Description

After solving the problem using array processing in C# and recursion in Haskell, I also explored a mathematical approach to find the remaining number without creating an array.

## Finding the Pattern

I noticed that the same results appear multiple times for different input values.

After testing the algorithm, I found the following pattern:

| Number | Times Appeared |
|---|---:|
| 1 | 2 |
| 3 | 12 |
| 15 | 72 |
| 87 | 432 |
| 519 | 2,592 |
| 3111 | 15,552 |

Each number appears **6 times more often** than the previous one.

The resulting numbers also follow a pattern:

`1 → 3 → 15 → 87 → 519 → 3111`

Each next number can be calculated using:

`result = result * 6 - 3`

## Implementation

Instead of processing an entire array, I used two variables:

- `result` — stores the number that will remain.
- `section` — represents the last input value for which the current result is valid.

The initial values are:

```csharp
long section = 2;
long result = 1;
```

For every next section, I update:

```csharp
section = section * 6 + 2;
result = result * 6 - 3;
```

The loop continues until `section` reaches or exceeds the input `n`.

## C# Code

```csharp

        int n = Convert.ToInt32(Console.ReadLine());
        long section = 2;
        long result = 1;
        while (n > section)
        {
            section = section * 6 + 2;
            result = result * 6 - 3;
        }
        Console.WriteLine(result);
  
```

## E-Olymp Result

- **Compiler:** C# (Microsoft .NET 10)
- **Score:** 100 / 100
- **Execution Time:** 0.062s
- **Memory:** 28 MB
- **Verdict:** Accepted

## Performance Comparison

| | C# (Array) | Haskell (List) | C# (Formula) |
|---|---|---|---|
| Score | 100/100 | 97/100 | 100/100 |
| Execution Time | 1.595s | Time Limit Exceeded (5s) | **0.062s** |
| Memory | 409.3 MB | 4.5 MB | **28 MB** |
| Time Complexity | O(n) | O(n) | **O(log n)** |
| Additional Space | O(1) | Depends on evaluation | O(1) |

The mathematical solution was approximately **25.7 times faster** than the array-based C# implementation and used significantly less memory.

## Conclusion

The mathematical approach achieved **100/100**, with an execution time of only **0.062 seconds** and **28 MB** of memory usage.

Unlike the previous implementations, this solution avoids creating and processing arrays or lists, making it significantly more efficient.

However, since the original assignment specifically requires array/list processing, I kept the imperative C# and functional Haskell implementations as my main solutions.


