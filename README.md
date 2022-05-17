# CustomerRewards

Install                          | Version    
---------------------------------|------------
Visual Studio (recommended)      | VS 2019+
.Net Framework                   | 4.7.2

Step 1: Open the project from github.

Step 2: build the application by using manual or Ctrl+Shift+B

Step 3: Run the application with the help of option IIS Express(top middle of the VS2019), and minimize the application.

Step 4: Go to Postman and follow the below steps:

#Postman
========
Request URL: https://localhost:44347/api/rewards

Request method: POST

Request Body: 
				{
				   "TotalAmount":123
				}

Response Body: 
				{
				    "Points": 96
				}
  

#For Code review:
=================
Step 1: 

\source\repos\CustomerRewards\CustomerRewards\Controllers\RewardsController.cs

#Documentation
==============
\source\repos\CustomerRewards\CustomerRewards\Documentation\ApiDoc.txt

