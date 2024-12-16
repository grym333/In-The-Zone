# In The Zone - MLB Game Visualization

## Description

"In The Zone" is a real-time web application that provides engaging visualizations of MLB games, focusing on security and data integrity through quantum-inspired concepts.

## Project Structure

The solution is organized into the following projects:

-   **InTheZone.Web:** ASP.NET Core web application (presentation layer).
-   **InTheZone.Services:** Core application logic and services.
-   **InTheZone.Data:** Data access layer (entities, repositories).
-   **InTheZone.Tests:** Unit, integration, and end-to-end tests.

## Quantum-Inspired Security

-   **Data Proxies:** Secure access to external APIs.
-   **Probabilistic Validation:** Data integrity checks.
-   **Secure Code Execution:** Uses Docker containers.
-   **Contextual Sanitization:** Prevents XSS vulnerabilities.
-   **"Quantum Waiting":** Asynchronous operations for optimal data.
-   **Entanglement:** Dependency Injection and graph structures model code/data relationships.

## Security Measures

-   Input Validation
-   Output Sanitization
-   Secure Data Storage
-   Authentication (ASP.NET Core Identity)
-   Authorization (Role-based)
-   Comprehensive Logging

## Getting Started

1. **Prerequisites:** .NET SDK, Node.js, npm, Visual Studio Code, Docker
2. **Clone the repository:** `git clone <repository-url>`
3. **Database Setup:** Configure your connection string in `appsettings.json`.
4. **API Keys:** Store your MLB Stats API key securely (e.g., user secrets or environment variables).
5. **Build:** `dotnet build`
6. **Run:** `dotnet run --project InTheZone.Web`

## Testing

-   **Unit Tests:** Located in `InTheZone.Tests`. Run using `dotnet test` in the solution root or `InTheZone.Tests` folder.
-   **Integration Tests:** In `InTheZone.Tests`, designed to test interactions between different layers of the application, ensuring they work together correctly.
-   **End-to-End Tests:** Located in the `InTheZone.Tests` project, these tests use Selenium/Playwright to simulate user interactions with the UI, testing the entire application stack.
-   **Fuzz Tests:** Included in `InTheZone.Tests`, fuzz tests are designed to find security vulnerabilities by sending random data to the application's inputs.
-   **Performance Tests:** Performance tests, using tools like K6 or LoadRunner, are also part of the `InTheZone.Tests` project, focusing on the application's performance under load.

## Google AI Studio Integration

-   **Quantum Simulation Tools:** Uses Google AI Studio for representing quantum concepts.
-   **Vertex AI:** Integrated for pitch prediction and player performance analysis.
-   **Google Cloud Storage:** Used for data storage.
-   **Google Cloud APIs:** Used for various data processing and communication tasks.

## Docker

Each project includes a `Dockerfile` for containerization. Run `docker build` to create images.

## Deployment

Instructions for deploying the application to your chosen environment (e.g., Google Cloud Run, Kubernetes).

## Contributing

Guidelines for contributing to the project.

## License

License information.MIT License

Copyright (c) [year] [fullname]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
