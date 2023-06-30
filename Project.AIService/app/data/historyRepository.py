from data.config import connection_string
import pyodbc
from datetime import datetime
from data.data import MachineLearning,DeepLearning,PredictionHistoryALL,PredictionHistory
connection = pyodbc.connect(connection_string)
sql = connection.cursor()
def GetAll():
    try:
        query = '''
            SELECT *
            FROM PredictionHistory
            '''
        sql.execute(query)
        rows = sql.fetchall()
        data = []
        for row in rows:
            history = PredictionHistoryALL(
                PredictID=row[0].lower(),
                PredictTime=str(row[3]),
                Result=row[2]
            )
            data.append(history.dict())
        return data
    except Exception as e:
        print("An error occurred:", str(e))
        return []

def GetByID(id):
    try:
        query = f'''
                SELECT
                    P."PredictID",
                    P."Note",
                    P."Result",
                    P."PredictTime",
                    M."MachineID",
                    ML."MachineName",
                    M."DeepID",
                    DL."DeepName"
                FROM
                    "PredictionHistory" P
					JOIN "Model" M ON M."ModelID" = P."ModelID"
                    JOIN "MachineLearning" ML ON M."MachineID" = ML."MachineID"
                    JOIN "DeepLearning" DL ON M."DeepID" = DL."DeepID"
                WHERE PredictID = '{id}'
                '''
        sql.execute(query)
        row = sql.fetchone()
        if row:
            history = PredictionHistory(
                    PredictID=row[0].lower(),
                    Note=row[1],
                    Result=row[2],
                    PredictTime=str(row[3]),
                    MachineLearning=MachineLearning(
                        MachineID=row[4].lower(),
                        MachineName=row[5]
                    ),
                    DeepLearning=DeepLearning(
                        DeepID=row[6].lower(),
                        DeepName=row[7]
                    )
                )
            data = history.dict()
        else:
            data = None
        return data
    except Exception as e:
        print("An error occurred:", str(e))
        return []
def Create(Note,Result,ModelID):
    try:
        query = "INSERT INTO PredictionHistory (Note,Result,PredictTime,ModelID) VALUES (?, ?, ?, ?)"
        values = (Note,Result,datetime.now(),ModelID)
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