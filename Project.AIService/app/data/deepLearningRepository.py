from data.config import connection_string
import pyodbc
from data.data import DeepLearning
connection = pyodbc.connect(connection_string)
sql = connection.cursor()
def GetAll():
    sql.execute("SELECT * FROM DeepLearning")
    rows = sql.fetchall()
    data = []
    for row in rows:
        deep_learning = DeepLearning(DeepID=row.DeepID.lower(), DeepName=row.DeepName)
        data.append(deep_learning.dict())
    return data
def GetByID(id):
    sql.execute(f"SELECT * FROM DeepLearning WHERE DeepID = '{id}'")
    row = sql.fetchone()
    if row:
        machine_learning = DeepLearning(DeepID=row.DeepID.lower(), DeepName=row.DeepName)
        data = machine_learning.dict()
    else:
        data = None
    return data
def Create(name):
    query = "INSERT INTO DeepLearning (DeepName) VALUES (?)"
    values = (name,)
    sql.execute(query, values)
    connection.commit()
    count = sql.rowcount
    if count > 0:
        return True
    else:
        return False
def Update(id, name):
    query = "UPDATE DeepLearning SET DeepName = ? WHERE DeepID = ?"
    values = (name, id)
    sql.execute(query, values)
    connection.commit()
    count = sql.rowcount
    if count > 0:
        return True
    else:
        return False
def Delete(id):
    query = "DELETE FROM DeepLearning WHERE DeepID = ?"
    values = (id,)
    sql.execute(query, values)
    connection.commit()
    count = sql.rowcount 
    if count > 0:
        return True
    else:
        return False