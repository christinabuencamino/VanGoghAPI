USE VanGoghService;

CREATE TABLE Paintings(
  PaintingId INT NOT NULL AUTO_INCREMENT,
  PaintingName VARCHAR(1000) NOT NULL,
  PRIMARY KEY ( PaintingId )
);

CREATE TABLE PaintingInfo(
  PaintingInfoId INT NOT NULL AUTO_INCREMENT,
  YearFinished INT,
  IsPortrait BOOLEAN,
  IsLandscape BOOLEAN,
  IsFloral BOOLEAN,
  IsAnimal BOOLEAN,
  Location VARCHAR(1000),
  PRIMARY KEY ( PaintingId )
);

ALTER TABLE PaintingInfo ADD CONSTRAINT FK_Painting FOREIGN KEY (PaintingInfoId) REFERENCES Painting(PaintingId);

ALTER TABLE paintinginfo ALTER Location SET DEFAULT 'Not listed.';

ALTER TABLE paintinginfo ALTER IsPortrait SET DEFAULT 0;
ALTER TABLE paintinginfo ALTER IsSelf SET DEFAULT 0;
ALTER TABLE paintinginfo ALTER IsPlant SET DEFAULT 0;
ALTER TABLE paintinginfo ALTER IsAnimal SET DEFAULT 0;
ALTER TABLE paintinginfo ALTER IsLandscape SET DEFAULT 0;
