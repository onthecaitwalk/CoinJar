# CoinJarAPI
Coin Jar API will only accept the latest US coinage and has a volume of 42 fluid ounces. Additionally, the jar has a counter to keep track of the total amount of money collected and can reset the count back to $0.00.

# README #

This README documents whatever steps are necessary to get your application up and running.

### Prerequisites

1. IDE:
   3. Visual Studio 2017 update 15.7 or later
2. [Latest .NET Core SDK](https://www.microsoft.com/net/download).

#### Running the application on Development

The application is designed to run with both IISExpress (on Windows):

**Visual Studio deployment:**

**Debug mode**

1. Make sure the `Web` project is selected as the startup project
2. **IIS Express**: Click the **IIS Express** option in the launch toolbar

**Without debugging**

1. Make sure the `Web` project is selected as the startup project
2. **IIS Express**: Make sure **IIS Express** is active in the launch toolbar
   1. press <kbd>CTRL</kbd> + <kbd>F5</kbd>

This will start the web project using the default profile in the `launchSettings.json` file.

The default profile will open the Swagger UI documents for the Coin Jar API.
