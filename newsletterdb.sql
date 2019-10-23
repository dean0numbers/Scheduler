CREATE DATABASE dbTest

USE dbTest

CREATE TABLE [dbo].[Contacts] (
    [pKey]     INT                 IDENTITY (1, 1) NOT NULL,
    [fName]    VARCHAR (35) SPARSE NULL,
    [lName]    VARCHAR (50)        NULL,
    [eMail]    VARCHAR (50)        NULL,
    [Phone]    VARCHAR (15)        NULL,
    [Comments] VARCHAR (75)        NULL,
    PRIMARY KEY CLUSTERED ([pKey] ASC)
);

CREATE TABLE [dbo].[Schedule] (
    [pKey]     INT                 IDENTITY (1, 1) NOT NULL,
    [Descript] VARCHAR (75) SPARSE NULL,
    [SendFile] VARCHAR (50) SPARSE NULL,
    [SendDate] DATE                NULL,
    PRIMARY KEY CLUSTERED ([pKey] ASC)
);

CREATE proc qryStrContacts
	as begin
		SELECT * FROM Contacts
	end;

CREATE proc qryStrContactRemove 
	@pKey int
	as begin
		DELETE FROM Contacts WHERE pKey = @pKey
	end;

CREATE proc qryStrInsertContact 
	@fName varchar(35),
	@lName varchar(50),
	@eMail varchar(50),
	@Phone varchar(15),
	@Comments varchar(75)
	as 
	Begin
		INSERT INTO [Contacts] VALUES (@fName, @lName, @eMail, @Phone, @Comments)
	end

CREATE procedure qryStrInsertSchedule 
	@Descript varchar(75),
	@sendFile varchar(50),
	@sendDate date
	as Begin
		INSERT INTO [Schedule] VALUES (@Descript, @sendFile, @sendDate)
	end

Create proc qryStrSchedule
	as begin
		SELECT* FROM Schedule
	end

CREATE proc qryStrScheduleRemove 
	@pKey int
	as begin
		DELETE FROM Schedule WHERE pKey = @pKey
	end

CREATE proc qryStrUpdateSchedule
	@pKey Int, 
	@Descript varchar(75),
	@sendFile varchar(50),
	@sendDate Date
	as Begin
		UPDATE [Schedule] SET Descript = @Descript, sendFile = @sendFile, sendDate = @sendDate WHERE pKey = @pKey
	end

CREATE proc qryStrUpdateContact
	@pKey Int, 
	@fName varchar(35),
	@lName varchar(50),
	@eMail varchar(50),
	@Phone varchar(15),
	@Comments varchar(75)
	as begin
		UPDATE [Contacts] SET fName = @fName, lName = @lName, eMail = @eMail, Phone = @Phone, Comments = @Comments WHERE pKey = @pKey
	end