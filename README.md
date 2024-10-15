# Sauce Labs Sample E2E Test Automation with C#, Playwright, and NUnit

This repository contains a sample end-to-end (E2E) test automation project for the Sauce Labs Sample Application, built using C#, Playwright, and NUnit. The project follows the Page Object Model (POM) pattern to promote maintainability and readability, making it easy to manage and scale.

# Project Structure
- PageObjectModels: Contains page classes representing different pages within the Sauce Labs application, with elements and actions encapsulated for reusability.
- Tests: Holds all test classes for different test scenarios, using NUnit as the testing framework.
- Configuration: Supports dynamic test execution environments via environment variables, with fallback to local values for flexibility.

# Key Features
- Playwright with C#: Leverages Playwright’s powerful browser automation capabilities to drive cross-browser tests with ease.
- NUnit: Integrates NUnit as the test runner for a simple and efficient testing workflow.
- Page Object Model: Follows the POM design pattern, which simplifies test maintenance and promotes cleaner code.
- GitHub Actions CI/CD Pipeline: Includes a sample YAML pipeline that securely handles credentials and prompts for input at runtime, enabling continuous integration and continuous delivery.
