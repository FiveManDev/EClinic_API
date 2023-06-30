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
    Accuracy: float
    IsActive: bool
    CreatedAt: str
    UpdatedAt: str
    MachineLearning: MachineLearning
    DeepLearning: DeepLearning
class ModelAll(BaseModel):
    ModelID:str
    Accuracy: float
    IsActive: bool
    MachineLearning: MachineLearning
    DeepLearning: DeepLearning
class PredictionHistoryALL(BaseModel):
    PredictID:str
    Result: str
    PredictTime: str
class PredictionHistory(BaseModel):
    PredictID:str
    Note:str
    Result: str
    PredictTime: str
    MachineLearning: MachineLearning
    DeepLearning: DeepLearning
class ModelDtos(BaseModel):
    Accuracy: float
    IsActive: bool
    CreatedAt: datetime
    UpdatedAt: datetime
    MachineID: str
    MachineID: str