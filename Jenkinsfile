pipeline {
    agent {
        label 'linux'
    }

    environment {
        BUILD_DIR = 'build_output'
    }

    stages {

        stage('Restore Dependencies') {
            steps {
                sh 'dotnet restore RibbonBot.sln'
            }
        }

        stage('Build') {
            steps {
                // sh "dotnet build RibbonBot.sln --configuration Release --output ${BUILD_DIR}"
                // Get the short commit hash
                script {
                    def commitHash = sh(script: "git rev-parse --short HEAD", returnStdout: true).trim()
                    sh "docker build -t ribbon_bot-website:${commitHash} RibbonBotWebsite"
                }
                // sh "cp RibbonBotWebSite/Dockerfile ${BUILD_DIR}"
            }
        }
    }

    post {
        success {
            echo "✅ Build and tests completed successfully. Output is in ${BUILD_DIR}"
        }
        failure {
            echo "❌ Build or tests failed."
        }
    }
}
