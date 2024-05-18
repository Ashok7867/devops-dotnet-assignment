pipeline {
agent any
stages {
 stage("Code Checkout from Github") {
  steps {
   git branch: 'main',
    credentialsId: 'GitHub',
    url: 'git@github.com:Ashok7867/devops-dotnet-assignment.git'
  }
 }
 stage('Build') {
  steps {
   bat "msbuild.exe ${workspace}\\SampleCalculatorApp.sln /nologo /nr:false  /p:platform=\"x64\" /p:configuration=\"release\" /t:clean;restore;rebuild"
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
}
