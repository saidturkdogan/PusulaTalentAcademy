# Pusula Talent Academy

A C# console application containing various algorithmic solutions and data processing utilities for the Pusula Talent Academy document candidate evaluation.

## Overview

This project contains four main algorithmic solutions implemented in C# .NET 9.0:

1. **Employee Filtering** - Filters employees based on specific criteria and returns statistical data
2. **XML Data Processing** - Parses XML data to filter people based on business rules
3. **Vowel Subsequence Analysis** - Finds the longest vowel subsequence in words
4. **Maximum Increasing Subarray** - Identifies the maximum sum increasing subarray

## Features

- **Employee Management**: Filter employees by age, department, salary, and hire date
- **XML Processing**: Parse and filter XML data with complex business logic
- **String Analysis**: Find longest vowel subsequences in word collections
- **Array Algorithms**: Calculate maximum sum increasing subarrays
- **JSON Output**: All functions return results in JSON format for easy integration

## Requirements

- .NET 9.0 or later
- Windows, macOS, or Linux

## Project Structure

```
├── FilterEmployees.cs                    # Employee filtering and statistics
├── FilterPeopleFromXml.cs               # XML data processing
├── LongestVowelSubsequenceAsJson.cs     # Vowel subsequence analysis
├── MaxIncreasingSubArrayAsJson.cs       # Maximum increasing subarray
├── PusulaTalentAcademyDocumentCandidate.csproj
└── README.md
```

## Usage

### Building the Project

```bash
dotnet build
```

### Running the Application

```bash
dotnet run
```

## Algorithm Details

### 1. Employee Filtering (`FilterEmployees.cs`)

Filters employees based on the following criteria:

- Age between 25-40 (inclusive)
- Department: IT or Finance
- Salary between 5000-9000 (inclusive)
- Hired after January 1, 2017

**Returns JSON with:**

- Sorted list of employee names
- Total, average, minimum, and maximum salaries
- Employee count

### 2. XML Data Processing (`FilterPeopleFromXml.cs`)

Processes XML data containing person information and filters based on:

- Age greater than 30
- Department equals "IT"
- Salary greater than 5000
- Hired before January 1, 2019

**Returns JSON with:**

- Sorted list of names
- Total and average salaries
- Maximum salary
- Person count

### 3. Vowel Subsequence Analysis (`LongestVowelSubsequenceAsJson.cs`)

Analyzes a list of words to find the longest consecutive vowel subsequence in each word.

**Returns JSON array with:**

- Original word
- Longest vowel sequence found
- Length of the sequence

### 4. Maximum Increasing Subarray (`MaxIncreasingSubArrayAsJson.cs`)

Finds the contiguous increasing subarray with the maximum sum.

**Returns JSON array containing:**

- The subarray with maximum sum
- Empty array if input is null or empty

## Example Outputs

### Employee Filtering

```json
{
  "Names": ["Ali", "Ayşe", "Veli"],
  "TotalSalary": 21500,
  "AverageSalary": 7166.67,
  "MinSalary": 6000,
  "MaxSalary": 8500,
  "Count": 3
}
```

### Vowel Subsequence

```json
[
  {
    "Word": "aeiou",
    "Sequence": "aeiou",
    "Length": 5
  },
  {
    "Word": "bcd",
    "Sequence": "",
    "Length": 0
  }
]
```

## Development

This project was created as part of the Pusula Talent Academy document candidate evaluation process. Each algorithm is implemented as a separate class with static methods for easy testing and integration.

## License

This project is licensed under the terms specified in the LICENSE file.
