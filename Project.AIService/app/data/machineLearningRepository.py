from data.config import connection_string
import pyodbc
from data.data import MachineLearning
connection = pyodbc.connect(connection_string)
sql = connection.cursor()
def GetAll():
    sql.execute("SELECT * FROM MachineLearning")
    rows = sql.fetchall()
    data = []
    for row in rows:
        machine_learning = MachineLearning(MachineID=row.MachineID.lower(), MachineName=row.MachineName)
        data.append(machine_learning.dict())
    return data
def GetByID(id):
    sql.execute(f"SELECT * FROM MachineLearning WHERE MachineID = '{id}'")
    row = sql.fetchone()
    if row:
        machine_learning = MachineLearning(MachineID=row.MachineID.lower(), MachineName=row.MachineName)
        data = machine_learning.dict()
    else:
        data = None
    return data
def Create(name):
    query = "INSERT INTO MachineLearning (MachineName) VALUES (?)"
    values = (name,)
    sql.execute(query, values)
    connection.commit()
    count = sql.rowcount
    if count > 0:
        return True
    else:
        return False
def Update(id, name):
    query = "UPDATE MachineLearning SET MachineName = ? WHERE MachineID = ?"
    values = (name, id)
    sql.execute(query, values)
    connection.commit()
    count = sql.rowcount
    if count > 0:
        return True
    else:
        return False
def Delete(id):
    query = "DELETE FROM MachineLearning WHERE MachineID = ?"
    values = (id,)
    sql.execute(query, values)
    connection.commit()
    count = sql.rowcount 
    if count > 0:
        return True
    else:
        return False