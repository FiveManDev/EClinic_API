from pydantic import BaseModel
from datetime import datetime

class Model(BaseModel):
    ModelName: str
    Accuracy: float
    Time: datetime = datetime.now()
    Description:str
    IsActive:bool = False
class ModelDtos(BaseModel):
    ModelID:str
    ModelName: str
    Accuracy: float
    Time: datetime = datetime.now()
    Description:str
    IsActive:bool = False