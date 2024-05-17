pipeline {
agent any
stages {
 stage("Code Checkout from Github") {
  steps {
   git branch: 'main',
    url: 'https://github.com/Ashok7867/devops-dotnet-assignment.git'
  }
 }
   stage('Code Quality Check via SonarQube') {
   steps {
       script {
       def scannerHome = tool 'sonarqube';
           withSonarQubeEnv("sonarqube-container") {
           sh "${tool("sonarqube")}/bin/sonar-scanner \
           -Dsonar.projectKey=dotnet-calc \
           -Dsonar.sources=. \
           -Dsonar.css.node=. \
           -Dsonar.host.url=http://devops.sonarqube.com \
           -Dsonar.login=squ_7bd899d9588930a6836ff1a53b3f0aace1647c24"
                   }
               }
           }
       }
    }
}
