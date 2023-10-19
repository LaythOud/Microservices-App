# Project Setup Guide

## How to Run the Project?

Running this project is simple and straightforward. Just follow these steps:

### Prerequisites
- Make sure you have Docker and Docker Compose installed on your system.

  - Docker Installation Guide: [Docker Documentation](https://docs.docker.com/engine/install/)
  
  - Docker Compose Installation Guide: [Docker Compose Documentation](https://docs.docker.com/compose/install/)

### Build Docker Images

First, navigate to the project directory in your terminal. Then, build the Docker images by running the following command:

```
    docker compose build
```


This command will build all the necessary images required for the project.

### Run the Project

After all the images have been built successfully, you can start the project by running the following command:


```
    docker compose up --wait
```


Please be patient, as it may take a couple of minutes for the project to fully start. Once the process is complete, you can access the project at the specified address (http://localhost:5167/Home/Index or http://127.0.0.1:5167/Home/Index).

That's it! You have successfully set up and run the project using Docker and Docker Compose. If you encounter any issues or have questions, feel free to reach out for assistance.