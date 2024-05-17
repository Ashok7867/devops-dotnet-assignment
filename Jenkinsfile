pipeline {
    agent any
    tools {
        maven 'Maven'
    }

    stages {
        stage('Git Checkout') {
            steps {
                checkout scmGit(branches: [[name: '*/main']], extensions: [], userRemoteConfigs: [[url: 'https://github.com/Ashok7867/devops-dotnet-assignment.git']])
                echo 'Git Checkout Completed'
            }
        }

        stage('SonarQube Analysis') {
            steps {
                withSonarQubeEnv('Sonarserver') {
                    bat '''mvn clean verify sonar:sonar -Dsonar.projectKey='dotnet-calc' -Dsonar.projectName='dotnet-calc' -Dsonar.host.url='http://devops.sonarqube.com' //port 9000 is default for sonar
                    echo 'SonarQube Analysis Completed'
                }
            }
        }
    }
}
