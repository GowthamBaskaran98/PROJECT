CREATE TABLE USER_LOGIN
(
userId VARCHAR(15) PRIMARY KEY NOT NULL,
mobileNumber VARCHAR(15) UNIQUE,
password VARCHAR(15),
userType VARCHAR(15),
created_At DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, 
);

BEGIN TRANSACTION
INSERT INTO USER_LOGIN(userId, mobileNumber, password, userType) VALUES ('admin', '8778613988', 'admin', 'Admin');
COMMIT TRANSACTION

DROP TABLE USER_LOGIN
Select * from USER_LOGIN

UPDATE USER_LOGIN SET userType = 'HotelOwner' WHERE userType = 'Hotel Owner'


CREATE PROCEDURE REGISTRATION
@userId VARCHAR(15),
@mobileNumber VARCHAR(10),
@password VARCHAR(15),
@userType VARCHAR(10)
AS
BEGIN	
      --INSERT
			INSERT INTO USER_LOGIN(userId,mobileNumber,password,userType) VALUES (@userId,@mobileNumber,@password,@userType)
END

DROP PROCEDURE REGISTRATION

CREATE TABLE HOTELLIST
(
hotelId INT IDENTITY PRIMARY KEY,
hotelName VARCHAR(15) NOT NULL,
hotelAddress VARCHAR(30) NOT NULL,
vacantRoom NUMERIC(15) NOT NULL,
roomSize VARCHAR(15),
hotelService VARCHAR(30),
pricePerDay NUMERIC(5) NOT NULL,
);
CREATE PROCEDURE STORED_PROCEDURE
@hotelId numeric(3) ,
@hotelName VARCHAR(15),
@hotelAddress VARCHAR(30),
@vacantRoom NUMERIC(15),
@roomSize VARCHAR(15),
@hotelService VARCHAR(30),
@pricePerDay NUMERIC(5),
@Action NUMERIC(2)
AS

BEGIN	
      --INSERT
      IF @Action = 1
      BEGIN
			INSERT INTO HOTELLIST(hotelID, hotelName, hotelAddress, vacantRoom, roomSize, hotelService, pricePerDay) VALUES (@hotelId,@hotelName,@hotelAddress,@vacantRoom,@roomSize,@hotelService,@pricePerDay)
      END
      IF @Action = 2
      BEGIN
			UPDATE HOTELLIST SET hotelID = @hotelId, hotelName = @hotelName, hotelAddress = @hotelAddress, vacantRoom = @vacantRoom, roomSize = @roomSize, hotelService = @hotelService, pricePerDay = @pricePerDay where hotelId = @hotelId
      END
END

CREATE PROCEDURE STORED_PROCEDURE_SELECT
	@Action VARCHAR(6)
AS

BEGIN
	--SELECT
      IF @Action = 4
      BEGIN
            SELECT hotelID, hotelName, hotelAddress, vacantRoom, roomSize, hotelService, pricePerDay FROM HOTELLIST
      END
END

CREATE PROCEDURE STORED_PROCEDURE_DELETE
	@hotelID NUMERIC(2),
	@Action VARCHAR(6)
AS

BEGIN
      IF @Action = 3
      BEGIN
          DELETE FROM HOTELLIST WHERE hotelId = @hotelID;
      END
       
END
drop table HOTELLIST
drop procedure STORED_PROCEDURE
DROP PROCEDURE STORED_PROCEDURE_SELECT
DROP PROCEDURE STORED_PROCEDURE_DELETE


CREATE TABLE Voter_List
(
voterId VARCHAR(10) PRIMARY KEY NOT NULL,
name VARCHAR(15) NOT NULL,
mobileNumber VARCHAR(15) UNIQUE,
age numeric(2),
);
INSERT INTO Voter_List (voterId,name,mobileNumber,age) VALUES('1656465456','Gowtham','9876543210',20)
INSERT INTO Voter_List (voterId,name,mobileNumber,age) VALUES('1656465451','Kowsalya','9876543216',16)
INSERT INTO Voter_List (voterId,name,mobileNumber,age) VALUES('1656465450','Priya','9876543219',21)


SELECT voterId,name,mobileNumber,age,
CASE
    WHEN age >= 18 THEN 'Eligible for Voting'
    ELSE 'Not eligible'	
END AS QuantityText
FROM Voter_List;

DROP TABLE Voter_List