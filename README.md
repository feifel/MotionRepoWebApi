# MotionRepoWebApi
REST API to access the [MotionRepo](https://github.com/feifel/MotionRepo) and the [MotionRepoContrib](https://github.com/feifel/MotionRepoContrib).

## Features
- Uses Auth0 for user Authentication.
- It provides CRUD operations for Workouts, Motions and Avatars.
- Read Operations do not need Authentication.

## how to build and run it
- Open the project in Visual Studio Code
- Open a terminal and run: dotnet run
- Open https://localhost:7031 in your browser to access the Swagger UI and test it
- Except for the read operations you need to authenticate yourself by doing this:
  https://youtu.be/NEllH_jX9Dg?si=T40dqg0xuinJIlRj&t=104 