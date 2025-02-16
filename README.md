# Expense Tracker Project

This is an Expense Tracker application built using ASP.NET Core MVC with Syncfusion elements. The application is automatically deployed to AWS Elastic Beanstalk using GitHub Actions.

## Features

- Track your expenses and income
- Categorize your transactions
- Generate reports and charts using Syncfusion components
- User authentication and authorization
- Responsive design

## Technologies Used

- ASP.NET Core MVC
- Syncfusion
- AWS Elastic Beanstalk
- GitHub Actions

## Getting Started

### Prerequisites

- .NET Core SDK
- AWS account
- GitHub account

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/expense-tracker-project.git
    ```
2. Navigate to the project directory:
    ```bash
    cd expense-tracker-project
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```
4. Build the project:
    ```bash
    dotnet build
    ```
5. Run the application:
    ```bash
    dotnet run
    ```

### Deployment

The application is automatically deployed to AWS Elastic Beanstalk using GitHub Actions. To set up the deployment, follow these steps:

1. Create an AWS Elastic Beanstalk environment.
2. Add your AWS credentials to GitHub Secrets.
3. Configure the GitHub Actions workflow file located at `.github/workflows/deploy.yml`.