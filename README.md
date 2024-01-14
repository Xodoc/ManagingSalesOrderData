# How to start a project

**The first method using InMemory instead of a real database**

Required tools:
1) IDE Visual Studio

Steps to start:
1) Download the project
2) Open the solution using Visual Studio
3) Select the project to launch ManagingSalesOrderData.Server
3) Select build type Release/Debug
4) Launch using the ctrl+f5 key or press the play button, after which the browser will open with the application start page.

**The second method using a real database**

Required tools:
1) IDE Visual Studio
2) SQL Server Express LocalDB

Steps to start:
1) Download the project
2) Open the solution using Visual Studio
3) Select Release build type
4) Right-click on ManagingSalesOrderData.Server in Solution Explorer and select “publish” and publish
5) Open the folder where you published the application and run ManagingSalesOrderData.Server.exe
6) Open a browser and go to the address "https://loacalhost:5001/", should load the application's home page. To go to swagger, use the url "https://loacalhost:5001/swagger".

If none of the methods worked, then in the Publish folder there is an archive with a ready-made project for deployment. Just download the archive, unzip it and run the exe file.
