from data.config import connection_string
import pyodbc
from data.data import Model, MachineLearning, DeepLearning, ModelAll
from datetime import datetime

connection = pyodbc.connect(connection_string)
sql = connection.cursor()

def GetAll():
    try:
        query = '''
            SELECT
                M."ModelID",
                M."FileURL",
                M."Accuracy",
                M."IsActive",
                M."CreatedAt",
                M."UpdatedAt",
                M."MachineID",
                ML."MachineName",
                M."DeepID",
                DL."DeepName"
            FROM
                "Model" M
                JOIN "MachineLearning" ML ON M."MachineID" = ML."MachineID"
                JOIN "DeepLearning" DL ON M."DeepID" = DL."DeepID"
            '''
        sql.execute(query)
        rows = sql.fetchall()
        data = []
        for row in rows:
            model = ModelAll(
                ModelID=row[0].lower(),
                Accuracy=row[2],
                IsActive=row[3],
                MachineLearning=MachineLearning(
                    MachineID=row[6].lower(),
                    MachineName=row[7]
                ),
                DeepLearning=DeepLearning(
                    DeepID=row[8].lower(),
                    DeepName=row[9]
                )
            )
            data.append(model.dict())
        return data
    except Exception as e:
        print("An error occurred:", str(e))
        return []

def GetByID(id):
    try:
        query = f'''
            SELECT
                M."ModelID",
                M."FileURL",
                M."Accuracy",
                M."IsActive",
                M."CreatedAt",
                M."UpdatedAt",
                M."MachineID",
                ML."MachineName",
                M."DeepID",
                DL."DeepName"
            FROM
                "Model" M
                JOIN "MachineLearning" ML ON M."MachineID" = ML."MachineID"
                JOIN "DeepLearning" DL ON M."DeepID" = DL."DeepID"
            WHERE ModelID = '{id}'
            '''
        sql.execute(query)

        row = sql.fetchone()
        if row:
            model = Model(
                ModelID=row[0].lower(),
                Accuracy=row[2],
                IsActive=row[3],
                CreatedAt=str(row[4]),
                UpdatedAt=str(row[5]),
                MachineLearning=MachineLearning(
                    MachineID=row[6].lower(),
                    MachineName=row[7]
                ),
                DeepLearning=DeepLearning(
                    DeepID=row[8].lower(),
                    DeepName=row[9]
                )
            )
            data = model.dict()
        else:
            data = None
        return data
    except Exception as e:
        print("An error occurred:", str(e))
        return []

def Create(Accuracy, MachineID, DeepID, FileURL):
    try:
        query = "INSERT INTO Model (FileURL,Accuracy,IsActive,CreatedAt,UpdatedAt,MachineID,DeepID) VALUES (?,?,?,?,?,?,?)"
        values = (FileURL, Accuracy, False, datetime.now(), datetime.now(), MachineID, DeepID)
        sql.execute(query, values)
        connection.commit()
        count = sql.rowcount
        if count > 0:
            return True
        else:
            return False
    except Exception as e:
        print("An error occurred:", str(e))
        return False

def Update(ModelID,Accuracy, MachineID, DeepID, FileURL):
    try:
        if FileURL is None:
            query = "UPDATE Model SET Accuracy = ?,MachineID= ?,DeepID=?,UpdatedAt =? WHERE ModelID = ?"
            values = (Accuracy, MachineID, DeepID, datetime.now(), ModelID)
        else:
            query = "UPDATE Model SET Accuracy = ?,MachineID= ?,DeepID=? ,FileURL=?,UpdatedAt =? WHERE ModelID = ?"
            values = (Accuracy, MachineID, DeepID, FileURL,datetime.now(), ModelID)
        sql.execute(query, values)
        connection.commit()
        count = sql.rowcount
        if count > 0:
            return True
        else:
            return False
    except Exception as e:
        # Handle the exception here
        print("An error occurred:", str(e))
        return False

def Delete(id):
    try:
        query = "DELETE FROM Model WHERE ModelID = ?"
        values = (id,)
        sql.execute(query, values)
        connection.commit()
        count = sql.rowcount
        if count > 0:
            return True
        else:
            return False
    except Exception as e:
        print("An error occurred:", str(e))
        return False
