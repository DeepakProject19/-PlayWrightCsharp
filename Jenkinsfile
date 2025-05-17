pipeline {
    agent any

    tools {
        dotnet 'dotnet-8' // Configure this in Jenkins global tools
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/YourUserName/YourRepo.git'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Install Browsers') {
            steps {
                sh 'pwsh bin/Release/net8.0/playwright.ps1 install --with-deps'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test --no-build --verbosity normal'
            }
        }
    }
}
