from data.config import connection_string
import pyodbc
from data.data import Model
connection = pyodbc.connect(connection_string)
sql = connection.cursor()
def GetAll():
    sql.execute("SELECT * FROM Model")
    rows = sql.fetchall()
    data = []
    for row in rows:
        deep_learning = Model(ModelID=row.ModelID.lower(), FileURL=row.FileURL ,Accuracy=row.Accuracy
                              ,IsActive=row.IsActive,CreatedAt=row.CreatedAt,UpdatedAt=row.UpdatedAt
                              ,MachineID=row.MachineID,DeepID=row.DeepID)
        data.append(deep_learning.dict())
    return data
def GetByID(id):
    sql.execute(f"SELECT * FROM Model WHERE DeepID = '{id}'")
    row = sql.fetchone()
    if row:
        machine_learning = Model(DeepID=row.DeepID.lower(), DeepName=row.DeepName)
        data = machine_learning.dict()
    else:
        data = None
    return data
def Create(name):
    query = "INSERT INTO Model (DeepName) VALUES (?)"
    values = (name,)
    sql.execute(query, values)
    connection.commit()
    count = sql.rowcount
    if count > 0:
        return True
    else:
        return False
def Update(id, name):
    query = "UPDATE Model SET DeepName = ? WHERE DeepID = ?"
    values = (name, id)
    sql.execute(query, values)
    connection.commit()
    count = sql.rowcount
    if count > 0:
        return True
    else:
        return False
def Delete(id):
    query = "DELETE FROM Model WHERE DeepID = ?"
    values = (id,)
    sql.execute(query, values)
    connection.commit()
    count = sql.rowcount 
    if count > 0:
        return True
    else:
        return False