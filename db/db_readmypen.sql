CREATE DATABASE db_readmypen
GO
USE db_readmypen
GO
CREATE TABLE tb_pictures(
	pic_id					INT PRIMARY KEY IDENTITY,
	pic_path			NVARCHAR(MAX)
)

INSERT INTO tb_pictures VALUES('this is a path');

SELECT * FROM tb_pictures;


