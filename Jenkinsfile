pipeline {
agent any
options { skipDefaultCheckout() }   
stages {
    stage('CleanWorkspace') {
            steps {
                cleanWs()
            }
        }
    stage("Code Checkout from Github") {
        steps {
            git branch: 'main',
            credentialsId: 'GitHub',
            url: 'git@github.com:Ashok7867/devops-dotnet-assignment.git'
                }
            }
    stage('Restore'){
        steps {
            sh 'dotnet restore SampleCalculatorApp/SampleCalculatorApp.csproj'
            }
        }
    stage('Build'){
        steps {
            sh 'dotnet build SampleCalculatorApp/SampleCalculatorApp.csproj --configuration Release'
            }
        }
 
    stage('Code Analysis') {
            environment {
                scannerHome = tool 'Sonar'
            }
            steps {
                script {
                    withSonarQubeEnv('Sonar') {
                        sh "${scannerHome}/bin/sonar-scanner \
                            -Dsonar.projectKey=dotnet-calc \
                            -Dsonar.projectName=dotnet-calc \
                            -Dsonar.projectVersion=1.0 \
                            -Dsonar.sources=."
                    }
                }
            }
        }
    }
post { 
    success { 
        archiveArtifacts artifacts: '**/*', fingerprint: true
        }
    always {
        cleanWs() /* clean up our workspace */
        }
    }      
}
