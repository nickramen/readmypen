/*INITIAL SETUP*/
/*START SECTION*/

--CREATE DATABASE READMYPEN_NICKRAMEN
GO
USE READMYPEN_NICKRAMEN
GO

--===============SCHEMA================
/*SECTION #1*/
CREATE SCHEMA [Acce]
GO
CREATE SCHEMA [Admin]
GO

--===============TABLES================
/*SECTION #2*/
CREATE TABLE [Acce].[tbRoles](
	[rol_Id]				INT IDENTITY(1,1),
	[rol_Description]		NVARCHAR(50)      NOT NULL

	CONSTRAINT  PK_Acce_tbRoles_rol_Id PRIMARY KEY(rol_Id)
);
GO

/*SECTION #3*/
CREATE TABLE [Acce].[tbUsers](
	[usr_Id]				INT IDENTITY(1,1),
	[usr_Username]			NVARCHAR(50)      NOT NULL,
	[usr_Password]			VARBINARY(8000)	  NOT NULL,
	[rol_Id]				INT               NOT NULL,

CONSTRAINT PK_Acce_tbUsers_usr_Id PRIMARY KEY(usr_Id),
CONSTRAINT FK_Acce_tbRoles_tbUsers_rol_Id FOREIGN KEY (rol_Id) REFERENCES [Acce].tbRoles(rol_Id)
);
GO

/*SECTION #4*/
CREATE TABLE [Admin].[tbPictures](
	[pic_Id]				INT IDENTITY(1,1),
	--[pic_PictureName]		NVARCHAR(MAX)     NOT NULL,
	[pic_PicturePath]		NVARCHAR(MAX)     NOT NULL,
	[usr_Id]				INT               NOT NULL,

CONSTRAINT PK_Acce_tbUsuarios_pic_Id PRIMARY KEY(pic_Id),
CONSTRAINT FK_Acce_tbPictures_tbUsers_usr_Id FOREIGN KEY (usr_Id) REFERENCES [Acce].tbUsers(usr_Id)
);
GO



/*SECTION #9*/
GO
CREATE PROCEDURE [UDP_Acce_tbUsers_Insert]
--========================================================
--Author:       Nicole Ramos
--Create date:  24/01/2023
--Description:  Inserts a new user in the database.
--========================================================
	@usr_Username			VARCHAR(50), 
	@usr_Password			VARCHAR(50),	
	@rol_Id					INT
AS
BEGIN
	INSERT INTO [Acce].[tbUsers] 
	 (
		 [usr_Username],
		 [usr_Password],
		 [rol_Id]
	 )
VALUES
  (
		@usr_Username,
		ENCRYPTBYPASSPHRASE('temere id est nuntius',@usr_Password,1,CONVERT(varbinary,@usr_Username)),		
		@rol_Id
 )
 SELECT SCOPE_IDENTITY();
END
GO



/*SECTION #8*/
GO
CREATE PROCEDURE [UDP_Acce_tbUsers_Login]
--========================================================
--Author:       Nicole Ramos
--Create date:  24/01/2023
--Description:  User login.
--========================================================
    @usr_Username			VARCHAR(50),
    @usr_Password           VARCHAR(50)
AS
BEGIN
    SELECT
                    [usr].[usr_Username],
                    [usr].[usr_Password],
                    [usr].[rol_Id]
    FROM            [Acce].[tbUsers] AS [usr]
    WHERE           [usr].[usr_Username] = @usr_Username
    AND            CONVERT(VARCHAR(50), DECRYPTBYPASSPHRASE('temere id est nuntius',[usr].[usr_Password],1,CONVERT(VARBINARY,@usr_Username))) = @usr_Password COLLATE SQL_Latin1_General_CP1_CS_AS
END
GO

/*SECTION #8*/
GO
CREATE PROCEDURE [UDP_Admin_tbPictures_Insert]
--========================================================
--Author:       Nicole Ramos
--Create date:  31/01/2023
--Description:  Insert pictures to database.
--========================================================
    @pic_PicturePath	VARCHAR(MAX),
    @usr_Id				INT
AS
BEGIN
    INSERT [Admin].[tbPictures] ([pic].[pic_PicturePath], [pic].[usr_Id]) VALUES(@pic_PicturePath, @usr_Id)
END
GO


--==============================INSERTS==============================
/*SECTION #5*/

INSERT [Acce].[tbRoles] ([rol_Description]) VALUES ( N'Admin')
INSERT [Acce].[tbRoles] ([rol_Description]) VALUES ( N'User')
GO

SELECT * FROM Acce.tbRoles

/*SECTION #6*/

--INSERT [Acce].[tbUsers] ([usr_Username],[usr_Password],[rol_Id]) VALUES ( N'nickramen',N'nickramen',2)
--INSERT [Acce].[tbUsers] ([usr_Username],[usr_Password],[rol_Id]) VALUES ( N'User')
--GO


EXEC [UDP_Acce_tbUsers_Insert] 'nickramen', 'admin1234',2
EXEC [UDP_Acce_tbUsers_Insert] 'ramennick', 'admin4321',2

SELECT * FROM Acce.tbUsers

EXEC [UDP_Acce_tbUsers_Login] 'nickramen','admin1234'


/*SECTION #7*/

INSERT [Admin].[tbPictures] ([pic_PicturePath],[usr_Id]) VALUES ( N'This is a user path',1)
INSERT [Admin].[tbPictures] ([pic_PicturePath],[usr_Id]) VALUES ( N'This is another user path',1)
GO

SELECT * FROM Admin.tbPictures

--==============================JOINS==============================
/*SECTION #8*/
SELECT * FROM Admin.tbPictures AS pic
JOIN Acce.tbUsers AS usr ON pic.usr_Id = usr.usr_Id
WHERE pic.usr_Id = 1


SELECT * FROM Admin.tbPictures AS pic
JOIN Acce.tbUsers AS usr ON pic.usr_Id = usr.usr_Id
WHERE pic.usr_Id = 1