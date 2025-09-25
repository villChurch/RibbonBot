pipeline {
    agent any

    environment {
        BUILD_DIR = 'build_output'
    }

    stages {
        stage('Restore NuGet Packages') {
            steps {
                bat 'nuget restore RibbonBot.sln'
            }
        }

        stage('Build') {
            steps {
                bat "msbuild RibbonBot.sln /p:OutDir=${BUILD_DIR}\\ /p:Configuration=Release"
            }
        }
    }

    post {
        success {
            echo "Build completed successfully. Output is in ${BUILD_DIR}"
        }
        failure {
            echo "Build failed."
        }
    }
}
