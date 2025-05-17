pipeline {
    agent any

    triggers {
        cron('H/10 * * * *') // every 10 minutes
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/DeepakProject19/-PlayWrightCsharp.git'
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
