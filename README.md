# CustomerRewards

Install                          | Version    
---------------------------------|------------
Visual Studio (recommended)      | VS 2019+
.Net Framework                   | 4.7.2

Step 1: Open the project in VS2019 from github.

Step 2: build the application by manual(build application) or Ctrl+Shift+B

Step 3: Run the application with the help of option IIS Express(top middle of the VS2019), and minimize the application.

![runapplication](https://user-images.githubusercontent.com/105716493/168862511-db4338b4-377d-44c4-b672-7bd5f1e400a7.png)

Step 4: Go to Postman and call the API(i.e.: rewards) like as follows:

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

