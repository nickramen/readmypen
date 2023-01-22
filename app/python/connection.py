import pyodbc
import json

#path = request.form['path']

conn_str = 'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-N8HS364\SQLEXPRESS;DATABASE=db_readmypen;Trusted_Connection=yes;'
conn = pyodbc.connect(conn_str)

query = conn.cursor()
# query.execute("SELECT * FROM tb_pictures")
# results = query.fetchall()
# for row in results:
#     print(row)

path = 'John Doe'

query.execute("INSERT INTO tb_pictures (pic_path) VALUES (?)", (path))
query.commit()


# close the cursor and connection
query.close()
conn.close()