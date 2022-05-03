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

The tables were set up as follows (I chose to add location later on) - constraints NOT NULL and DEFAULT are used:

```SQL
CREATE TABLE Paintings(
  PaintingId INT NOT NULL AUTO_INCREMENT,
  PaintingName VARCHAR(1000) NOT NULL,
  PRIMARY KEY ( PaintingId )
);

CREATE TABLE PaintingInfo(
  PaintingInfoId INT NOT NULL AUTO_INCREMENT,
  Location VARCHAR(1000),
  YearFinished INT,
  IsPortrait BOOLEAN,
  IsLandscape BOOLEAN,
  IsFloral BOOLEAN,
  IsAnimal BOOLEAN,
  PRIMARY KEY ( PaintingId )
);

ALTER TABLE Painting ADD CONSTRAINT FK_PaintingInfo FOREIGN KEY (PaintingId) REFERENCES PaintingInfo(PaintingId);

ALTER TABLE paintinginfo ALTER Location SET DEFAULT 'Not listed.';

ALTER TABLE paintinginfo ALTER IsPortrait SET DEFAULT 0;
ALTER TABLE paintinginfo ALTER IsSelf SET DEFAULT 0;
ALTER TABLE paintinginfo ALTER IsPlant SET DEFAULT 0;
ALTER TABLE paintinginfo ALTER IsAnimal SET DEFAULT 0;
ALTER TABLE paintinginfo ALTER IsLandscape SET DEFAULT 0;
```

Here are example SQL statements for updating and adding to the database:

```SQL
UPDATE `vangoghservice`.`paintinginfo` SET `IsPortrait` = '0', `IsSelf` = '0', `IsPlant` = '0', `IsAnimal` = '0' WHERE (`InfoId` = '1');

INSERT INTO Painting (PaintingName) VALUES ("Almond Blossoms");
INSERT INTO PaintingInfo (YearFinished, IsPortrait, IsSelf, IsPlant, IsAnimal, IsLandscape, PaintingId, Location) VALUES (1890, False, False, True, False, False, 9, "Van Gogh Museum, Netherlands");
```

### Response Class
The Response class was created in order to standardize the response message from every HTTP request. It very simply holds three members: statusCode (the HTTP code associated with the call), statusDescription (string explanation of what the statusCode means), and a paintings list (which simultaneously calls PaintingInfo):

```C#
namespace VanGoghAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        
        public string statusDescription { get; set; } 

        // GET method properties for both painting and paintinginfo:
        public List<Painting> paintings { get; set; }
    }
}
```

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


PUT /painting/{id} updates painting information where PaintingId = id. Sample request body:

```JSON
{
     "paintingId": 1,
     "paintingName": "The Starry Night",
     "paintingInfo": {}
}
```

and a success:

```JSON
{
    "statusCode": 200,
    "statusDescription": "Update successful on painting #1!",
    "paintings": [
        {
            "paintingId": 1,
            "paintingName": "The Starry Night",
            "paintingInfo": {
                "paintingInfoId": 0,
                "yearFinished": null,
                "isPortrait": false,
                "isSelf": false,
                "isPlant": false,
                "isAnimal": false,
                "isLandscape": false,
                "paintingId": 0,
                "location": "Not listed."
            }
        }
    ]
}
```

and a failure when paintingId does not match id:

```JSON
{
    "statusCode": 400,
    "statusDescription": "Bad request. Parameter painting ID does not match PaintingID.",
    "paintings": null
}
```

and a failure when paintingId does not exist:

```JSON
{
    "statusCode": 404,
    "statusDescription": "Painting ID not found.",
    "paintings": null
}
```

The DELETE method will only process if PaintingInfo for the associated id has been deleted already. Example of success:

```JSON
{
    "statusCode": 200,
    "statusDescription": "Successfully deleted painting #9",
    "paintings": null
}
```

Example of failure where parameter id does not exist:

```JSON
{
    "statusCode": 404,
    "statusDescription": "Painting #0 not found.",
    "paintings": null
}
```

Example of failure PaintingInfo was not deleted prior:

```JSON
{
    "statusCode": 400,
    "statusDescription": "Something went wrong. Did you delete the PaintingInfo yet?",
    "paintings": null
}
```

#### 3. /paintinginfo/{id}
Supports PUT and DELETE methods.
PUT /paintinginfo/{id} updates the PaintingInfo of a painting with paintingId = id. Example of request body:

```JSON
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
}
```

and a successful response message:

```JSON
{
    "statusCode": 200,
    "statusDescription": "Update successful on painting #4!",
    "paintings": [
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
        }
    ]
}
```

and an unsuccessful response message matches the messages of PUT /painting/{id}.
<br>
DELETE /paintinginfo/{id} must be run first in order to successfully delete a painting from the database. Response messages for success and mismatched id are the same. Example of misc. failure:

```JSON
{
    "statusCode": 400,
    "statusDescription": "Bad request.",
    "paintings": null
}
```

#### Thank you for reading!!
