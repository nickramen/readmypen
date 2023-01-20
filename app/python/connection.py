import pyodbc

conn_str = 'DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-N8HS364\SQLEXPRESS;DATABASE=db_readmypen;Trusted_Connection=yes;'
conn = pyodbc.connect(conn_str)

query = conn.cursor()
query.execute("SELECT * FROM tb_pictures")

results = query.fetchall()
for row in results:
    print(row)

# close the cursor and connection
query.close()
conn.close()
