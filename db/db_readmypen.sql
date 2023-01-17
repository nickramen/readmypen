CREATE DATABASE db_readmypen
GO
USE db_readmypen
GO
CREATE TABLE tb_pictures(
	pic_id					INT PRIMARY KEY IDENTITY,
	pic_picturePath			NVARCHAR(MAX), 
	pic_transcriptionDoc	NVARCHAR(MAX)
)