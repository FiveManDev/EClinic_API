from pydantic import BaseModel,Field
from datetime import datetime
class MachineLearning(BaseModel):
    MachineID: str
    MachineName: str
class DeepLearning(BaseModel):
    DeepID: str
    DeepName: str
class Model(BaseModel):
    ModelID:str
    FileURL: str
    Accuracy: float
    IsActive: bool
    CreatedAt: datetime
    UpdatedAt: datetime
    MachineID: str
    DeepID: str
class PredictionHistory(BaseModel):
    PredictID:str
    Note: str
    Result: str
    PredictTime: datetime
    ModelID: str
class ModelDtos(BaseModel):
    Accuracy: float
    IsActive: bool
    CreatedAt: datetime
    UpdatedAt: datetime
    MachineID: str
    MachineID: str