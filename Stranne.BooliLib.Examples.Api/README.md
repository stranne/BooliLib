# BooliLib ASP.NET Core RESTful API Example

[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/stranne/BooliLib/master/LICENSE)

A simple example project for BooliLib that wrapps the Booli API with its own API with a Swagger definition.

## Usage

### Configure

You will need a caller id and key from Booli to use theire the API. They can be asked for [here](https://www.booli.se/api/key).

Add them to ``appsettings.json`` file or as environment variables in the system with the name ``BooliCallerId`` and ``BooliKey``.


### Build

To build the console application [dotnet sdk](https://www.microsoft.com/net/download/core#/sdk) needs to be installed on the device.

Navigate to the folder of the project is, i.e. ends with ...\Examples\Stranne.BooliLib.Examples.Api and run the following commands in a terminal, or build it with Visual Studio.

```cmd
dotnet restore
dotnet build
```

### Run

Open a terminal at the root of the project folder and run the following command. A swagger ui is accessible at the path ``swagger``, i.e. ``http://localhost:5000/swagger``.


```cmd
dotnet run
```