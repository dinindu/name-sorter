[![Build status](https://ci.appveyor.com/api/projects/status/jk0ueeulkcf90k2i/branch/master?svg=true)](https://ci.appveyor.com/project/dinindu/name-sorter/branch/master)

# Name Sorter

A simple application to sort a list of names.

## Solution

## Assumptions

- Last name is mandatory
- Last name will always be at the end of the line
- Each line contains a name of a single person
- Names of a person are separated from at least one space
- Multiple spaces and tabs between names will be ignored
- Empty lines are ignored
- Pre and post spaces will be ignored and trimmed
- Names that exceeds the maximum number of allowed given names (3) are considered invalid
- Invalid names are ignored in the process and will be excluded from the output

## How to build, run and test

### Prerequisites

- .Net Framework version 7.0

### Build

In the root level execute the following command

```sh
dotnet build
```

### Run the app

In a terminal go to ~/name-sorter/cli/NameSorter.ConsoleApp and run the following command to get the help screen with options.

```sh
dotnet run
```

#### Options

| Short form | Long form | Description                                     |
| ---------- | --------- | ----------------------------------------------- |
| -i         | --input   | Required. Input file containing unsorted names. |
| -o         | --output  | Required. Output file to store sorted names.    |

<br/>

#### Sample usage

```sh
dotnet run -i ./unsorted-names-list.txt -o ./sorted-names-list.txt
```

### Running the unit tests

In the root level execute the following command to run the unit tests in verbose mode.

```sh
dotnet test -v=normal
```

### Logs

- Log files will be stored under ~/name-sorter/cli/logs directory

<br/>
