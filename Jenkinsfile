pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/DeepakProject19/-PlayWrightCsharp.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --no-restore'
            }
        }

        stage('Install Browsers') {
            steps {
                bat 'npx playwright install'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test --no-build'
            }
        }
    }
}
