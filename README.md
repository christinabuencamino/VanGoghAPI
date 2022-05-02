[Github](https://github.com/christinabuencamino) | [LinkedIn](https://www.linkedin.com/in/christina-buencamino/)
<br>
### MySQL Database: VanGoghService
The database for this API was created in MySQL and involves two tables: a Painting table and a PaintingInfo table, which have a one to one relationship with the Painting table being the parent. The Painting table uses PaintingId as a primary key, and the PaintingInfo table uses PaintingInfoId as a primary key, and FK_PaintingId as a foreign key pointed towards PaintingId in the Painting table.

{: style="text-align:center"}
![https://user-images.githubusercontent.com/66935005/166314404-b607cecf-0965-46dc-b5e7-0a9fc68265f3.png](https://user-images.githubusercontent.com/66935005/166314404-b607cecf-0965-46dc-b5e7-0a9fc68265f3.png)
  
I have included 9 of his most famous paintings as samples in the database. Their names are stored in Paintings, and their details (such as year made, category, and location) are in PaintingInfo. <br>

{: style="text-align:center"}
![https://user-images.githubusercontent.com/66935005/166315974-f9d3dc9f-1fae-46c9-a783-8536839f0ca8.png](https://user-images.githubusercontent.com/66935005/166315974-f9d3dc9f-1fae-46c9-a783-8536839f0ca8.png)

{: style="text-align:center"}
![https://user-images.githubusercontent.com/66935005/166315898-bc696faf-abcb-4730-b965-9ad163b33b93.png](https://user-images.githubusercontent.com/66935005/166315898-bc696faf-abcb-4730-b965-9ad163b33b93.png)

### Response 
lol

### API Endpoints and HTTP Responses
There are three endpoints currently supported:
#### 1. /painting
Supports GET and POST methods.<br>
GET /painting returns all paintings, with paintinginfo, from the database. Example of successful GET response:
```JSON
{
    "statusCode": 200,
    "statusDescription": "Successful GET on all paintings!",
    "paintings": [
        {
            "paintingId": 1,
            "paintingName": "The Starry Night",
            "paintingInfo": {
                "paintingInfoId": 1,
                "yearFinished": 1889,
                "isPortrait": false,
                "isSelf": false,
                "isPlant": false,
                "isAnimal": false,
                "isLandscape": true,
                "paintingId": 1,
                "location": "The Museum Of Modern Art, New York City"
            }
        },
        {
            "paintingId": 2,
            "paintingName": "Van Gogh self-portrait",
            "paintingInfo": {
                "paintingInfoId": 2,
                "yearFinished": 1889,
                "isPortrait": true,
                "isSelf": true,
                "isPlant": false,
                "isAnimal": false,
                "isLandscape": false,
                "paintingId": 2,
                "location": "Musée d'Orsay, Paris"
            }
        },
        {
            "paintingId": 3,
            "paintingName": "The Potato Eaters",
            "paintingInfo": {
                "paintingInfoId": 3,
                "yearFinished": 1885,
                "isPortrait": false,
                "isSelf": false,
                "isPlant": false,
                "isAnimal": false,
                "isLandscape": false,
                "paintingId": 3,
                "location": "Van Gogh Museum, ‎Amsterdam"
            }
        },
        {
            "paintingId": 4,
            "paintingName": "Irises",
            "paintingInfo": {
                "paintingInfoId": 4,
                "yearFinished": 1889,
                "isPortrait": false,
                "isSelf": false,
                "isPlant": true,
                "isAnimal": false,
                "isLandscape": false,
                "paintingId": 4,
                "location": "J. Paul Getty Museum, California"
            }
        },
        
        ( and so on ... )
        
    ]
}
```
Example of failure:
```JSON
    "statusCode": 404,
    "statusDescription": "No paintings found.",
    "paintings": null
```
<br>
POST /painting requires a request body in the following format, where you can optionally add painting information:
```JSON
{
     "paintingId": 10,
     "paintingName": "The Bedroom",
     "paintingInfo": {}
}
```
and returns if successful:
```JSON
{
    "statusCode": 200,
    "statusDescription": "POST successful for painting #10!",
    "paintings": null
}
```
and returns if unsuccessful:
```JSON
{
    "statusCode": 400,
    "statusDescription": "POST unsuccessful.",
    "paintings": null
}
```
#### 2. /painting/{id}
Supports GET, PUT, and DELETE methods.<br>
GET /painting/{id} returns painting information where PaintingId = id. Example response with id = 1:
```JSON
{
    "statusCode": 200,
    "statusDescription": "Successful GET on painting #1!",
    "paintings": [
        {
            "paintingId": 1,
            "paintingName": "The Starry Night",
            "paintingInfo": {
                "paintingInfoId": 1,
                "yearFinished": 1889,
                "isPortrait": false,
                "isSelf": false,
                "isPlant": false,
                "isAnimal": false,
                "isLandscape": true,
                "paintingId": 1,
                "location": "The Museum Of Modern Art, New York City"
            }
        }
    ]
}
```
Example of a failed GET response:
```JSON
{
    "statusCode": 404,
    "statusDescription": "Painting #0 not found.",
    "paintings": null
}
```
<br>
PUT /painting/{id} updates painting information where PaintingId = id. Sample request body:
```JSON

```

- /paintinginfo/{id}

These 
