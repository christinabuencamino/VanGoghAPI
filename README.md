
	Add any instructions or documentation that you want to share with others. 
•	What are the different endpoints that a client can use? (/paintings, /paintings/{id}, /paintinginfo/id - GET, GET by ID, PUT painting or paintinginfo, POST painting, DELETE paintinginfo and then DELETE painting)

•	Sample request bodies, if applicable? 
•	Sample response body? (There should only be one, as this should be consistent. More information on this further below). (code, desc, painting(s) worked with)
	If you make any changes to your API idea, document them in your README.md file. You can completely change your idea if you’d like, and for whatever reason you want to. Just write down why! (added default, location column)

	You’re going to send me all of the SQL needed to make your entire database for this API, in a .sql file. 

# VanGoghAPI
## An API to call Vincent van Gogh paintings and their details, by Christina Buencamino<br>
[Github](https://github.com/christinabuencamino) | [LinkedIn](https://www.linkedin.com/in/christina-buencamino/)
<br>
## Background
The database for this API was created in MySQL and involves two tables: a Painting table and a PaintingInfo table, which have a one to one relationship with the Painting table being the parent. The Painting table uses PaintingId as a primary key, and the PaintingInfo table uses PaintingInfoId as a primary key, and FK_PaintingId as a foreign key pointed towards PaintingId in the Painting table.

{: style="text-align:center"}
![https://user-images.githubusercontent.com/66935005/166314404-b607cecf-0965-46dc-b5e7-0a9fc68265f3.png](https://user-images.githubusercontent.com/66935005/166314404-b607cecf-0965-46dc-b5e7-0a9fc68265f3.png)
  
I have included 9 of his most famous paintings as samples in the database. Their names are stored in Paintings, and their details (such as year made, category, and location) are in PaintingInfo. <br>

{: style="text-align:center"}
![https://user-images.githubusercontent.com/66935005/166315974-f9d3dc9f-1fae-46c9-a783-8536839f0ca8.png](https://user-images.githubusercontent.com/66935005/166315974-f9d3dc9f-1fae-46c9-a783-8536839f0ca8.png)

{: style="text-align:center"}
![https://user-images.githubusercontent.com/66935005/166315898-bc696faf-abcb-4730-b965-9ad163b33b93.png](https://user-images.githubusercontent.com/66935005/166315898-bc696faf-abcb-4730-b965-9ad163b33b93.png)

<br>
